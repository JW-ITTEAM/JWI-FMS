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

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
);

const labels = ["INVOICE", "CRDR", "AP"];

export const data = {
  labels,
  datasets: [
    {
      label: "Dataset 2",
      data: labels.map(() => faker.datatype.number({ min: 0, max: 1000 })),
      borderColor: "rgb(53, 162, 235)",
      backgroundColor: "rgba(53, 162, 235, 0.5)",
    },
  ],
};

export const options = {
  indexAxis: "y" as const,
  elements: {
    bar: {
      borderWidth: 2,
    },
  },
  responsive: true,
  plugins: {
    legend: {
      position: "right" as const,
    },
    title: {
      display: true,
      text: "Chart.js Horizontal Bar Chart",
    },
  },
};

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
            <div className="card-header">[HARDCODE] SPC GLOBAL LCC</div>
            <div className="card-body">
              <table className="table">
                <tbody>
                  <tr>
                    <td>MBL</td>
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
      <div className="row mt-3">
        <div className="col-lg-4">
          <div className="card h-100 stretch-card">
            <div className="card-header">INVOICE</div>
            <div className="card-body">
              <table className="table table-hover">
                <tbody>
                  <tr>
                    <td>
                      <div>INV-76423</div>
                      <div>YS GARMENTS INC. DBA NEXT LEVEL APPAREL</div>
                    </td>
                    <td className="text-right">$335.00</td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div className="card-footer">
              <div className="row">
                <div className="col-lg-7">
                  <div className="small">number of invoice</div>
                  <div>1</div>
                </div>
                <div className="col-lg-5 text-right">
                  <div className="small">invoice total</div>
                  <div className="text-right">$335.00</div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="col-lg-4">
          <div className="card h-100 stretch-card">
            <div className="card-header">CRDR</div>
            <div className="card-body">
              <table className="table table-hover">
                <tbody>
                  <tr>
                    <td>
                      <div>CRDR-63214</div>
                      <div>SEABOARD MARINE LTD</div>
                    </td>
                    <td>
                      <div className="text-right">$770.00</div>
                    </td>
                  </tr>
                  <tr>
                    <td>
                      <div>22070529</div>
                      <div>REPRESENTACIONES S.Y.D</div>
                    </td>
                    <td>
                      <div className="text-right">$-155.00</div>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div className="card-footer">
              <div className="row">
                <div className="col-lg-7">
                  <div className="small">number of credit debit</div>
                  <div>2</div>
                </div>
                <div className="col-lg-5 text-right">
                  <div className="small">credit debit total</div>
                  <div>$615.00</div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="col-lg-4">
          <div className="card h-100 stretch-card">
            <div className="card-header">ACCOUNT PAYABLE</div>
            <div className="card-body">
              <table className="table table-hover">
                <tbody>
                  <tr>
                    <td>
                      <div>1626492</div>
                      <div>SEABOARD MARINE LTD</div>
                    </td>
                    <td className="text-right">$5,054.00</td>
                  </tr>
                  <tr>
                    <td>
                      <div>104236</div>
                      <div>C-AIR-MIAMI</div>
                    </td>
                    <td className="text-right">$75.00</td>
                  </tr>
                  <tr>
                    <td>
                      <div>32443</div>
                      <div>UNIQUE EXPRESS CO., LTD</div>
                    </td>
                    <td className="text-right">$7,150.00</td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div className="card-footer">
              <div className="row">
                <div className="col-lg-7">
                  <div className="small">number of account payable</div>
                  <div>3</div>
                </div>
                <div className="col-lg-5 text-right">
                  <div className="small">account payable total</div>
                  <div>$13,179.00</div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className="row mt-3">
        <div className="col-lg-4">
          <div className="card h-100">
            <div className="card-header">INVOICE FILES</div>
            <div className="card-body">
              <div className="row">
                <div className="col-lg-6">
                  <select className="custom-select form-control">
                    <option selected>INVOICE FILE TYPE</option>
                    <option>ISF</option>
                    <option>HOUSE B/L</option>
                    <option>PACKING LIST</option>
                    <option>COMMERCIAL INVOICE</option>
                    <option>CUSTOMS DOCUMENT</option>
                    <option>PROOF OF DELIVERY</option>
                    <option>QUOTATION</option>
                    <option>OTHER</option>
                  </select>
                </div>
                <div className="col-lg-6">
                  <div className="custom-file">
                    <input type="file" className="custom-file-input" />
                    <label className="custom-file-label">
                      SELECT FILE TYPE
                    </label>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="col-lg-4">
          <div className="card h-100">
            <div className="card-header">CRDR FILES</div>
            <div className="card-body">
              <div className="row">
                <div className="col-lg-6">
                  <select className="form-control">
                    <option selected>CRDR FILES</option>
                  </select>
                </div>
                <div className="col-lg-6">
                  <div className="custom-file">
                    <input type="file" className="custom-file-input" />
                    <label className="custom-file-label">
                      SELECT FILE TYPE
                    </label>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="col-lg-4">
          <div className="card h-100">
            <div className="card-header">ACCOUNT PAYABLE FILES</div>
            <div className="card-body">
              <div className="row">
                <div className="col-lg-6">
                  <select className="form-control">
                    <option selected>AP FILE TYPE</option>
                  </select>
                </div>
                <div className="col-lg-6">
                  <div className="custom-file">
                    <input type="file" className="custom-file-input" />
                    <label className="custom-file-label">
                      SELECT FILE TYPE
                    </label>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className="row mt-3">
        <div className="col-lg-6">
          <div className="card h-100">
            <div className="card-header">COMMENTS</div>
            <div className="card-body">
              <div className="row">
                <div className="col-lg-12">
                  <div className="input-group">
                    <input type="text" className="form-control" />
                    <div className="input-group-append">
                      <button className="btn btn-primary">SEND</button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="col-lg-6">
          <div className="card h-100">
            <div className="card-header">PROFIT</div>
            <div className="card-body">
              <div className="row">
                <div className="col-lg-6">
                  <table className="table table-bordered">
                    <tbody>
                      <tr className="">
                        <td>TOTAL</td>
                        <td className="text-right">$13794.00</td>
                      </tr>
                      <tr>
                        <td>INVOICE</td>
                        <td className="text-right">$335.00</td>
                      </tr>
                      <tr>
                        <td>CRDR</td>
                        <td className="text-right">$615.00</td>
                      </tr>
                      <tr>
                        <td>AP</td>
                        <td className="text-right">$13179.00</td>
                      </tr>
                    </tbody>
                  </table>
                </div>
                <div className="col-lg-6">
                  <Bar data={data} options={options} />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default withRouter(OceanImportDetail);
