import { observer } from "mobx-react-lite";
import { Button, Form } from "react-bootstrap";
import { Link, useHistory, useLocation, withRouter } from "react-router-dom";
import { useStore } from "../../stores/store";
import firebaseConn from "../../utils/FireBaseManager";

export interface LoginProps {}

function Login(props: LoginProps) {
  const history: any = useHistory();
  const location: any = useLocation();
  const { commonStore, loginStore } = useStore();
  commonStore.fullPageControl(location.pathname);

  const signInSubmit = (event: any) => {
    event.preventDefault();
    firebaseConn.loginEmail(
      loginStore.userLoginProps.email,
      loginStore.userLoginProps.password
    );
  };

  const signInGoogleEmail = async (event: any) => {
    event.preventDefault();
    const userCredential: any = await firebaseConn.signInGoogleEmail();
    console.log(userCredential);
    if (userCredential !== undefined) {
      // login success
      history.push({
        pathname: "/dashboard/",
        userCredential: userCredential.user,
      });
    }
  };

  return (
    <div>
      <div className="d-flex align-items-center auth px-0">
        <div className="row w-100 mx-0">
          <div className="col-lg-4 mx-auto">
            <div className="card text-left py-5 px-4 px-sm-5">
              <div className="brand-logo">
                <img
                  src={require("./../../assets/images/logo_image/logo-90degree.png")}
                  alt="logo"
                />
              </div>
              <h4>Hello! let's get started</h4>
              <h6 className="font-weight-light">Sign in to continue.</h6>
              <Form className="pt-2">
                <Form.Group className="d-flex search-field">
                  <Form.Control
                    type="email"
                    placeholder="Email"
                    name="email"
                    size="lg"
                    className="h-auto"
                    value={loginStore.userLoginProps.email}
                    onChange={(e) => loginStore.onChangeProps(e, "login")}
                  />
                </Form.Group>
                <Form.Group className="mb-1 d-flex search-field">
                  <Form.Control
                    type="password"
                    placeholder="Password"
                    name="password"
                    size="lg"
                    className="h-auto"
                    value={loginStore.userLoginProps.password}
                    onChange={(e) => loginStore.onChangeProps(e, "login")}
                    autoComplete="on"
                  ></Form.Control>
                </Form.Group>
                <div className="d-flex justify-content-between align-items-center">
                  <div className="form-check">
                    <label className="form-check-label text-muted">
                      <input type="checkbox" className="form-check-input" />
                      <i className="input-helper"></i>
                      Keep me signed in
                    </label>
                  </div>
                  <a
                    href="!#"
                    onClick={(evt) => evt.preventDefault()}
                    className="auth-link text-muted"
                  >
                    Forgot password?
                  </a>
                </div>
                <div className="mt-2">
                  <Button
                    type="submit"
                    className="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn"
                    onClick={signInSubmit}
                  >
                    SIGN IN
                  </Button>
                </div>
                <div className="my-3 d-flex justify-content-between align-items-center">
                  <div style={{ fontSize: "13px" }}>
                    Not registered yet?{" "}
                    <span>
                      <Link to="/register">Create an Account</Link>
                    </span>
                  </div>
                </div>
                <div className="mb-2">
                  <button
                    type="button"
                    className="btn btn-block btn-google auth-form-btn"
                    onClick={signInGoogleEmail}
                  >
                    <i className="mdi mdi-google mr-2"></i>Connect using Google
                  </button>
                </div>
              </Form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default withRouter(observer(Login));
