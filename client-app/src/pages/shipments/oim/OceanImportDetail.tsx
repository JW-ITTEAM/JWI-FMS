import * as React from "react";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
import { Bar } from "react-chartjs-2";
import { faker } from "@faker-js/faker";
import { useLocation, withRouter } from "react-router-dom";
import "../../../assets/styles/partial/oim_detail.scss";

export interface IOceanImportDetailProps {}

function OceanImportDetail(props: IOceanImportDetailProps) {
  const location: any = useLocation();
  return (
    <div>
      <div className="page-header">
        <h3
          className="page-title"
          style={{ marginTop: "11px", marginBottom: "11px" }}
        >
          <i className="mdi mdi"></i>
          {location.state.refNo}
        </h3>
      </div>
      <div className="row">
        <div className="col-lg-6">
          <div className="card h-100">
            <div className="card-header">MASTER B/L INFO</div>
            <div className="card-body">
              <table className="table">
                <tbody>
                  <tr>
                    <td>SHIPPER</td>
                    <td>[HARDCODE] SMLU7266481A</td>
                  </tr>
                  <tr>
                    <td>CARRIER</td>
                    <td>[HARDCODE] SEABOARD MARINE LTD</td>
                  </tr>
                  <tr>
                    <td>AGENT</td>
                    <td>[HARDCODE] REPRESENTACIONES S.Y.D</td>
                  </tr>
                  <tr>
                    <td>VESSEL</td>
                    <td>[HARDCODE] SEABOARD ATLANTIC 481N</td>
                  </tr>
                  <tr>
                    <td>COMMODITY</td>
                    <td>[HARDCODE] MENS OVERCOATS ON HANGERS</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
        <div className="col-lg-6">
          <div className="card h-100">
            <div className="card-header">SHIPMENT</div>
            <div className="card-body">
              <table className="table">
                <tbody>
                  <tr>
                    <td>CREATED</td>
                    <td>[HARDCODE] JENNIFERS</td>
                    <td>[HARDCODE] August 4, 2022</td>
                  </tr>
                  <tr>
                    <td>UPDATED</td>
                    <td>[HARDCODE] JENNIFERS</td>
                    <td>[HARDCODE] August 4, 2022</td>
                  </tr>
                  <tr>
                    <td>SHIP</td>
                    <td>[HARDCODE] SANTO TOMAS DE CASTILLA</td>
                    <td>[HARDCODE] August 7, 2022</td>
                  </tr>
                  <tr>
                    <td>ARRIVAL</td>
                    <td>[HARDCODE] MIAMI, FL</td>
                    <td>[HARDCODE] August 10, 2022</td>
                  </tr>
                  <tr>
                    <td>COMMODITY</td>
                    <td>[HARDCODE] MIAMI, FL</td>
                    <td>[HARDCODE] August 7, 2022</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default withRouter(OceanImportDetail);
