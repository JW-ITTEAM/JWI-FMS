import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useHistory } from "react-router-dom";
import { LoadSpinner } from "../../components/loadSpinner/LoadSpinner";
import { useStore } from "../../stores/store";

export interface IIntgBoardProps {}

function IntgBoard(props: IIntgBoardProps) {
  const history = useHistory();
  const { shipmentStore } = useStore();

  useEffect(() => {
    shipmentStore.loadOceanImportList();
  }, [shipmentStore]);

  const fetchDetail = (RMH_Id: string) => {
    history.push({
      pathname: "/shipments/intg_ocean_detail/" + RMH_Id,
      state: { RMH_Id: RMH_Id },
    });
  };

  return (
    <div>
      <LoadSpinner isLoading={shipmentStore.isLoading} />
      <div className="page-header">
        <h3 className="page-title">SHIPMENTS</h3>
        <nav aria-label="breadcrumb">
          <ol className="breadcrumb">
            <li className="breadcrumb-item">SHIPMENTS</li>
          </ol>
        </nav>
      </div>
      <div>
        <div className="card stretch-card">
          <div className="card-body">
            <div className="row mb-1">
              <div className="col-lg-4">
                <select className="form-control">
                  <option>ALL SHIPMENTS</option>
                  <option>OCEAN</option>
                  <option>AIR</option>
                </select>
              </div>
              <div className="col-lg-4">
                <input
                  type="text"
                  className="form-control"
                  placeholder="SEARCH"
                />
              </div>
              <div className="col-lg-4 text-right">
                <button className="btn btn-primary">CREATE</button>
              </div>
            </div>
            <div className="row">
              <div className="col-lg-12">
                <table className="table table-hover">
                  <thead>
                    <tr>
                      <th>REFERENCE</th>
                      <th>MASTER B/L</th>
                      <th>HOUSE B/L</th>
                      <th>CUSTOMER</th>
                      <th>POL</th>
                      <th>POD</th>
                      <th>ETD</th>
                      <th>ETA</th>
                      <th>STATUS</th>
                      <th>A/N</th>
                    </tr>
                  </thead>
                  <tbody>
                    {shipmentStore.oims.map((data: any) => (
                      <tr
                        key={data.f_RMH_ID}
                        onClick={() => fetchDetail(`${data.f_RMH_ID}`)}
                        style={{ cursor: "pointer" }}
                      >
                        {/* <td>{data.f_RMH_ID}</td> */}
                        <td>{data.f_RefNo ?? ""}</td>
                        <td>{data.f_MBLNo ?? ""}</td>
                        <td>{data.f_HBLNo ?? ""}</td>
                        <td></td>
                        <td>{data.f_LoadingPort ?? ""}</td>
                        <td></td>
                        <td>{data.f_ETD ?? ""}</td>
                        <td>{data.f_ETA ?? ""}</td>
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
    </div>
  );
}

export default observer(IntgBoard);
