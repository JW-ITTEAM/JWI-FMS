import { observer } from "mobx-react-lite";
import { Link, useLocation, withRouter } from "react-router-dom";
import { useStore } from "../../stores/store";
import firebaseConn from "../../utils/FireBaseManager";
import { MsgManager } from "../../utils/MsgManager";

export interface RegisterProps {}

function Register(props: RegisterProps) {
  const location: any = useLocation();
  const { commonStore, loginStore } = useStore();
  commonStore.fullPageControl(location.pathname);

  const signUpEmail = async (event: any) => {
    event.preventDefault();
    firebaseConn.signUpEmail(
      loginStore.userRegisterProps.email,
      loginStore.userRegisterProps.password,
      loginStore.userRegisterProps.passwordconfirm,
      loginStore.userRegisterProps.chkagree
    );
  };

  return (
    <div>
      <div className="d-flex align-items-center auth px-0 h-100">
        <div className="row w-100 mx-0">
          <div className="col-lg-4 mx-auto">
            <div className="card text-left py-5 px-4 px-sm-5">
              <div className="brand-logo">
                <img
                  src={require("./../../assets/images/logo_image/logo-90degree.png")}
                  alt="logo"
                />
              </div>
              <h4>New here?</h4>
              <h6 className="font-weight-light">
                Signing up is easy. It only takes a few steps
              </h6>
              <form className="pt-3">
                <div className="form-group">
                  <input
                    type="email"
                    className="form-control form-control-lg"
                    id="exampleInputEmail1"
                    placeholder="Email"
                    name="email"
                    value={loginStore.userRegisterProps.email}
                    onChange={(e) => loginStore.onChangeProps(e, "register")}
                  />
                </div>
                {/* <div className="form-group">
                  <input
                    type="text"
                    className="form-control form-control-lg"
                    id="exampleInputUsername1"
                    placeholder="Username"
                    name="username"
                    value={loginStore.userRegisterProps.username}
                    onChange={(e) => loginStore.onChangeProps(e, "register")}
                  />
                </div> */}
                <div className="form-group">
                  <input
                    type="password"
                    className="form-control form-control-lg"
                    id="exampleInputPassword1"
                    placeholder="Password"
                    autoComplete="on"
                    name="password"
                    value={loginStore.userRegisterProps.password}
                    onChange={(e) => loginStore.onChangeProps(e, "register")}
                  />
                </div>
                <div className="form-group">
                  <input
                    type="password"
                    className="form-control form-control-lg"
                    id="exampleInputPassword2"
                    placeholder="Password Confirm"
                    autoComplete="on"
                    name="passwordconfirm"
                    value={loginStore.userRegisterProps.passwordconfirm}
                    onChange={(e) => loginStore.onChangeProps(e, "register")}
                  />
                </div>
                <div className="mb-4">
                  <div className="form-check">
                    <label className="form-check-label text-muted">
                      <input
                        type="checkbox"
                        name="chkagree"
                        className="form-check-input"
                        checked={!!loginStore.userRegisterProps.chkagree}
                        onChange={(e) =>
                          loginStore.onChangeProps(e, "register")
                        }
                      />
                      <i className="input-helper"></i>I agree to all Terms &
                      Conditions
                    </label>
                  </div>
                </div>
                <div className="mt-3">
                  <Link
                    className="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn"
                    to="/dashboard"
                    onClick={signUpEmail}
                  >
                    SIGN UP
                  </Link>
                </div>
                <div className="text-center mt-4 font-weight-light">
                  Already have an account?{" "}
                  <Link to="/login" className="text-primary">
                    Login
                  </Link>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default withRouter(observer(Register));
