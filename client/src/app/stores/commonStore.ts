import {ServerError} from "../models/serverError";
import {makeAutoObservable} from "mobx";

export default class CommonStore {
    error: ServerError | null = null;
    
    // makes our error an observable (above)
    constructor() {
        makeAutoObservable(this);
    }
    
    setServerError = (error: ServerError) => {
        this.error = error;
    }
}