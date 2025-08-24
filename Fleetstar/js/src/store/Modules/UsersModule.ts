import { Action, Mutation, getModule, Module, VuexModule } from "vuex-module-decorators";
import store from "..";
import UserService from "@/services/UserService";

@Module({
    store,
    dynamic: true,
    name: "UsersModule",
    namespaced: true,
})
class UsersClass extends VuexModule {
    private userService = new UserService();

    private Users: User[] = null;

    get USERS(): User[] {
        return this.Users;
    }
    
    @Action({ commit: "SET_USERS"})
    public async GET_USERS() {
        return await this.userService.getAll();
    }

    @Mutation
    private SET_USERS(payload: User[]) {
        this.Users = payload;
    }
}

export const UsersModule = getModule(UsersClass);