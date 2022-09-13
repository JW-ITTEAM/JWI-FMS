import * as React from "react";
import { Oval } from "react-loader-spinner";

export interface ILoadSpinnerProps {
  isLoading: boolean;
}

export function LoadSpinner(props: ILoadSpinnerProps) {
  return (
    <div>
      {props.isLoading ? (
        <div style={loader_css}>
          <Oval
            height={50}
            width={50}
            color="#4fa94d"
            wrapperStyle={{}}
            wrapperClass=""
            visible={true}
            ariaLabel="oval-loading"
            secondaryColor="#4fa94d"
            strokeWidth={4}
            strokeWidthSecondary={2}
          />
        </div>
      ) : (
        <></>
      )}
    </div>
  );
}

const loader_css: React.CSSProperties = {
  position: "fixed",
  width: "100%",
  height: "100%",
  top: 0,
  left: 0,
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  zIndex: 1031,
  background: "rgba(255,255,255,0.7)",
  animation: "bg 1s",
};
