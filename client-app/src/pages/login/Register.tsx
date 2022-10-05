import { observer } from "mobx-react-lite";
import { Link, useLocation, withRouter } from "react-router-dom";
import {
  DASHBOARD_URI,
  LOGIN_URI,
  REQUESTINFO_URI,
} from "../../config/UriConfig";
import { useStore } from "../../stores/store";
import firebaseConn from "../../utils/FireBaseManager";

export interface RegisterProps {}

function Register(props: RegisterProps) {
  const location: any = useLocation();
  const { commonStore, loginStore } = useStore();
  const isRequestInfo = location.pathname === REQUESTINFO_URI;
  commonStore.fullPageControl(location.pathname);

  const signUpEmail = async (event: any) => {
    event.preventDefault();
    await firebaseConn.signUpEmail(loginStore);
  };

  const reqInfoSubmit = async (event: any) => {
    event.preventDefault();
    await firebaseConn.saveDbUser(loginStore);
  };

  return (
    <div>
      <div className="d-flex align-items-center auth px-0 h-100">
        <div className="row w-100 mx-0">
          <div className="col-lg-7 mx-auto">
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
                {!isRequestInfo && (
                  <div className="row">
                    <div className="col-lg-6">
                      <div className="form-group">
                        <input
                          type="email"
                          className="form-control form-control-lg"
                          placeholder="Email"
                          name="email"
                          value={loginStore.userRegisterProps.email}
                          onChange={(e) =>
                            loginStore.onChangeProps(e, "register")
                          }
                        />
                      </div>
                    </div>
                    <div className="col-lg-6">
                      <div className="form-group">
                        <input
                          type="text"
                          className="form-control form-control-lg"
                          placeholder="Username"
                          name="username"
                          value={loginStore.userRegisterProps.username}
                          onChange={(e) =>
                            loginStore.onChangeProps(e, "register")
                          }
                        />
                      </div>
                    </div>
                  </div>
                )}

                <div className="row">
                  <div className="col-lg-6">
                    <div className="form-group">
                      <input
                        type="phone"
                        className="form-control form-control-lg"
                        placeholder="Phone"
                        name="phone"
                        value={loginStore.userRegisterProps.phone}
                        onChange={(e) =>
                          loginStore.onChangeProps(e, "register")
                        }
                      />
                    </div>
                  </div>
                  <div className="col-lg-6">
                    <div className="form-group">
                      <input
                        type="text"
                        className="form-control form-control-lg"
                        placeholder="Fax"
                        name="fax"
                        value={loginStore.userRegisterProps.fax}
                        onChange={(e) =>
                          loginStore.onChangeProps(e, "register")
                        }
                      />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-lg-6">
                    <div className="form-group">
                      <input
                        type="text"
                        className="form-control form-control-lg"
                        placeholder="Company Name (Not Fix)"
                        name="companyname"
                        value={loginStore.userRegisterProps.companyname}
                        onChange={(e) =>
                          loginStore.onChangeProps(e, "register")
                        }
                      />
                    </div>
                  </div>
                  <div className="col-lg-6">
                    <div className="form-group">
                      <input
                        type="text"
                        className="form-control form-control-lg"
                        placeholder="Department"
                        name="dept"
                        value={loginStore.userRegisterProps.dept}
                        onChange={(e) =>
                          loginStore.onChangeProps(e, "register")
                        }
                      />
                    </div>
                  </div>
                </div>
                {!isRequestInfo && (
                  <div className="row">
                    <div className="col-lg-6">
                      <div className="form-group">
                        <input
                          type="password"
                          className="form-control form-control-lg"
                          placeholder="Password"
                          autoComplete="on"
                          name="password"
                          value={loginStore.userRegisterProps.password}
                          onChange={(e) =>
                            loginStore.onChangeProps(e, "register")
                          }
                        />
                      </div>
                    </div>
                    <div className="col-lg-6">
                      <div className="form-group">
                        <input
                          type="password"
                          className="form-control form-control-lg"
                          placeholder="Password Confirm"
                          autoComplete="on"
                          name="passwordconfirm"
                          value={loginStore.userRegisterProps.passwordconfirm}
                          onChange={(e) =>
                            loginStore.onChangeProps(e, "register")
                          }
                        />
                      </div>
                    </div>
                  </div>
                )}

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

                {isRequestInfo ? (
                  <div className="mt-3">
                    <Link
                      className="btn btn-block btn-success btn-lg font-weight-medium auth-form-btn"
                      to={DASHBOARD_URI}
                      onClick={reqInfoSubmit}
                    >
                      SUBMIT
                    </Link>
                  </div>
                ) : (
                  <div>
                    <div className="mt-3">
                      <Link
                        className="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn"
                        to={DASHBOARD_URI}
                        onClick={signUpEmail}
                      >
                        SIGN UP
                      </Link>
                    </div>
                    <div className="text-center mt-4 font-weight-light">
                      Already have an account?{" "}
                      <Link to={LOGIN_URI} className="text-primary">
                        Login
                      </Link>
                    </div>
                  </div>
                )}
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default withRouter(observer(Register));
