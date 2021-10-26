import {Post} from "./post";
import {Pagination} from "./pagination";

export interface Result {
    posts: Post[];
    pagination: Pagination;
}