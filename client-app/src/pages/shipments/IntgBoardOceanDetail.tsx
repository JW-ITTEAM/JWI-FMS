import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useLocation } from "react-router-dom";
import { ActivityLog } from "../../components/activityLog/ActivityLog";
import ActivityLogEvent from "../../components/activityLog/ActivityLogEvent";
import { LoadSpinner } from "../../components/loadSpinner/LoadSpinner";
import { useStore } from "../../stores/store";

export interface IIntgBoardOceanDetailProps {}

function IntgBoardDetail(props: IIntgBoardOceanDetailProps) {
  const location: any = useLocation();
  const colspan_val = 2;
  const { shipmentStore } = useStore();

  useEffect(() => {
    shipmentStore.loadOceanImportDetail(location.state.RMH_Id);
  }, [shipmentStore]);

  if (!shipmentStore.oimdata) return <></>;
  return (
    <div>
      <LoadSpinner isLoading={shipmentStore.isLoading} />
      <div className="page-header">
        <h3
          className="page-title"
          style={{ marginTop: "11px", marginBottom: "11px" }}
        >
          {shipmentStore.oimdata.f_RefNo}
        </h3>
      </div>
      <div className="row mb-4">
        <div className="col-lg-6">
          <div className="card">
            <div className="card-header">
              <div className="row">
                <div className="col-md-6">MASTER</div>
                <div className="col-md-6 text-right">
                  {shipmentStore.oimdata.f_MBLNo}
                </div>
              </div>
            </div>
            <div className="card-body">
              <table className="table">
                <tbody>
                  <tr>
                    <td colSpan={colspan_val}>SHIPPER</td>
                    <td colSpan={colspan_val} className="text-right">
                      {shipmentStore.oimdata.f_M_SName}
                    </td>
                  </tr>
                  <tr>
                    <td colSpan={colspan_val}>CONSIGNEE</td>
                    <td colSpan={colspan_val} className="text-right">
                      {shipmentStore.oimdata.f_M_CName}
                    </td>
                  </tr>
                  <tr>
                    <td colSpan={colspan_val}>NOTIFY</td>
                    <td colSpan={colspan_val} className="text-right">
                      {shipmentStore.oimdata.f_M_NName}
                    </td>
                  </tr>
                  <tr>
                    <td colSpan={colspan_val}>CARRIER</td>
                    <td colSpan={colspan_val} className="text-right">
                      {shipmentStore.oimdata.f_CarrierName}
                    </td>
                  </tr>
                  <tr>
                    <td colSpan={colspan_val}>ISSUE DATE</td>
                    <td colSpan={colspan_val} className="text-right">
                      {shipmentStore.oimdata.f_M_PostDate}
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
        <div className="col-lg-6">
          <div className="card h-100">
            <div className="card-header">
              <div className="row">
                <div className="col-md-6">HOUSE</div>
                <div className="col-md-6 text-right">
                  {shipmentStore.oimdata.f_HBLNo}
                </div>
              </div>
            </div>
            <div className="card-body">
              <table className="table">
                <tbody>
                  <tr>
                    <td style={{ width: "25%" }}>CUSTOMER</td>
                    <td style={{ width: "25%" }} className="text-right">
                      {shipmentStore.oimdata.f_Customer}
                    </td>
                    <td>CUST REF NO.</td>
                    <td>{shipmentStore.oimdata.f_CustRefNo}</td>
                  </tr>
                  <tr>
                    <td>SHIPPER</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_H_SName}
                    </td>
                    <td>CONSIGNEE</td>
                    <td>{shipmentStore.oimdata.f_H_CName}</td>
                  </tr>
                  <tr>
                    <td>NOTIFY</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_H_NName}
                    </td>
                    <td>ISSUE DATE</td>
                    <td>{shipmentStore.oimdata.f_H_PostDate}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
      <div className="row mb-4">
        <div className="col-lg-12">
          <div className="card h-100">
            <div className="card-header">SHIPPING</div>
            <div className="card-body">
              <table className="table">
                <tbody>
                  <tr>
                    <td>VESSEL</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_Vessel}
                    </td>
                    <td>BOOKING NO.</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_BookingNo}
                    </td>
                  </tr>
                  <tr>
                    <td>VOYAGE</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_Voyage}
                    </td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <td style={{ width: "25%" }}>PORT OF LOADING</td>
                    <td style={{ width: "25%" }} className="text-right">
                      {shipmentStore.oimdata.f_LoadingPort}
                    </td>
                    <td>ETD</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_ETD}
                    </td>
                  </tr>
                  <tr>
                    <td>PORT OF DISCHARGE</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_DisCharge}
                    </td>
                    <td>ETA</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_ETA}
                    </td>
                  </tr>
                  <tr>
                    <td>FINAL DELIVERY</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_FinalDelivery}
                    </td>
                    <td>FINAL ETA</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_FETA}
                    </td>
                  </tr>
                  <tr>
                    <td>DELIVERY TYPE</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_MoveType}
                    </td>
                    <td>RECEIPT OF PLACE</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_PaidPlace}
                    </td>
                  </tr>
                  <tr>
                    <td>CY LOCATION</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_CYLocation}
                    </td>
                    <td>CFS LOCATION</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_CFSLocation}
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
      <div className="row mb-2">
        <div className="col-lg-12">
          <div className="card">
            <div className="card-header">RAIL</div>
            <div className="card-body">
              <table className="table">
                <tbody>
                  <tr>
                    <td style={{ width: "16.6%" }}>IT NO</td>
                    <td style={{ width: "16.6%" }} className="text-right">
                      {shipmentStore.oimdata.f_ITNo}
                    </td>
                    <td style={{ width: "16.6%" }}>IT PLACE</td>
                    <td style={{ width: "16.6%" }} className="text-right">
                      {shipmentStore.oimdata.f_ITPlace}
                    </td>
                    <td style={{ width: "16.6%" }}>IT DATE</td>
                    <td style={{ width: "16.6%" }} className="text-right">
                      {shipmentStore.oimdata.f_ITDate}
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
      <div className="row mb-4">
        <div className="col-lg-12">
          <div className="card">
            <div className="card-body">
              <table className="table">
                <tbody>
                  <tr>
                    <td style={{ width: "25%" }}>FCL/LCL</td>
                    <td style={{ width: "25%" }} className="text-right">
                      {shipmentStore.oimdata.f_LCLFCL}
                    </td>
                    <td style={{ width: "25%" }}>FREE/NOMI/CO-LOAD</td>
                    <td style={{ width: "25%" }} className="text-right">
                      {shipmentStore.oimdata.f_Nomi}
                    </td>
                  </tr>
                  <tr>
                    <td>EXPRESS RELEASE</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_ExpRLS}
                    </td>
                    <td>AMS/ISF NO.</td>
                    <td className="text-right">
                      {shipmentStore.oimdata.f_AMSBLNO}
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
      <div className="row mb-4">
        <div className="col-lg-12">
          <div className="card">
            <div className="card-header">CONTAINER</div>
            <div className="card-body">
              <table className="table table-hover">
                <thead>
                  <tr>
                    <th>CONTAINER NO</th>
                    <th>SEAL NO</th>
                    <th>CONTAINER SIZE</th>
                    <th>PACKAGE</th>
                    <th>UNIT</th>
                  </tr>
                </thead>
                <tbody>
                  {shipmentStore.oimdata.vM_CONTAINERS.map((cont: any) => (
                    <tr key={cont.f_ID}>
                      <td>{cont.f_ContainerNo}</td>
                      <td>{cont.f_SealNo}</td>
                      <td>{cont.f_ConType}</td>
                      <td>20</td>
                      <td>CNTS</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
      <div className="row">
        <div className="col-lg-6">
          <div className="card h-100">
            <div className="card-header">MEMO</div>
            <div className="card-body">
              <div>
                <textarea
                  className="form-control"
                  style={{ height: "292px" }}
                ></textarea>
              </div>
            </div>
          </div>
        </div>
        <div className="col-lg-6">
          <div className="card">
            <div className="card-header">ACTIVITY LOG</div>
            <div className="card-body">
              <ActivityLog>
                <ActivityLogEvent
                  title="John Doe sent a SMS"
                  createdAt="2016-09-12 10:06 PM"
                >
                  I received the payment for $543. Should be shipping the item
                  within a couple of hours.
                </ActivityLogEvent>
                <ActivityLogEvent
                  title="John Doe sent a SMS"
                  createdAt="2016-09-12 2:06 PM"
                  icon={<i className="mdi mdi-mail"></i>}
                >
                  Like we talked, you said that you would share the shipment
                  details? This is an urgent order and so I am losing patience.
                  Can you expedite the process and pls do share the details
                  asap. Consider this a gentle reminder if you are on track
                  already!
                </ActivityLogEvent>
              </ActivityLog>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default observer(IntgBoardDetail);
