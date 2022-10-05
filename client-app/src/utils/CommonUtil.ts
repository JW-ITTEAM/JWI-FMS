export const stringIsNullOrEmpty = (value: string) => {
  if (typeof value === "string" && value.trim().length === 0) {
    return true;
  } else {
    return false;
  }
};

export const validationEmail = (email: string) => {
  if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(email)) {
    return false;
  } else {
    return true;
  }
};

export const getToken = (localStorage: any) => {
  let token = localStorage.getItem("Token");
  return token;
};

export const logChk = (localStorage: any) => {
  return !!getToken(localStorage);
};

export const userDbSave = (localStorage: any) => {
  let userDbSave = localStorage.getItem("UserDbSave");
  return userDbSave;
};

export const userDbSaveChk = (localStorage: any) => {
  return !!userDbSave(localStorage);
};
