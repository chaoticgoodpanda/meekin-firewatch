import {Post} from "../../app/models/post";
import PostList from "./PostList";
import {useEffect, useState} from "react";
import agent from "../../app/api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";
import {PostLabeling} from "../../app/models/postLabeling";



export default function Catalog() {
    // use the setPosts functions to modify the state
    // set to Post type as in models
    const [posts, setPosts] = useState<Post[]>([]);
    // const [report, setReport] = useState<PostLabeling | undefined>(undefined);
    const [reports, setReports] = useState<PostLabeling[]>([]);
    const [loading, setLoading] = useState(true);
    const [selectedReport, setSelectedReport] = useState<PostLabeling | undefined>(undefined);
    const [editMode, setEditMode] = useState(false);

    // can add a side effect to component OnInit, i.e. when it loads, is destroyed, etc.
    useEffect(() => {
        agent.Catalog.list()
            .then(posts => setPosts((posts)))
            .catch(error => console.log(error))
            .finally(() => setLoading(false))
    }, []);
    
    
    // another useEffect, this time for loading the reports for the posts
    useEffect( () => {
        agent.Reports.list()
            .then(reports => setReports(reports))
            .catch(error => console.log(error))
            .finally(() => setLoading(false))
    }, []);
    
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
    
    if (loading) return <LoadingComponent message='Loading posts and reports...' />;
    

    return (
        <>
            <PostList
                posts={posts} 
                reports={reports}
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