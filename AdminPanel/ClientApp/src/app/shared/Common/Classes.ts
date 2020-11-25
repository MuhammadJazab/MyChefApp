export class UserVM {
  userId: number;
  email: string;
  password: string;
  userName: string;
  accountTypeId: number;
  cookingSkillId: number;
  profileImage: [];
  isAdmin: boolean;
}

export class MenuVM {
  day: string;
  title: string;
  direction: string;
  inGridient: any = [];
  menuId: number;
  menuRecipeId: number;

}
export class ResponseVm {
  status: any;
  message: string;
  resultData: any;
}

export var httpStatus = {
  Ok: "200",
  Restricted: "403",
  loginError: "invalid email address/phone number or password."
}
