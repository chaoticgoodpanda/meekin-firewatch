import {ServerError} from "../models/serverError";
import {makeAutoObservable} from "mobx";

export default class CommonStore {
    error: ServerError | null = null;
    token: string | null = null;
    appLoaded = false;
    
    // makes our error an observable (above)
    constructor() {
        makeAutoObservable(this);
    }
    
    setServerError = (error: ServerError) => {
        this.error = error;
    }
    
    setToken = (token: string | null) => {
        // if there is a token, store in browser's local storage
        if (token) window.localStorage.setItem('jwt', token);
        this.token = token;
    }
    
    setAppLoaded = () => {
        this.appLoaded = true;
    }
}