import { makeAutoObservable } from "mobx";
import nProgress from "nprogress";
import axiosConn from "../utils/ApiConnection";

export default class ShipmentStore {
  isLoading = false;
  oims = [];
  oimdata: any | undefined = undefined;

  constructor() {
    makeAutoObservable(this);
  }

  loadOceanImportList = async () => {
    this.setLoading(true);
    try {
      const oims = await axiosConn.OceanImports.list();
      this.setOims(oims);
      this.setLoading(false);
    } catch (error) {
      this.setLoading(false);
    }
  };

  loadOceanImportDetail = async (rmh_id: string) => {
    this.setLoading(true);
    const oim = await axiosConn.OceanImports.detail(rmh_id);
    this.setDetail(oim);
    this.setLoading(false);
    try {
    } catch (error) {
      this.setLoading(false);
    }
  };

  setLoading = (value: boolean) => {
    this.isLoading = value;
    if (value === true) {
      nProgress.inc();
    } else {
      nProgress.done();
    }
  };

  setOims = (oims: []) => {
    this.oims = oims;
  };

  setDetail = (oim: any) => {
    this.oimdata = oim;
  };
}
