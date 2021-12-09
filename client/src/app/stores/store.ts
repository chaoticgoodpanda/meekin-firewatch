import ReportStore from "./reportStore";
import {createContext, useContext} from "react";
import CommonStore from "./commonStore";
import UserStore from "./userStore";
import ModalStore from "./modals/modalStore";


interface Store {
    // classes can also be used as types
    reportStore: ReportStore;
    commonStore: CommonStore;
    userStore: UserStore;
    modalStore: ModalStore;
}

export const store: Store = {
    reportStore: new ReportStore(),
    commonStore: new CommonStore(),
    userStore: new UserStore(),
    modalStore: new ModalStore()
}

// as we create new stores, we are adding instances of new stores to this context, and 
// they will be available in our React Context
export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}