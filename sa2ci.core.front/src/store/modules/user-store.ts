import { VuexModule, Module } from "vuex-class-modules";
import store from "@/store";
import { userService } from "@/services/generated/UserService";
import { LoginResultDto } from '@/models/generated/LoginResultDto';

@Module({ generateMutationSetters: true })
export class UserStore extends VuexModule {
    loginResult: LoginResultDto = {} as LoginResultDto;
    userName = '';
    private _accessToken = '';
    isAuthenticated = false;

    async login(email: string, password: string) {
        this.loginResult = (await userService.login({ Email: email, Password: password })).data;

        this._accessToken = this.loginResult.AccessToken;
        this.userName = this.loginResult.UserName;
        this.isAuthenticated = true;
    }

    getAccessToken():string {
        alert(this._accessToken);
        return this._accessToken;
    }
    // @Action
    // async onUserLoggedIn()
    // isAuthorized = false;

    // private _accessToken = '';
    // user: UserDto = {} as UserDto;

    // getAccessToken(){
}
export const userStore = new UserStore({ store, name: "userStore" });
