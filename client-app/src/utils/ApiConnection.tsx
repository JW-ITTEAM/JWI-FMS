import axios, { AxiosResponse } from "axios";
import {
  FMS_API_URL,
  API_URL_OCEAN_IMPORT_LIST,
  API_URL_OCEAN_IMPORT_DETAIL,
} from "../config/SystemConfig";
import { MsgManager } from "./MsgManager";

const axiosSet = axios.create({
  baseURL: FMS_API_URL,
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json; charset=utf-8",
  },
});
axiosSet.defaults.timeout = 3000;

axiosSet.interceptors.request.use(
  function (config) {
    return config;
  },
  function (error) {
    MsgManager({
      icon: "error",
      title: error.code,
      text: error.message,
    });
    return Promise.reject(error);
  }
);

axiosSet.interceptors.response.use(
  function (response) {
    return response;
  },
  function (error) {
    MsgManager({
      icon: "error",
      title: error.code,
      text: error.message,
    });
    return Promise.reject(error);
  }
);

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
  get: (url: string) => axiosSet.get(url).then(responseBody),
  post: (url: string, body: {}) => axiosSet.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axiosSet.put(url, body).then(responseBody),
  del: (url: string) => axiosSet.delete(url).then(responseBody),
};

const OceanImports = {
  list: () => requests.get(API_URL_OCEAN_IMPORT_LIST),
  detail: (rmh_id: string) =>
    requests.get(API_URL_OCEAN_IMPORT_DETAIL + encodeURIComponent(rmh_id)),
};

const axiosConn = {
  OceanImports,
};

export default axiosConn;
