import { makeAutoObservable } from "mobx";
import { objectPrototype } from "mobx/dist/internal";
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
}
