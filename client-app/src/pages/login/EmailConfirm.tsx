import { getAuth, User } from "firebase/auth";
import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useLocation, withRouter } from "react-router-dom";
import { useStore } from "../../stores/store";
import firebaseConn, { auth } from "../../utils/FireBaseManager";

export interface IEmailConfirmProps {}

function EmailConfirm(props: IEmailConfirmProps) {
  const { commonStore, loginStore } = useStore();
  const location: any = useLocation();
  commonStore.fullPageControl(location.pathname);

  // useEffect(() => {
  //   if (loginStore.currentUserProps.f_EmailVerified) {
  //     window.location.href = DASHBOARD_URI;
  //   }
  // }, [loginStore.currentUserProps]);

  const sendEmailVerification = async (event: any) => {
    event.preventDefault();
    let user = firebaseConn.getCurrentUser();
    if (user) firebaseConn.emailVerification(user, true);
  };

  // const testFunc = async () => {
  //   const auth = getAuth();
  //   const user = firebaseConn.getCurrentUser();

  //   if (user != null) {
  //     user.providerData.forEach((profile) => {
  //       console.log("profile : " + JSON.stringify(profile));
  //     });
  //   }
  // };

  return (
    <div>
      <div className="d-flex align-items-center auth px-0">
        <div className="row w-100 mx-0">
          <div className="col-lg-4 mx-auto">
            <div className="card text-left py-5 px-4 px-sm-5">
              <div className="row mb-3">
                <div className="col-12">
                  <div className="brand-logo">
                    <img
                      src={require("./../../assets/images/logo_image/logo-90degree.png")}
                      alt="logo"
                    />
                  </div>
                  <h4>Hello! we are waiting for your response.</h4>
                  <h6 className="font-weight-light">
                    To precess your sign in, you need to verificate to your
                    email.
                  </h6>
                </div>
              </div>
              <div className="row mb-2">
                <div className="col-12">
                  <button
                    className="btn btn-primary"
                    onClick={sendEmailVerification}
                  >
                    Resend Email
                  </button>
                </div>
                {/* <div className="col-12">
                  <button className="btn btn-primary" onClick={testFunc}>
                    TestFunc
                  </button>
                </div> */}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default withRouter(observer(EmailConfirm));
