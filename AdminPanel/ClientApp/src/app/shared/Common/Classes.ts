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

export class Common {
  public NavigateToRoute(routeName: string, params?) {
    if (params == undefined || params == null)
      this.router.navigate([routeName]);
    else
      this.router.navigate([routeName, params]);
  }
}