export interface IActivityLogProps {
  children?: JSX.Element | JSX.Element[];
}

export function ActivityLog(props: IActivityLogProps) {
  return (
    <div>
      <section
        style={{
          position: "relative",
          fontSize: "80%",
          fontWeight: 300,
          padding: "10px 0px",
          width: "95%",
          margin: "0px auto",
        }}
      >
        <div
          className="iconline"
          style={{
            position: "absolute",
            top: "0px",
            height: "100%",
            width: "2px",
            background: "rgb(160, 178, 184)",
            left: "16px",
          }}
        ></div>
        {props.children}
        <div style={{ clear: "both", display: "table" }}></div>
      </section>
    </div>
  );
}
