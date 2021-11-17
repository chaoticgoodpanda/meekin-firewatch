import {makeAutoObservable} from "mobx";

export default class ReportStore {
    title = 'Hello from MobX!';
    
    constructor() {
        // mobx works out on its own that title is a property and therefore observable
        // setTitle is a function and therefore observable
        makeAutoObservable(this)
    }
    
    // this function is bound to the class
    setTitle = () => {
        this.title = this.title + '!';
    }
}