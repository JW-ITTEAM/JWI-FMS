import { onAuthStateChanged } from "firebase/auth";
import { makeAutoObservable } from "mobx";
import { objectPrototype } from "mobx/dist/internal";
import { LOGIN_URI } from "../config/UriConfig";
import { CurrentUserProps } from "../models/CurrentUserProps";
import { UserLoginProps } from "../models/UserLoginProps";
import { UserRegisterProps } from "../models/UserRegisterProps";
import firebaseConn, { auth } from "../utils/FireBaseManager";

export default class LoginStore {
  userLoginProps: UserLoginProps = {
    email: "",
    password: "",
  };

  userRegisterProps: UserRegisterProps = {
    email: "",
    username: "",
    password: "",
    passwordconfirm: "",
    phone: "",
    fax: "",
    companyname: "",
    dept: "",
    chkagree: false,
  };

  currentUserProps: CurrentUserProps = {
    f_UserName: "",
    f_UserEmail: "",
    f_Phone: "",
    f_Fax: "",
    f_EmailVerified: false,
  };

  constructor() {
    makeAutoObservable(this);
  }

  onChangeProps = (event: any, target: string) => {
    type typeOfObjKey = keyof typeof objectPrototype;
    let attType = event.target.attributes.type.nodeValue;
    let name: typeOfObjKey = event.target.name;
    let targetLower = target.toLowerCase();
    let value = event.target.value;
    if (attType === "checkbox") {
      value = event.target.checked;
    }

    if (targetLower === "login") {
      this.userLoginProps[name] = value;
    } else if (targetLower === "register") {
      this.userRegisterProps[name] = value;
    }
  };

  setCurrentUserProps = (props: CurrentUserProps) => {
    this.currentUserProps.f_UserEmail = props.f_UserEmail;
    this.currentUserProps.f_UserName = props.f_UserName;
    this.currentUserProps.f_Phone = props.f_Phone;
    this.currentUserProps.f_Fax = props.f_Fax;
    this.currentUserProps.f_EmailVerified = props.f_EmailVerified;
  };

  setUserRegisterProp = (key: any, value: any) => {
    type typeOfObjKey = keyof typeof objectPrototype;
    let name: typeOfObjKey = key;
    this.userRegisterProps[name] = value;
  };

  loadAuthState = async (returnToLogin: boolean = false) => {
    await onAuthStateChanged(auth, (user) => {
      if (user) {
        // console.log(user);
        // console.log("ok");
        firebaseConn.setCurrentUserProps(user, this);
      } else {
        // console.log("not login status");
        localStorage.removeItem("Token");
        if (returnToLogin) {
          window.open(LOGIN_URI, "_self");
        }
      }
    });
  };
}
