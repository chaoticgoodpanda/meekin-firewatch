import {makeAutoObservable} from "mobx";
import {PostLabeling} from "../models/postLabeling";
import agent from "../api/agent";
import {Post} from "../models/post";

export default class ReportStore {
    posts: Post[] = [];
    selectedPost: Post | null = null;
    reports: PostLabeling[] = [];
    selectedReport: PostLabeling | null = null;
    editMode = false;
    loading = false;
    loadingInitial = false;
    
    constructor() {
        // mobx works out on its own that title is a property and therefore observable
        // setTitle is a function and therefore observable
        makeAutoObservable(this)
    }
    
    loadPosts = async () => {
        this.loadingInitial = true;
        try {
            const posts = await agent.Catalog.list();
            // do date conversions
            posts.forEach(post => {
                post.date = post.date.split('T')[0];
                this.posts.push(post);
            })
            this.loadingInitial = false;
        } catch (e) {
            console.log(e);
        }
    }
    
    loadReports = async () => {
        this.loadingInitial = true;
        try {
            const reports = await agent.Reports.list();
            this.loadingInitial = false;
        } catch (e) {
            console.log(e);
            this.loadingInitial = false;
        }
    }
    

}