import axios, {AxiosError, AxiosResponse} from "axios";
import {history} from "../..";
import {toast} from "react-toastify";
import {Post} from "../models/post";
import {PostLabeling} from "../models/postLabeling";
import {Medium} from "../models/medium";
import {store} from "../stores/store";
import {values} from "mobx";
import {User, UserFormValues} from "../models/user";

// base URL for all of our requests
axios.defaults.baseURL = 'https://localhost:5001/api/';

// axios interceptor for *requests* (I've written response axios interceptor below this block
axios.interceptors.request.use(config => {
    const token = store.commonStore.token;
    if (token) config.headers!.Authorization = `Bearer ${token}`
    return config;
})

// make it easier to extract the response
const responseBody = <T> (response: AxiosResponse<T>) => response.data;
// const responseDetailBody = (response: AxiosResponse) => response.data.result.posts;

// intercepts the response from the API before it hits the client
axios.interceptors.response.use(response => {
    // if response successful (200 range status code), return the response as is -- as fulfilled
    return response
}, 
    // this is when the request has been rejected, axios intercepts it
    (error: AxiosError) => {
        const {data, status, config} = error.response!;
        switch (status) {
            case 400:
                if (typeof data === 'string') {
                    toast.error(data);
                }
                if (config.method === 'get' && data.errors.hasOwnProperty('id')) {
                    history.push('/not-found');
                }
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
                } else {
                    toast.error(data.title);
                }
                break;
            case 401:
                toast.error(data.title);
                break;
            case 404:
                // history.push('/not-found');
                toast.error(data.title);
                break;
            case 500:
                store.commonStore.setServerError(data);
                history.push({
                    pathname: '/server-error',
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
    get: <T> (url: string, params?: URLSearchParams) => axios.get<T>(url, {params}).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T> (url: string) => axios.delete<T>(url).then(responseBody),
}

// requests specifically for the catalog
const Catalog = {
    list: () => requests.get<Post[]>('posts'),
    details: (guidId: string) => requests.get<Post>(`posts/${guidId}`)
}

const Reports = {
    list: () => requests.get<PostLabeling[]>('reports'),
    forOnePost: (guidId: string) => requests.get<PostLabeling[]>(`reports/getReportsOnePost/${guidId}`),
    details: (guidId: string) => requests.get<PostLabeling>(`reports/${guidId}`),
    create: (report: PostLabeling) => axios.post('reports', report),
    update: (report: PostLabeling) => axios.put(`reports/${report.id}`, report),
    delete: (guidId: string) => axios.delete(`reports/${guidId}`)
}

const Media = {
    list: () => requests.get<Medium[]>('posts')
}

// testing errors on API
const TestErrors = {
    get400Error: () => requests.get('buggy/bad-request'),
    get401Error: () => requests.get('buggy/unauthorized'),
    get404Error: () => requests.get('buggy/not-found'),
    get500Error: () => requests.get('buggy/server-error'),
    getValidationError: () => requests.get('buggy/validation-error'),
}

// tracks requests that go up to the account controller
const Account = {
    login: (user: UserFormValues) => requests.post<User>('account/login', user),
    register: (user: UserFormValues) => requests.post<User>('account/register', user),
    // to retrieve the JWT
    currentUser: () => requests.get<User>('account/currentUser'),
}

const agent = {
    Catalog,
    TestErrors,
    Reports,
    Media,
    Account
}

export default agent;