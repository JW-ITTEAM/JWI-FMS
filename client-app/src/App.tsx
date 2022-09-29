import { useLocation, withRouter } from "react-router-dom";
import "./App.scss";
import { AppRoutes } from "./AppRoutes";
import Footer from "./pages/shared/Footer";
import Navbar from "./pages/shared/Navbar";
import Sidebar from "./pages/shared/Sidebar";
import "./assets/styles/css/nprogress.css";
import { LoadSpinner } from "./components/loadSpinner/LoadSpinner";
import { useStore } from "./stores/store";
import { useEffect } from "react";

function App() {
  const { commonStore, loginStore } = useStore();
  const location: any = useLocation();
  commonStore.fullPageControl(location.pathname);

  useEffect(() => {
    loginStore.loadAuthState();
    // let timer1 = setTimeout(() => commonStore.setLoading(true), 5000);
    // return () => {
    //   clearTimeout(timer1);
    //   commonStore.setLoading(false);
    // };
  }, []);

  let navbarComponent = !commonStore.isFullLayout ? (
    <Navbar userInfo={loginStore.currentUserProps} />
  ) : (
    ""
  );
  let sidebarComponent = !commonStore.isFullLayout ? (
    <Sidebar userInfo={loginStore.currentUserProps} />
  ) : (
    ""
  );
  let footerComponent = !commonStore.isFullLayout ? <Footer /> : "";

  return (
    <div>
      <LoadSpinner isLoading={commonStore.isLoading} />
      <div className="container-scroller">
        {sidebarComponent}
        <div className="container-fluid page-body-wrapper">
          {navbarComponent}
          <div className="main-panel">
            <div className="content-wrapper">
              <AppRoutes />
            </div>
            {footerComponent}
          </div>
        </div>
      </div>
    </div>
  );
}

export default withRouter(App);
