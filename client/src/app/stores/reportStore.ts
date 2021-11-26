import {makeAutoObservable, runInAction} from "mobx";
import {PostLabeling} from "../models/postLabeling";
import agent from "../api/agent";
import {Post} from "../models/post";

export default class ReportStore {
    postRegistry = new Map<string, Post>();
    selectedPost: Post | undefined = undefined;
    reportRegistry = new Map<string, PostLabeling>();
    reportsForId: PostLabeling[] = [];
    reportsForIdRegistry = new Map<string, PostLabeling>();
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
    
    get groupedReports() {
        // an array of objects, an object has a key, and for each key we have array of reports
        return Object.entries(
            this.reportsByDate.reduce((reports, report) => {
                const date = report.analysisDate;
                reports[date] = reports[date] ? [...reports[date], report] : [report];
                return reports;
            }, {} as {[key: string]: PostLabeling[]})
        )
    }
    
    
    get postsByDate() {
        return Array.from(this.postRegistry.values()).sort((a, b) => 
            Date.parse(a.date) - Date.parse(b.date)).reverse();
    }
    
    get reportsForIdByDate() {
        return Array.from(this.reportsForIdRegistry.values()).sort((a, b) =>
            Date.parse(a.analysisDate) - Date.parse(b.analysisDate)).reverse();
    }
    
    loadPosts = async () => {
        this.loadingInitial = true;
        try {
            const posts = await agent.Catalog.list();
                // do date conversions
                posts.forEach(post => {
                    // this action because it's inside its own function will be set as a function in MobX
                    this.setPost(post);
                })
            console.log(Array.from(this.postRegistry));
            this.setLoadingInitial(false);
        } catch (e) {
            console.log(e);
            this.setLoadingInitial(false);
        }
    }
    
    loadPost = async (id: string) => {
        this.loadingInitial = true;
        let post = this.getPost(id);
        if (post) {
            this.selectedPost = post;
            return post;
        } else {
            this.loadingInitial = true;
            try {
                // if the postId is not already in the post Map, only then fetch it from the API
                post = await agent.Catalog.details(id);
                this.setPost(post);
                runInAction(() => {
                    this.selectedPost = post;
                })
                this.setLoadingInitial(false);
                return post;
            } catch (e) {
                console.log(e);
                this.setLoadingInitial(false);
            }
        }
    }
    
    private setPost = (post: Post) => {
        post.date = post.date.split('T')[0];
        this.postRegistry.set(post.id, post);
    }

    private getPost = (id: string) => {
            return this.postRegistry.get(id);
    }
    
    loadReports = async () => {
        this.loadingInitial = true;
        try {
            const reports = await agent.Reports.list();
            reports.forEach(report => {
                this.setReport(report);
            })
            this.setLoadingInitial(false);
        } catch (e) {
            console.log(e);
            this.setLoadingInitial(false);
        }
    }
    
    // loads a specific report by id
    loadReport = async (id: string) => {
        let report = this.getReport(id);
        if (report) {
            this.selectedReport = report;
            return report;
        } else {
            this.loadingInitial = true;
            try {
                report = await agent.Reports.details(id);
                this.setReport(report);
                runInAction(() => {
                    this.selectedReport = report;
                })
                this.setLoadingInitial(false);
                return report;
            } catch (e) {
                console.log(e);
                this.setLoadingInitial(false);
            }
        }
    }
    
    private setReport = (report: PostLabeling) => {
        report.analysisDate = report.analysisDate.split('T')[0];
        this.reportRegistry.set(report.id, report);
    }
    
    private getReport = (id: string) => {
        return this.reportRegistry.get(id);
    }
    
    loadReportsForId = async (id: string) => {
        try {
            const reportsForId = await agent.Reports.forOnePost(id);
            reportsForId.forEach(report => {
                this.setReportsForId(report);
                this.setLoadingInitial(false);
            })
            
            this.setLoadingInitial(false);
        } catch (e) {
            console.log(e);
            this.setLoadingInitial(false);
        }
    }

    private getReportsForId = (facebookGuid: string) => {
        return this.reportsForIdRegistry.has(facebookGuid);
    }

    private setReportsForId = (report: PostLabeling) => {
        report.analysisDate = report.analysisDate.split('T')[0];
        this.reportsForIdRegistry.set(report.facebookGuid, report);
    }

    
    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }
    
    createReport = async (report: PostLabeling) => {
        this.loading = true;
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
    
    cancelSelectedPost = () => {
        this.selectedPost = undefined;
    }
    
    openPost = (id?: string) => {
        id ? this.selectPost(id) : this.cancelSelectedPost();
        this.editMode = true;
    }
    
    closePost = () => {
        this.editMode = false;
    }
    
    selectReport = (id: string) => {
        this.selectedReport = this.reportRegistry.get(id);
    }

    cancelSelectedReport = () => {
        this.selectedReport = undefined;
    }

    openReportForm = (id?: string) => {
        id ? this.selectReport(id) : this.cancelSelectedReport();
        this.editMode = true;
    }

    closeReportForm = () => {
        this.editMode = false;
    }
    
    deleteReport = async (id: string) => {
        this.loading = true;
        try {
            await agent.Reports.delete(id);
            runInAction(() => {
                this.reportRegistry.delete(id);
            })
        } catch (e) {
            console.log(e);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
    

}