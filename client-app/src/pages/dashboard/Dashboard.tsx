import * as React from "react";
import firebaseConn from "../../utils/FireBaseManager";

export interface IDashboardProps {}

export default class Dashboard extends React.Component<IDashboardProps> {
  public render() {
    return (
      <div>
        <h4>Dashboard</h4>
      </div>
    );
  }
}
