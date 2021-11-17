import {Post} from "../../app/models/post";
import PostList from "./PostList";
import {useEffect, useState} from "react";
import agent from "../../app/api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";
import {PostLabeling} from "../../app/models/postLabeling";
import {useStore} from "../../app/stores/store";



export default function Catalog() {
    const {reportStore} = useStore();
    // use the setPosts functions to modify the state
    // set to Post type as in models
    const [posts, setPosts] = useState<Post[]>([]);
    const [reports, setReports] = useState<PostLabeling[]>([]);
    const [selectedReport, setSelectedReport] = useState<PostLabeling | undefined>(undefined);
    const [editMode, setEditMode] = useState(false);

    // can add a side effect to component OnInit, i.e. when it loads, is destroyed, etc.
    useEffect(() => {
        reportStore.loadPosts();
    }, [reportStore]);
    
    
    // another useEffect, this time for loading the reports for the posts
    useEffect( () => {
        reportStore.loadReports();
    }, [reportStore]);
    
    function handleSelectReport(id: string) {
        setSelectedReport(reports.find(x => x.id === id));
    }
    
    function handleCancelSelectReport() {
        setSelectedReport(undefined);
    }
    
    // set the report to be undefined
    function handleFormOpen(id?: string) {
        id ? handleSelectReport(id) : handleCancelSelectReport();
        setEditMode(true);
    }
    
    function handleFormClosed() {
        setEditMode(false);
    }
    
    if (reportStore.loadingInitial) return <LoadingComponent message='Loading posts and reports...' />;
    

    return (
        <>
            <PostList
                posts={reportStore.posts} 
                reports={reportStore.reports}
                selectedReport={selectedReport}
                selectReport={handleSelectReport}
                cancelSelectReport={handleCancelSelectReport}
                editMode={editMode}
                openForm={handleFormOpen}
                closeForm={handleFormClosed}
            />
        </>

)
}