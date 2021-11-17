import {makeAutoObservable} from "mobx";
import {PostLabeling} from "../models/postLabeling";
import agent from "../api/agent";
import {Post} from "../models/post";

export default class ReportStore {
    posts: Post[] = [];
    selectedPost: Post | undefined = undefined;
    reports: PostLabeling[] = [];
    selectedReport: PostLabeling | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = false;
    
    constructor() {
        // mobx works out on its own that title is a property and therefore observable
        // setTitle is a function and therefore observable
        makeAutoObservable(this)
    }
    
    loadPosts = async () => {
        this.setLoadingInitial(true);
        try {
            const posts = await agent.Catalog.list();
                // do date conversions
                posts.forEach(post => {
                    post.date = post.date.split('T')[0];
                    this.posts.push(post);
                })
            this.setLoadingInitial(false);
        } catch (e) {
            console.log(e);
            this.setLoadingInitial(false);
        }
    }
    
    loadReports = async () => {
        this.setLoadingInitial(true);
        try {
            const reports = await agent.Reports.list();
            this.setLoadingInitial(false);
        } catch (e) {
            console.log(e);
            this.setLoadingInitial(false);
        }
    }
    
    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }
    
    selectReport = (id: string) => {
        this.selectedReport = this.reports.find(a => a.id === id);
    }
    
    cancelSelectedReport = () => {
        this.selectedReport = undefined;
    }
    
    openForm = (id?: string) => {
        id ? this.selectReport(id) : this.cancelSelectedReport();
        this.editMode = true;
    }
    
    closeForm = () => {
        this.editMode = false;
    }
    
    selectPost = (id: string) => {
        this.selectedPost = this.posts.find(a => a.id === id);
    }
    

}