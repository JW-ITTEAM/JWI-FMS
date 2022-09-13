import { useLocation, withRouter } from "react-router-dom";
import "./App.scss";
import AppRoutes from "./AppRoutes";
import Footer from "./pages/shared/Footer";
import Navbar from "./pages/shared/Navbar";
import Sidebar from "./pages/shared/Sidebar";
import "./assets/styles/css/nprogress.css";
import { LoadSpinner } from "./components/loadSpinner/LoadSpinner";
import { useStore } from "./stores/store";

function App() {
  const { commonStore } = useStore();
  const location: any = useLocation();
  commonStore.fullPageControl(location.pathname);

  let navbarComponent = !commonStore.isFullLayout ? <Navbar /> : "";
  let sidebarComponent = !commonStore.isFullLayout ? <Sidebar /> : "";
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
