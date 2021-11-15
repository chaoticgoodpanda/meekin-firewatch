import {Post} from "../../app/models/post";
import PostList from "./PostList";
import {useEffect, useState} from "react";
import agent from "../../app/api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";
import {PostLabeling} from "../../app/models/postLabeling";
import {Report} from "@mui/icons-material";



export default function Catalog() {
    // use the setPosts functions to modify the state
    // set to Post type as in models
    const [posts, setPosts] = useState<Post[]>([]);
    const [reports, setReports] = useState<PostLabeling[]>([]);
    const [loading, setLoading] = useState(true);

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
    
    if (loading) return <LoadingComponent message='Loading posts and reports...' />;
    

    return (
        <>
            <PostList posts={posts} reports={reports}/>
        </>

)
}