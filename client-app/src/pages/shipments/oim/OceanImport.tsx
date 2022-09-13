import axios from "axios";
import * as React from "react";
import { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";

export interface IOceanImportProps {}

export default function OceanImport(props: IOceanImportProps) {
  const [oims, setOims] = useState([]);
  const [loading, setLoading] = useState(false);

  const history = useHistory();

  useEffect(() => {
    axios
      .get("https://localhost:7077/api/Shipments/getOceanImportList")
      .then((response) => {
        // console.log(response);
        setOims(response.data);
      });
  }, []);

  const fetchDetail = (refNo: string) => {
    // console.log("fetchDetail");
    history.push({
      pathname: "/shipments/oim_detail/" + refNo,
      state: { refNo: refNo },
    });
  };

  return (
    <div>
      <div className="page-header">
        <h3 className="page-title">OCEAN IMPORT</h3>
        <nav aria-label="breadcrumb">
          <ol className="breadcrumb">
            <li className="breadcrumb-item active">Shipments</li>
            <li className="breadcrumb-item">Ocean Import</li>
          </ol>
        </nav>
      </div>
      <div className="row">
        <div className="col-lg-12 stretch-card">
          <div className="card">
            <div className="card-body">
              <table className="table table-hover">
                <thead>
                  <tr>
                    <th>Reference</th>
                    <th>Master B/L</th>
                    <th>House B/L</th>
                    <th>Customer</th>
                    <th>POL</th>
                    <th>POD</th>
                    <th>ETD</th>
                    <th>ETA</th>
                    <th>Status</th>
                    <th>A/N</th>
                  </tr>
                </thead>
                <tbody>
                  {oims.map((data: any) => (
                    <tr
                      key={data.oim.f_RefNo}
                      onClick={() => fetchDetail(`${data.oim.f_RefNo}`)}
                      style={{ cursor: "pointer" }}
                    >
                      <td>{data.oim?.f_RefNo ?? ""}</td>
                      <td>{data.oim?.f_MBLNo ?? ""}</td>
                      <td>{data.oih?.f_HBLNo ?? ""}</td>
                      <td></td>
                      <td>{data.oim?.f_LoadingPort ?? ""}</td>
                      <td></td>
                      <td>{data.oim?.f_ETD ?? ""}</td>
                      <td>{data.oim?.f_ETA ?? ""}</td>
                      <td></td>
                      <td></td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
