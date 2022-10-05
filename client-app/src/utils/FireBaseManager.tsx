import { initializeApp } from "firebase/app";
import {
  getAuth,
  GoogleAuthProvider,
  signInWithPopup,
  signInWithEmailAndPassword,
  sendEmailVerification,
  createUserWithEmailAndPassword,
  User,
  updateProfile,
  signOut,
} from "firebase/auth";
import { isNull } from "lodash";
import {
  FIREBASE_WEB_FMS_API_KEY,
  FMS_CLIENT_URL,
} from "../config/SystemConfig";
import { stringIsNullOrEmpty, validationEmail } from "./CommonUtil";
import { MsgManager } from "./MsgManager";
import LoginStore from "./../stores/loginStore";
import { CurrentUserProps } from "../models/CurrentUserProps";
import nProgress from "nprogress";
import {
  DASHBOARD_URI,
  EMAILCONFIRM_URI,
  LOGIN_URI,
} from "../config/UriConfig";
import axiosConn, { axiosSet } from "./ApiConnection";
import { Vm_User } from "../models/Vm_User";

// Declare Obj
const firebaseApp = initializeApp({
  apiKey: FIREBASE_WEB_FMS_API_KEY,
  authDomain: "fms-api-6a4cb.firebaseapp.com",
  projectId: "fms-api-6a4cb",
  storageBucket: "fms-api-6a4cb.appspot.com",
  messagingSenderId: "738534569841",
  appId: "1:738534569841:web:fb6ebe76761fb349dce8d0",
});

export const auth = getAuth(firebaseApp);
const provider = new GoogleAuthProvider();
const actionCodeSettings = {
  url: FMS_CLIENT_URL + "/" + DASHBOARD_URI,
};
// Declare Obj

// Google Login
const signInGoogleEmail = async () => {
  const userCredential = await signInWithPopup(auth, provider)
    .then(async (result) => {
      console.log("success");
      let user = auth.currentUser;
      await loginOperationProcess(user);
      return result;
    })
    .catch((error) => {
      MsgManager({
        error: error,
      });
      return;
    });
  return userCredential;
};
// Google Login

// Email Password Login and Create Account
const signUpEmail = async (loginStore: LoginStore) => {
  let email = loginStore.userRegisterProps.email;
  let username = loginStore.userRegisterProps.username;
  let password = loginStore.userRegisterProps.password;
  let passwordconfirm = loginStore.userRegisterProps.passwordconfirm;
  let chkagree = loginStore.userRegisterProps.chkagree;

  if (loginValidCheck(email, password, passwordconfirm, username, chkagree)) {
    MsgManager({
      defaultConfirm: true,
    }).then(async (result) => {
      if (result.isConfirmed) {
        const result = await addDbSignUp(loginStore);
        if (!result) {
          return;
        }
        const userCredential = await createUserWithEmailAndPassword(
          auth,
          email,
          password
        )
          .then(async () => {
            let user = auth.currentUser;
            if (user !== null) {
              await emailVerification(user);
              await userUpdateInfo(user, loginStore);
              await loginOperationProcess(user);
            } else {
              MsgManager({
                icon: "error",
                title: "Error!",
                text: "System can not load current user.",
              });
              return;
            }
          })
          .catch((error) => {
            MsgManager({
              error: error,
            });
            return;
          });
        return userCredential;
      }
    });
  }
  return;
};

const emailVerification = async (user: User, messageOn: boolean = false) => {
  await sendEmailVerification(user, actionCodeSettings)
    .then(() => {
      if (messageOn) {
        MsgManager({
          icon: "success",
          title: "Verification email sent successfully.",
        });
      } else {
        console.log("email verification sent");
      }
    })
    .catch((error) => {
      MsgManager({
        error: error,
      });
      return;
    });
};

const saveDbUser = async (loginStore: LoginStore) => {
  nProgress.start();
  const user = getCurrentUser();
  if (user != null) {
    loginStore.setUserRegisterProp("email", user.email);
    loginStore.setUserRegisterProp(
      "username",
      user.displayName?.toUpperCase() ?? ""
    );
    console.log(JSON.stringify(loginStore.userRegisterProps));
    const result = await addDbSignUp(loginStore);
    nProgress.done();
    if (result) {
      localStorage.setItem("UserDbSave", "Saved");
      window.open(DASHBOARD_URI, "_self");
    } else {
      localStorage.removeItem("UserDbSave");
    }
  }
};

const loginEmail = async (loginStore: LoginStore) => {
  let email = loginStore.userLoginProps.email;
  let password = loginStore.userLoginProps.password;
  if (loginValidCheck(email, password)) {
    nProgress.start();
    const userCredential = await signInWithEmailAndPassword(
      auth,
      email,
      password
    )
      .then(async (result) => {
        const user = result.user;
        await loginOperationProcess(user);
        nProgress.done();
      })
      .catch((error) => {
        nProgress.done();
        MsgManager({
          error: error,
        });
        return;
      });
    return userCredential;
  }
};

