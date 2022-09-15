import { makeAutoObservable } from "mobx";
import { objectPrototype } from "mobx/dist/internal";
import { CurrentUserProps } from "../models/CurrentUserProps";
import { UserLoginProps } from "../models/UserLoginProps";
import { UserRegisterProps } from "../models/UserRegisterProps";

export default class LoginStore {
  userLoginProps: UserLoginProps = {
    email: "",
    password: "",
  };

  userRegisterProps: UserRegisterProps = {
    email: "",
    username: "",
    password: "",
    passwordconfirm: "",
    chkagree: false,
  };

  currentUserProps: CurrentUserProps = {
    f_UserName: "",
    f_UserEmail: "",
    f_Phone: "",
    f_Fax: "",
    f_EmailVerified: false,
  };

  constructor() {
    makeAutoObservable(this);
  }

  onChangeProps = (event: any, target: string) => {
    type typeOfObjKey = keyof typeof objectPrototype;
    let attType = event.target.attributes.type.nodeValue;
    let name: typeOfObjKey = event.target.name;
    let targetLower = target.toLowerCase();
    let value = event.target.value;
    if (attType === "checkbox") {
      value = event.target.checked;
    }

    if (targetLower === "login") {
      this.userLoginProps[name] = value;
    } else if (targetLower === "register") {
      this.userRegisterProps[name] = value;
    }
  };

  setCurrentUserProps = async (props: CurrentUserProps) => {
    this.currentUserProps.f_UserEmail = props.f_UserEmail;
    this.currentUserProps.f_UserName = props.f_UserName;
    this.currentUserProps.f_Phone = props.f_Phone;
    this.currentUserProps.f_Fax = props.f_Fax;
    this.currentUserProps.f_EmailVerified = props.f_EmailVerified;
  };
}
