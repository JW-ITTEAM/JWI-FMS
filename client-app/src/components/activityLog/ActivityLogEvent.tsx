import * as React from "react";

export interface IActivityLogEventProps {
  title?: React.ReactNode;
  createdAt?: React.ReactNode;
  icon?: React.ReactNode;
  children?: React.ReactNode;
}

export default function ActivityLogEvent(props: IActivityLogEventProps) {
  return (
    <div>
      <div
        style={{
          position: "relative",
          margin: "10px 0px",
          paddingLeft: "45px",
          textAlign: "left",
        }}
      >
        <div
          style={{
            position: "absolute",
            top: "0px",
            borderRadius: "50%",
            width: "30px",
            height: "30px",
            marginLeft: "1px",
            background: "rgb(233, 240, 245)",
            border: "2px solid black",
            display: "flex",
            color: "black",
            left: "0px",
          }}
        >
          <span
            style={{
              display: "flex",
              width: "32px",
              height: "32px",
              position: "relative",
              justifyContent: "center",
              cursor: "pointer",
              alignSelf: "center",
              alignItems: "center",
            }}
          >
            {props.icon ? (
              props.icon
            ) : (
              <i className="mdi mdi-message-processing"></i>
            )}
          </span>
        </div>
        <div style={{ position: "relative" }}>
          <div
            style={{
              top: "24px",
              left: "100%",
              borderColor:
                "transparent transparent transparent rgb(255,255,255)",
            }}
          ></div>
          <div>
            <div style={{ marginBottom: "3px", color: "rgb(3,84,115)" }}>
              {props.createdAt}
            </div>
            <div>{props.title}</div>
            <div
              style={{ marginTop: "-20px", float: "right", textAlign: "right" }}
            ></div>
          </div>
          <div
            style={{
              width: "98%",
              backgroundColor: "rgb(255,255,255)",
              boxShadow: "rgba(0,0,0,0.1) 0px 1px 3px 0px",
              marginTop: "1em",
              marginBottom: "1em",
              lineHeight: 1.6,
              padding: "0.5em 1em",
              color: "black",
            }}
          >
            {props.children}
            <div style={{ clear: "both", display: "table" }}></div>
          </div>
        </div>
        <div style={{ clear: "both", display: "table" }}></div>
      </div>
    </div>
  );
}
