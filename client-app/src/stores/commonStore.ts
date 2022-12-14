import { makeAutoObservable } from "mobx";
import nProgress from "nprogress";
import { EMAILCONFIRM_URI, LOGIN_URI } from "../config/UriConfig";

export default class CommonStore {
  isLoading = false;
  isFullLayout = false;

  constructor() {
    makeAutoObservable(this);
  }

  setLoading = (value: boolean) => {
    this.isLoading = value;
    if (value === true) {
      nProgress.inc();
    } else {
      // console.log("testst");
      // setTimeout(() => {
      //   nProgress.done();
      // }, 1000);
      nProgress.done();
    }
  };

  setFullLayout = (value: boolean) => {
    this.isFullLayout = value;
  };

  fullPageControl = (pathname: string) => {
    window.scrollTo(0, 0);
    const fullPageLayoutRoutes = [LOGIN_URI, "/register", EMAILCONFIRM_URI];
    for (let i = 0; i < fullPageLayoutRoutes.length; i++) {
      if (pathname === fullPageLayoutRoutes[i]) {
        this.setFullLayout(true);
        document
          .querySelector(".page-body-wrapper")
          ?.classList.add("full-page-wrapper");
        break;
      } else {
        this.setFullLayout(false);
        document
          .querySelector(".page-body-wrapper")
          ?.classList.remove("full-page-wrapper");
      }
    }
  };

  setFullPageForce = (value: boolean) => {
    if (value === true) {
      this.setFullLayout(true);
      document
        .querySelector(".page-body-wrapper")
        ?.classList.add("full-page-wrapper");
    } else {
      this.setFullLayout(false);
      document
        .querySelector(".page-body-wrapper")
        ?.classList.remove("full-page-wrapper");
    }
  };
}
