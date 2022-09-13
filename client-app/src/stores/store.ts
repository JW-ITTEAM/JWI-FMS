import { createContext, useContext } from "react";
import CommonStore from "./commonStore";
import LoginStore from "./loginStore";
import ShipmentStore from "./shipmentStore";

interface Store {
  commonStore: CommonStore;
  shipmentStore: ShipmentStore;
  loginStore: LoginStore;
}

export const store: Store = {
  commonStore: new CommonStore(),
  shipmentStore: new ShipmentStore(),
  loginStore: new LoginStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
