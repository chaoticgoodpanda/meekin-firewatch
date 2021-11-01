import axios, {AxiosError, AxiosResponse} from "axios";
import {history} from "../..";
import {toast} from "react-toastify";

// base URL for all of our requests
axios.defaults.baseURL = 'https://localhost:5001/api/';

// make it easier to extract the response
const responseBody = (response: AxiosResponse) => response.data;
// TODO: figure out if it's possible to use this different method for {id} calls
// const responseDetailBody = (response: AxiosResponse) => response.data.result.posts;

// intercepts the response from the API before it hits the client
axios.interceptors.response.use(response => {
    // if response successful (200 range status code), return the response as is -- as fulfilled
    return response
}, 
    // this is when the request has been rejected, axios intercepts it
    (error: AxiosError) => {
        const {data, status} = error.response!;
        switch (status) {
            case 400:
                if (data.errors) {
                    const modelStateErrors: string[] = [];
                    for (const key in data.errors) {
                        // each error in errors object has a key
                        if (data.errors[key]) {
                            // when you find a key, push it to the modelStateErrors array
                            modelStateErrors.push(data.errors[key])
                        }
                    }
                    // flatten the array so only get back the strings in array
                    // throw stops continued execution of the switch method
                    throw modelStateErrors.flat();
                }
                toast.error(data.title);
                break;
            case 401:
                toast.error(data.title);
                break;
            case 404:
                toast.error(data.title);
                break;
            case 500:
                history.push({
                    pathname: '/server-error',
                    state: {error: data},
                    
                });
                break;
            default:
                toast.error(data.title);
                break;
        }
        return Promise.reject(error.response);
    })

// variable for different kind of requests we'll use axios for
// centralizes requests
const requests = {
    //pulls response.data straight from the get call
    //consider changing to array form
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url).then(responseBody),
    put: (url: string, body: {}) => axios.put(url).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody),
}

// requests specifically for the catalog
const Catalog = {
    list: () => requests.get('posts'),
    details: (id: string) => requests.get(`posts/${id}`)
}

// testing errors on API
const TestErrors = {
    get400Error: () => requests.get('buggy/bad-request'),
    get401Error: () => requests.get('buggy/unauthorized'),
    get404Error: () => requests.get('buggy/not-found'),
    get500Error: () => requests.get('buggy/server-error'),
    getValidationError: () => requests.get('buggy/validation-error'),
}

const agent = {
    Catalog,
    TestErrors
}

export default agent;