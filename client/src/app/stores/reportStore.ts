import {makeAutoObservable, runInAction} from "mobx";
import {PostLabeling} from "../models/postLabeling";
import agent from "../api/agent";
import {Post} from "../models/post";
import {v4 as uuid} from 'uuid';
import {useParams, withRouter} from "react-router-dom";
import {Report} from "@mui/icons-material";

export default class ReportStore {
    // posts: Post[] = [];
    postRegistry = new Map<string, Post>();
    selectedPost: Post | undefined = undefined;
    // reports: PostLabeling[] = [];
    reportRegistry = new Map<string, PostLabeling>();
    reportsForId: PostLabeling[] = [];
    selectedReport: PostLabeling | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = true;
    
    constructor() {
        // mobx works out on its own that title is a property and therefore observable
        // setTitle is a function and therefore observable
        makeAutoObservable(this)
    }
    
    get reportsByDate() {
        return Array.from(this.reportRegistry.values()).sort((a, b) => 
            Date.parse(a.analysisDate) - Date.parse(b.analysisDate)).reverse();
    }
    
    get postsByDate() {
        return Array.from(this.postRegistry.values()).sort((a, b) => 
            Date.parse(a.date) - Date.parse(b.date)).reverse();
    }
    
    loadPosts = async () => {
        try {
            const posts = await agent.Catalog.list();
                // do date conversions
                posts.forEach(post => {
                    post.date = post.date.split('T')[0];
                    this.postRegistry.set(post.id, post);
                })
            console.log(Array.from(this.postRegistry));
            this.setLoadingInitial(false);
        } catch (e) {
            console.log(e);
            this.setLoadingInitial(false);
        }
    }
    
    loadReports = async () => {
        try {
            const reports = await agent.Reports.list();
            reports.forEach(report => {
                report.analysisDate = report.analysisDate.split('T')[0];
                this.reportRegistry.set(report.id, report);
            })
            this.setLoadingInitial(false);
        } catch (e) {
            console.log(e);
            this.setLoadingInitial(false);
        }
    }
    
    loadReportsForId = async (id: string) => {
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
        this.selectedReport = this.reportRegistry.get(id);
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
                this.reportRegistry.set(report.id, report);
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
                this.reportRegistry.set(report.id, report);
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
        this.selectedPost = this.postRegistry.get(id);
    }
    
    deleteReport = async (id: string) => {
        this.loading = true;
        try {
            await agent.Reports.delete(id);
            runInAction(() => {
                this.reportRegistry.delete(id);
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