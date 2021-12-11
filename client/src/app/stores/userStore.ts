import {User, UserFormValues} from "../models/user";
import {makeAutoObservable, runInAction} from "mobx";
import agent from "../api/agent";
import {store} from "./store";
import {history} from "../../index";

export default class UserStore {
    user: User | null = null;
    
    constructor() {
        makeAutoObservable(this);
    }
    
    get isLoggedIn() {
        // double !! casts to boolean
        return !!this.user;
    }
    
    login = async (creds: UserFormValues) => {
        try {
            const user = await agent.Account.login(creds);
            // sets our user token
            store.commonStore.setToken(user.token);
            // if we want to modify an observable, we have to runInAction
            // sets our user
            runInAction(() => this.user = user);
            history.push('/catalog');
            store.modalStore.closeModal();
        } catch (error) {
            throw error;
        }
    }
    
    logout = () => {
        // reset the token to null
        store.commonStore.setToken(null);
        // remove token from local storage
        window.localStorage.removeItem('jwt');
        this.user = null;
        history.push('/');
    }
    
    // get the user that matches the token
    getUser = async () => {
        try {
            const user = await agent.Account.currentUser();
            runInAction(() => this.user = user);
        } catch (error) {
            console.log(error);
        }
    }
    
    register = async (creds: UserFormValues) => {
        try {
            const user = await agent.Account.register(creds);
            store.commonStore.setToken(user.token);
            runInAction(() => this.user = user);
            history.push('/catalog');
            store.modalStore.closeModal();
        } catch (error) {
            throw error;
        }
    }
}