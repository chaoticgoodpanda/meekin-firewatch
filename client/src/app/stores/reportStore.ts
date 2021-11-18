import {makeAutoObservable, runInAction} from "mobx";
import {PostLabeling} from "../models/postLabeling";
import agent from "../api/agent";
import {Post} from "../models/post";
import {v4 as uuid} from 'uuid';
import {useParams, withRouter} from "react-router-dom";
import {Report} from "@mui/icons-material";

export default class ReportStore {
    posts: Post[] = [];
    selectedPost: Post | undefined = undefined;
    reports: PostLabeling[] = [];
    reportsForId: PostLabeling[] = [];
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
    
    loadReportsForId = async (id: string) => {
        this.setLoadingInitial(true);
        try {
            const reportsForId = await agent.Reports.forOnePost(id);
            console.log(reportsForId);
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
    
    createReport = async (report: PostLabeling) => {
        this.loading = true;
        report.id = uuid();
        try {
            await agent.Reports.create(report);
            runInAction(() => {
                this.reports.push(report);
                this.selectedReport = report;
                this.editMode = false;
                this.loading = false;
            })
        } catch (e) {
            console.log(e);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
    
    updateReport = async (report: PostLabeling) => {
        this.loading = true;
        try {
            await agent.Reports.update(report);
            runInAction(() => {
                // creates a new array with spread operator, replacing the old array
                this.reports = [...this.reports.filter(a => a.id !== report.id), report];
                this.selectedReport = report;
                this.editMode = false;
                this.loading = false;
            })
        } catch (e) {
            console.log(e);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
    
    selectPost = (id: string) => {
        this.selectedPost = this.posts.find(a => a.id === id);
    }
    
    deleteReport = async (id: string) => {
        this.loading = true;
        try {
            await agent.Reports.delete(id);
            runInAction(() => {
                // deletes the report from the list
                this.reports = [...this.reports.filter(a => a.id !== id)];
                if (this.selectedReport?.id === id) this.cancelSelectedReport();
            })
        } catch (e) {
            console.log(e);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
    

}