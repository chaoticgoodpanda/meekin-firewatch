import {createStore} from "redux";
import {devToolsEnhancer} from "redux-devtools-extension";
import testReducer from "../../features/sandbox/testReducer";

export function configureStore() {
    // @ts-ignore
    return createStore(testReducer, devToolsEnhancer());
}