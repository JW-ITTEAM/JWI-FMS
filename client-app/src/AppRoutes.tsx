import React, { lazy, Suspense } from "react";
import { Redirect, Route, Switch } from "react-router-dom";
import AuthRoute from "./components/routeHelper/AuthRoute";

export interface IAppRoutesProps {}

const OceanImport = lazy(() => import("./pages/shipments/oim/OceanImport"));
const OceanImportDetail = lazy(
  () => import("./pages/shipments/oim/OceanImportDetail")
);
const OceanExport = lazy(() => import("./pages/shipments/oex/OceanExport"));
const AirImport = lazy(() => import("./pages/shipments/aim/AirImport"));
const AirExport = lazy(() => import("./pages/shipments/aex/AirExport"));

const ShipmentIntgBoard = lazy(() => import("./pages/shipments/IntgBoard"));
const ShipmentIntgBoardOceanDetail = lazy(
  () => import("./pages/shipments/IntgBoardOceanDetail")
);

const Dashboard = lazy(() => import("./pages/dashboard/Dashboard"));
const BasicTable = lazy(() => import("./pages/tables/BasicTable"));
const Login = lazy(() => import("./pages/login/Login"));
const Register = lazy(() => import("./pages/login/Register"));
const EmailConfirm = lazy(() => import("./pages/login/EmailConfirm"));

const Token = localStorage.getItem("Token");
const IsLogin = !!Token;
console.log("IsLogin : " + IsLogin);
console.log("Token : " + Token);

export default class AppRoutes extends React.Component<IAppRoutesProps> {
  public render() {
    return (
      <Suspense>
        <Switch>
          <Route exact path="/shipments/oim" component={OceanImport} />
          <Route path="/shipments/oim_detail/" component={OceanImportDetail} />
          <Route path="/shipments/oex" component={OceanExport} />
          <Route path="/shipments/aim" component={AirImport} />
          <Route path="/shipments/aex" component={AirExport} />
          <Route exact path="/dashboard" component={Dashboard} />
          <Route
            exact
            path="/shipments/intg_board"
            component={ShipmentIntgBoard}
          />
          <Route
            path="/shipments/intg_ocean_detail"
            component={ShipmentIntgBoardOceanDetail}
          />
          <Route path="/tables/basic-table" component={BasicTable} />
          <Route path="/login" component={Login} />
          <Route path="/register" component={Register} />
          <Route path="/emailconfirm" component={EmailConfirm} />
          <AuthRoute path="/test" authenticated={false} component={Dashboard} />
          <Redirect to="/dashboard" />
          {IsLogin ? <Redirect to="/dashboard" /> : <Redirect to="/login" />}
        </Switch>
      </Suspense>
    );
  }
}
