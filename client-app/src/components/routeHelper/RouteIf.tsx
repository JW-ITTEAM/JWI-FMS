import { Redirect, Route } from "react-router-dom";
import { LOGIN_URI, REQUESTINFO_URI } from "../../config/UriConfig";
import { logChk, userDbSaveChk } from "../../utils/CommonUtil";

const RouteIf = ({ role, component: Component, ...rest }: any) => {
  let IsLogin = logChk(localStorage);
  let IsUserDbSaved = userDbSaveChk(localStorage);
  return (
    <Route
      {...rest}
      render={(props) => {
        if (!IsLogin) {
          return <Redirect to={LOGIN_URI} />;
        }

        if (!IsUserDbSaved) {
          return <Redirect to={REQUESTINFO_URI} />;
        }

        if (Component) {
          return <Component {...props} />;
        }
      }}
    />
  );
};

export default RouteIf;