const logOut = async () => {
  signOut(auth)
    .then(() => {
      localStorage.removeItem("Token");
      window.open(LOGIN_URI, "_self");
    })
    .catch((error) => {
      nProgress.done();
      MsgManager({
        error: error,
      });
      return;
    });
};
// Email Password Login

// Util
const loginValidCheck = (
  email: string,
  password: string,
  passwordconfirm: string | null = null,
  username: string | null = null,
  chkagree: boolean | null = null
) => {
  const emptyEmail = stringIsNullOrEmpty(email);
  const notValidEmail = !validationEmail(email);
  const emptyUsername = !isNull(username) && stringIsNullOrEmpty(username);
  const emptyPassword = stringIsNullOrEmpty(password);
  const emptyPasswordConfirm =
    !isNull(passwordconfirm) && stringIsNullOrEmpty(passwordconfirm);
  const notMatchedPassword =
    !isNull(passwordconfirm) &&
    !emptyPassword &&
    !emptyPasswordConfirm &&
    password !== passwordconfirm;
  const emptyAgree = chkagree === false;

  if (emptyUsername) {
    MsgManager({
      icon: "error",
      title: "Validation error",
      text: "Please input username.",
    });
    return false;
  } else if (emptyEmail) {
    MsgManager({
      icon: "error",
      title: "Validation error",
      text: "Please input email.",
    });
    return false;
  } else if (notValidEmail) {
    MsgManager({
      icon: "error",
      title: "Validation error",
      text: "Wrong email address",
    });
    return false;
  } else if (emptyPassword) {
    MsgManager({
      icon: "error",
      title: "Validation error",
      text: "Please input password.",
    });
    return false;
  } else if (emptyPasswordConfirm) {
    MsgManager({
      icon: "error",
      title: "Validation error",
      text: "Please input password confirm.",
    });
    return false;
  } else if (notMatchedPassword) {
    MsgManager({
      icon: "error",
      title: "Password error",
      text: "Password not matched.",
    });
    return false;
  } else if (emptyAgree) {
    MsgManager({
      icon: "error",
      title: "You have to check the agreement if you want to process.",
      text: "Please check The Argreement of Terms & Condition.",
    });
    return false;
  }
  return true;
};

const setCurrentUserProps = (user: any, loginStore: LoginStore) => {
  const currentUserProps: CurrentUserProps = {
    f_UserName: user?.displayName ?? "",
    f_UserEmail: user?.email ?? "",
    f_Phone: user?.phoneNumber ?? "",
    f_Fax: "",
    f_EmailVerified: user?.emailVerified ?? false,
  };
  loginStore.setCurrentUserProps(currentUserProps);
};

const userUpdateInfo = async (user: any, loginStore: LoginStore) => {
  await updateProfile(user, {
    displayName: loginStore.userRegisterProps.username.toUpperCase(),
  });
};

const addDbSignUp = async (loginStore: LoginStore) => {
  const vm_user: Vm_User = {
    F_UserName: loginStore.userRegisterProps.username,
    F_UserEmail: loginStore.userRegisterProps.email,
    F_Phone: loginStore.userRegisterProps.phone,
    F_FAX: loginStore.userRegisterProps.fax,
    F_Dept: loginStore.userRegisterProps.dept,
    F_CompanyName: loginStore.userRegisterProps.companyname,
  };
  const result = await axiosConn.Accounts.signUp(vm_user)
    .then((result) => {
      if (result) {
        return true;
      }
    })
    .catch((error) => {
      console.log("error : " + error);
      nProgress.done();
      MsgManager({
        error: error,
      });
      return false;
    });
  return result;
};

const loginOperationProcess = async (user: any) => {
  // localstorage save token information.
  localStorage.setItem("Token", user["accessToken"]);
  axiosSet.defaults.headers.common["Authorization"] =
    "Bearer " + user["accessToken"];
  var user_dbinfo: Vm_User = await axiosConn.Accounts.getDbCurrentUser(
    user["email"]
  );

  console.log(JSON.stringify(user_dbinfo));
  let dev = false;
  if (dev) {
    console.log(user);
  } else {
    if (!user.emailVerified) {
      window.open(EMAILCONFIRM_URI, "_self");
      return;
    }

    // user.providerData[0]["providerId"] === "google.com"
    if (
      user_dbinfo === null ||
      user_dbinfo === undefined ||
      user_dbinfo === ""
    ) {
      console.log("No Db Info");
      localStorage.removeItem("UserDbSave");
    } else {
      console.log("Yes Db Info");
      console.log("user_dbinfo : " + user_dbinfo);
      localStorage.setItem("UserDbSave", "Saved");
    }
    window.open(DASHBOARD_URI, "_self");
  }
};

const getCurrentUser = () => {
  let user = auth.currentUser;
  // // if (user === null) {
  // //   window.open(DASHBOARD_URI, "_self");
  // // }
  return user;
};
// Util

export const firebaseConn = {
  signUpEmail,
  loginEmail,
  signInGoogleEmail,
  emailVerification,
  getCurrentUser,
  setCurrentUserProps,
  saveDbUser,
  logOut,
};

export default firebaseConn;
