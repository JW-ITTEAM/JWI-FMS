import { StaticContext } from "react-router";
import { RouteComponentProps } from "react-router-dom";
import { MsgManager } from "../../utils/MsgManager";

export interface IAuthRouteProps {
  path: string;
  authenticated: boolean;
  component?:
    | React.ComponentType<any>
    | React.ComponentType<RouteComponentProps<any, StaticContext, unknown>>
    | undefined;
}

export default function AuthRoute(props: IAuthRouteProps) {
  if (!props.authenticated) {
    MsgManager({
      icon: "error",
      title: "Access Error",
      text: "You do not have an authority to accesss this page.",
    });
    // window.open(LOGIN_URI, "_self");
    return <></>;
  } else {
    return <></>;
  }
}
