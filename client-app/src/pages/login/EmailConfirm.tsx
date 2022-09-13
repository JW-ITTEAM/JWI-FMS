import { observer } from "mobx-react-lite";
import * as React from "react";
import { useLocation, withRouter } from "react-router-dom";
import { useStore } from "../../stores/store";

export interface IEmailConfirmProps {}

function EmailConfirm(props: IEmailConfirmProps) {
  const { commonStore } = useStore();
  const location: any = useLocation();
  commonStore.fullPageControl(location.pathname);

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
              TEST
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default withRouter(observer(EmailConfirm));
