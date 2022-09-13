import React, { Component } from "react";
import { Link, RouteComponentProps, withRouter } from "react-router-dom";
import { Collapse, Dropdown } from "react-bootstrap";
import { mdiChevronDown, mdiCog } from "@mdi/js";
import Icon from "@mdi/react";

class Sidebar extends Component<RouteComponentProps> {
  state: any = {};

  toggleMenuState(menuState: string) {
    if (this.state[menuState]) {
      this.setState({
        [menuState]: false,
      });
    } else if (Object.keys(this.state).length === 0) {
      this.setState({ [menuState]: true });
    } else {
      Object.keys(this.state).forEach((i) => {
        this.setState({ [i]: false });
      });
      this.setState({ [menuState]: true });
    }
  }

  render() {
    return (
      <nav className="sidebar sidebar-offcanvas" id="sidebar">
        {/* Main Logo in Sidebar */}
        <div className="sidebar-brand-wrapper d-none d-lg-flex align-items-center justify-content-center fixed-top">
          <a className="sidebar-brand brand-logo" href="index.html">
            <img
              src={require("./../../assets/images/logo_image/logo-90degree.png")}
              alt="logo"
            />
          </a>
          <a className="sidebar-brand brand-logo-mini" href="index.html">
            <img
              src={require("./../../assets/images/logo_image/J_Logo.png")}
              alt="logo"
            />
          </a>
        </div>
        {/* Main Logo in Sidebar */}

        <ul className="nav">
          {/* Profile */}
          <li className="nav-item profile">
            <div className="profile-desc">
              <div className="profile-pic">
                <div className="count-indicator">
                  <img
                    className="img-xs rounded-circle"
                    src={require("../../assets/images/faces/face15.jpg")}
                    alt="profile"
                  />
                  <span className="count bg-success"></span>
                </div>
                <div className="profile-name">
                  <h5 className="mb-0 font-weight-normal">Henry Klein</h5>
                  <span>Gold Member</span>
                </div>
              </div>
              <Dropdown alignRight>
                <Dropdown.Toggle as="a" className="cursor-pointer no-caret">
                  <i className="mdi mdi-dots-vertical"></i>
                </Dropdown.Toggle>
                <Dropdown.Menu className="sidebar-dropdown preview-list">
                  <a
                    href="!#"
                    className="dropdown-item preview-item"
                    onClick={(evt) => evt.preventDefault()}
                  >
                    <div className="preview-thumbnail">
                      <div className="preview-icon bg-dark rounded-circle">
                        <Icon
                          path={mdiCog}
                          size={0.7}
                          className="mdi mdi-settings text-primary"
                        ></Icon>
                      </div>
                    </div>
                    <div className="preview-item-content">
                      <p className="preview-subject ellipsis mb-1 text-small">
                        Account settings
                      </p>
                    </div>
                  </a>
                  <div className="dropdown-divider"></div>
                  <a
                    href="!#"
                    className="dropdown-item preview-item"
                    onClick={(evt) => evt.preventDefault()}
                  >
                    <div className="preview-thumbnail">
                      <div className="preview-icon bg-dark rounded-circle">
                        <i className="mdi mdi-onepassword text-info"></i>
                      </div>
                    </div>
                    <div className="preview-item-content">
                      <p className="preview-subject ellipsis mb-1 text-small">
                        Change Password
                      </p>
                    </div>
                  </a>
                  <div className="dropdown-divider"></div>
                  <a
                    href="!#"
                    className="dropdown-item preview-item"
                    onClick={(evt) => evt.preventDefault()}
                  >
                    <div className="preview-thumbnail">
                      <div className="preview-icon bg-dark rounded-circle">
                        <i className="mdi mdi-calendar-today text-success"></i>
                      </div>
                    </div>
                    <div className="preview-item-content">
                      <p className="preview-subject ellipsis mb-1 text-small">
                        To-do list
                      </p>
                    </div>
                  </a>
                </Dropdown.Menu>
              </Dropdown>
            </div>
          </li>
          {/* Profile */}

          {/* Navigation Menu */}
          <li className="nav-item nav-category">
            <span className="nav-link">Navigation</span>
          </li>

          {/* Dashboard */}
          <li
            className={
              this.isPathActive("/dashboard")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <Link className="nav-link" to="/dashboard">
              <span className="menu-icon">
                <i className="mdi mdi-speedometer"></i>
              </span>
              <span className="menu-title">Dashboard</span>
            </Link>
          </li>
          {/* Dashboard */}

          {/* Shipment */}
          <li
            className={
              this.isPathActive("/shipments/intg_board/")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <Link className="nav-link" to="/shipments/intg_board/">
              <span className="menu-icon">
                <i className="mdi mdi-ferry"></i>
              </span>
              <span className="menu-title">Shipments</span>
            </Link>
          </li>
          {/* Shipment */}

          {/* Ocean Import */}
          {/* <li
            className={
              this.isPathActive("/shipments")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <div
              className={
                this.state.basicUiMenuOpen
                  ? "nav-link menu-expanded"
                  : "nav-link"
              }
              onClick={() => this.toggleMenuState("basicUiMenuOpen")}
              data-toggle="collapse"
            >
              <span className="menu-icon">
                <i className="mdi mdi-ferry"></i>
              </span>
              <span className="menu-title">Shipments</span>
              <Icon
                path={mdiChevronDown}
                title="menu-arrow"
                size={0.7}
                className="menu-arrow"
              ></Icon>
            </div>
            <Collapse in={this.state.basicUiMenuOpen}>
              <div>
                <ul className="nav flex-column sub-menu">
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/shipments/oim")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/shipments/oim"
                    >
                      Ocean Import
                    </Link>
                  </li>
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/shipments/oex")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/shipments/oex"
                    >
                      Ocean Export
                    </Link>
                  </li>
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/shipments/aim")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/shipments/aim"
                    >
                      Air Import
                    </Link>
                  </li>
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/shipments/aex")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/shipments/aex"
                    >
                      Air Export
                    </Link>
                  </li>
                </ul>
              </div>
            </Collapse>
          </li> */}
          {/* Shipments */}

          {/* Billing & Invoice */}
          <li
            className={
              this.isPathActive("/invoice")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <Link className="nav-link" to="/invoice">
              <span className="menu-icon">
                <i className="mdi mdi-receipt-text"></i>
              </span>
              <span className="menu-title">Billing & Invoice</span>
            </Link>
          </li>
          {/* Billing & Invoice */}

          {/* Arrival */}
          <li
            className={
              this.isPathActive("/arrival")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <Link className="nav-link" to="/arrival">
              <span className="menu-icon">
                <i className="mdi mdi-calendar-multiple-check"></i>
              </span>
              <span className="menu-title">Arrival</span>
            </Link>
          </li>
          {/* Arrival */}

          {/* Trucking */}
          <li
            className={
              this.isPathActive("/trucking")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <Link className="nav-link" to="/trucking">
              <span className="menu-icon">
                <i className="mdi mdi-truck"></i>
              </span>
              <span className="menu-title">Trucking</span>
            </Link>
          </li>
          {/* Trucking */}

          {/* Admin */}
          <li
            className={
              this.isPathActive("/admin")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <Link className="nav-link" to="/admin">
              <span className="menu-icon">
                <i className="mdi mdi-cog"></i>
              </span>
              <span className="menu-title">Admin</span>
            </Link>
          </li>
          {/* Admin */}

          {/* Basic Ui Element */}
          {/* <li
            className={
              this.isPathActive("/basic-ui")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <div
              className={
                this.state.basicUiMenuOpen
                  ? "nav-link menu-expanded"
                  : "nav-link"
              }
              onClick={() => this.toggleMenuState("basicUiMenuOpen")}
              data-toggle="collapse"
            >
              <span className="menu-icon">
                <i className="mdi mdi-laptop"></i>
              </span>
              <span className="menu-title">Basic UI Elements</span>
              <Icon
                path={mdiChevronDown}
                title="menu-arrow"
                size={0.7}
                className="menu-arrow"
              ></Icon>
            </div>
            <Collapse in={this.state.basicUiMenuOpen}>
              <div>
                <ul className="nav flex-column sub-menu">
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/basic-ui/buttons")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/basic-ui/buttons"
                    >
                      Buttons
                    </Link>
                  </li>
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/basic-ui/dropdowns")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/basic-ui/dropdowns"
                    >
                      Dropdowns
                    </Link>
                  </li>
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/basic-ui/typography")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/basic-ui/typography"
                    >
                      Typography
                    </Link>
                  </li>
                </ul>
              </div>
            </Collapse>
          </li> */}
          {/* Basic Ui Element */}

          {/* Form Elements */}
          {/* <li
            className={
              this.isPathActive("/form-elements")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <div
              className={
                this.state.formElementsMenuOpen
                  ? "nav-link menu-expanded"
                  : "nav-link"
              }
              onClick={() => this.toggleMenuState("formElementsMenuOpen")}
              data-toggle="collapse"
            >
              <span className="menu-icon">
                <i className="mdi mdi-playlist-play"></i>
              </span>
              <span className="menu-title">Form Elements</span>
              <Icon
                path={mdiChevronDown}
                title="menu-arrow"
                size={0.7}
                className="menu-arrow"
              ></Icon>
            </div>
            <Collapse in={this.state.formElementsMenuOpen}>
              <div>
                <ul className="nav flex-column sub-menu">
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/form-elements/basic-elements")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/form-elements/basic-elements"
                    >
                      Basic Elements
                    </Link>
                  </li>
                </ul>
              </div>
            </Collapse>
          </li> */}
          {/* Form Elements */}

          {/* Tables */}
          {/* <li
            className={
              this.isPathActive("/tables")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <div
              className={
                this.state.tablesMenuOpen
                  ? "nav-link menu-expanded"
                  : "nav-link"
              }
              onClick={() => this.toggleMenuState("tablesMenuOpen")}
              data-toggle="collapse"
            >
              <span className="menu-icon">
                <i className="mdi mdi-table-large"></i>
              </span>
              <span className="menu-title">Tables</span>
              <Icon
                path={mdiChevronDown}
                title="menu-arrow"
                size={0.7}
                className="menu-arrow"
              ></Icon>
            </div>
            <Collapse in={this.state.tablesMenuOpen}>
              <div>
                <ul className="nav flex-column sub-menu">
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/tables/basic-table")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/tables/basic-table"
                    >
                      Basic Table
                    </Link>
                  </li>
                </ul>
              </div>
            </Collapse>
          </li> */}
          {/* Tables */}

          {/* Charts */}
          {/* <li
            className={
              this.isPathActive("/charts")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <div
              className={
                this.state.chartsMenuOpen
                  ? "nav-link menu-expanded"
                  : "nav-link"
              }
              onClick={() => this.toggleMenuState("chartsMenuOpen")}
              data-toggle="collapse"
            >
              <span className="menu-icon">
                <i className="mdi mdi-chart-bar"></i>
              </span>
              <span className="menu-title">Charts</span>
              <Icon
                path={mdiChevronDown}
                title="menu-arrow"
                size={0.7}
                className="menu-arrow"
              ></Icon>
            </div>
            <Collapse in={this.state.chartsMenuOpen}>
              <div>
                <ul className="nav flex-column sub-menu">
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/charts/chart-js")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/charts/chart-js"
                    >
                      Chart Js
                    </Link>
                  </li>
                </ul>
              </div>
            </Collapse>
          </li> */}
          {/* Charts */}

          {/* Icons */}
          {/* <li
            className={
              this.isPathActive("/icons")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <div
              className={
                this.state.iconsMenuOpen ? "nav-link menu-expanded" : "nav-link"
              }
              onClick={() => this.toggleMenuState("iconsMenuOpen")}
              data-toggle="collapse"
            >
              <span className="menu-icon">
                <i className="mdi mdi-contacts"></i>
              </span>
              <span className="menu-title">Icons</span>
              <Icon
                path={mdiChevronDown}
                title="menu-arrow"
                size={0.7}
                className="menu-arrow"
              ></Icon>
            </div>
            <Collapse in={this.state.iconsMenuOpen}>
              <div>
                <ul className="nav flex-column sub-menu">
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/icons/mdi")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/icons/mdi"
                    >
                      Material
                    </Link>
                  </li>
                </ul>
              </div>
            </Collapse>
          </li> */}
          {/* Icons */}

          {/* User Pages */}
          {/* <li
            className={
              this.isPathActive("/user-pages")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <div
              className={
                this.state.userPagesMenuOpen
                  ? "nav-link menu-expanded"
                  : "nav-link"
              }
              onClick={() => this.toggleMenuState("userPagesMenuOpen")}
              data-toggle="collapse"
            >
              <span className="menu-icon">
                <i className="mdi mdi-security"></i>
              </span>
              <span className="menu-title">User Pages</span>
              <Icon
                path={mdiChevronDown}
                title="menu-arrow"
                size={0.7}
                className="menu-arrow"
              ></Icon>
            </div>
            <Collapse in={this.state.userPagesMenuOpen}>
              <div>
                <ul className="nav flex-column sub-menu">
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/user-pages/login-1")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/user-pages/login-1"
                    >
                      Login
                    </Link>
                  </li>
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/user-pages/register-1")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/user-pages/register-1"
                    >
                      Register
                    </Link>
                  </li>
                </ul>
              </div>
            </Collapse>
          </li> */}
          {/* User Pages */}
          {/* Navigation Menu */}

          {/* More Menu */}
          {/* <li className="nav-item nav-category">
            <span className="nav-link">More</span>
          </li> */}

          {/* Error Pages */}
          {/* <li
            className={
              this.isPathActive("/error-pages")
                ? "nav-item menu-items active"
                : "nav-item menu-items"
            }
          >
            <div
              className={
                this.state.errorPagesMenuOpen
                  ? "nav-link menu-expanded"
                  : "nav-link"
              }
              onClick={() => this.toggleMenuState("errorPagesMenuOpen")}
              data-toggle="collapse"
            >
              <span className="menu-icon">
                <i className="mdi mdi-lock"></i>
              </span>
              <span className="menu-title">Error Pages</span>
              <Icon
                path={mdiChevronDown}
                title="menu-arrow"
                size={0.7}
                className="menu-arrow"
              ></Icon>
            </div>
            <Collapse in={this.state.errorPagesMenuOpen}>
              <div>
                <ul className="nav flex-column sub-menu">
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/error-pages/error-404")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/error-pages/error-404"
                    >
                      404
                    </Link>
                  </li>
                  <li className="nav-item">
                    <Link
                      className={
                        this.isPathActive("/error-pages/error-500")
                          ? "nav-link active"
                          : "nav-link"
                      }
                      to="/error-pages/error-500"
                    >
                      500
                    </Link>
                  </li>
                </ul>
              </div>
            </Collapse>
          </li> */}
          {/* Error Pages */}

          {/* Documentation */}
          {/* <li className="nav-item menu-items">
            <a
              className="nav-link"
              href="http://bootstrapdash.com/demo/corona-react-free/documentation/documentation.html"
              rel="noopener noreferrer"
              target="_blank"
            >
              <span className="menu-icon">
                <i className="mdi mdi-text-box"></i>
              </span>
              <span className="menu-title">Documentation</span>
            </a>
          </li> */}
          {/* Documentation */}
          {/* More Menu */}
        </ul>
      </nav>
    );
  }

  // navagation class control - active
  isPathActive(path: string) {
    return this.props.location.pathname.startsWith(path);
  }
}

export default withRouter(Sidebar);
