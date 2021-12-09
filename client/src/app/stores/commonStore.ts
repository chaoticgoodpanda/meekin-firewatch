import {ServerError} from "../models/serverError";
import {makeAutoObservable, reaction} from "mobx";

export default class CommonStore {
    error: ServerError | null = null;
    // as soon as our store loads, we attempt to get token from local storage
    token: string | null = window.localStorage.getItem('jwt');
    appLoaded = false;
    
    // makes our error an observable (above)
    constructor() {
        makeAutoObservable(this);
        
        // reaction only runs when there is a change to token
        // first runs, token is null
        // otherwise, string of the token
        // reaction is only called after token initially changes
        // different from autoRun, which runs every single time, and don't need to set token every time if it's already been set
        reaction(
            () => this.token,
            token => {
                if (token) {
                    window.localStorage.setItem('jwt', token)
                } else {
                    window.localStorage.removeItem('jwt')
                }
            }
        )
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