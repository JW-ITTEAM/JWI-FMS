import React, { lazy, Suspense } from "react";
import { Redirect, Route, Switch } from "react-router-dom";
import RouteIf from "./components/routeHelper/RouteIf";
import { DASHBOARD_URI, LOGIN_URI, REQUESTINFO_URI } from "./config/UriConfig";
import { logChk, userDbSaveChk } from "./utils/CommonUtil";

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
const RequestInfo = lazy(() => import("./pages/login/Register"));

//EYJ
const FileUpload = lazy(() => import("./pages/fileDrop/FileUploadPage"));
const IsLogin = logChk(localStorage);
const IsUserDbSaved = userDbSaveChk(localStorage);

export interface IAppRoutesProps {}

export class AppRoutes extends React.Component<IAppRoutesProps> {
  public render() {
    return (
      <Suspense>
        <Switch>
          <RouteIf path={DASHBOARD_URI} component={Dashboard} />
          <RouteIf exact path="/shipments/oim" component={OceanImport} />
          <RouteIf
            path="/shipments/oim_detail/"
            component={OceanImportDetail}
          />
          <RouteIf path="/shipments/oex" component={OceanExport} />
          <RouteIf path="/shipments/aim" component={AirImport} />
          <RouteIf path="/shipments/aex" component={AirExport} />
          <RouteIf
            exact
            path="/shipments/intg_board"
            component={ShipmentIntgBoard}
          />
          <RouteIf
            path="/shipments/intg_ocean_detail"
            component={ShipmentIntgBoardOceanDetail}
          />
          <RouteIf path="/tables/basic-table" component={BasicTable} />
          <RouteIf path="/emailconfirm" component={EmailConfirm} />
          <Route path={LOGIN_URI} component={Login} />
          <Route path="/register" component={Register} />
          <Route path={REQUESTINFO_URI} component={RequestInfo} />
          <Route exact path="/fileDrop/file_upload/" component={FileUpload} />
          {IsLogin ? (
            IsUserDbSaved ? (
              <Redirect to={DASHBOARD_URI} />
            ) : (
              <Redirect to={REQUESTINFO_URI} />
            )
          ) : (
            <Redirect to={LOGIN_URI} />
          )}
        </Switch>
      </Suspense>
    );
  }
}
