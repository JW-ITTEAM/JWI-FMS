import Swal from "sweetalert2";

export interface MsgManagerProps {
  icon?: string;
  title?: string;
  text?: string;
  error?: any;
  defaultConfirm?: string;
}

export function MsgManager(props: MsgManagerProps | any = null) {
  let swalProps: any;

  swalProps = {
    icon: props.icon,
    title: props.title,
    text: props.text,
  };

  if (props.error) {
    swalProps = {
      icon: "error",
      title: props.error.code,
      text: props.error.message,
    };
  }

  if (props.defaultConfirm) {
    swalProps = {
      icon: "warning",
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      showCancelButton: true,
    };
  }

  return Swal.fire(swalProps);
}
