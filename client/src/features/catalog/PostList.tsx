import {Grid, } from "@mui/material";
import {Post} from "../../app/models/post";
import PostCard from "./PostCard";
import {PostLabeling} from "../../app/models/postLabeling";
import ThreatCard from "./ThreatCard";
import {useEffect, useState} from "react";
import axios from "axios";
import {Medium} from "../../app/models/medium";
import agent from "../../app/api/agent";
import {useStore} from "../../app/stores/store";
import {observer} from "mobx-react-lite";

interface Props {
    posts: Post[];
    reports: PostLabeling[];
}



export default observer(function PostList({posts, reports}: Props) {
    const {reportStore} = useStore();
    
    const [medium, setMedium] = useState<Medium[]>([]);
    // another useEffect, this time for loading the reports for the posts
    useEffect( () => {
        agent.Media.list()
            .then(medium => setMedium(medium))
            .catch(error => console.log(error))
    }, []);
    
    return (
        <>
            <Grid container spacing={4}>
            {posts.map((post) => (
                <Grid item xs={4} key={post.id}>
                    <PostCard 
                        post={post}
                        reports={reports}
                        medium={medium}
                    />
                </Grid>
            ))}
            </Grid><Grid container spacing={2}>
                {reports.map((report) => (
                    <Grid item xs={2} key={report.id}>
                        <ThreatCard  />
                    </Grid>
                ))}
            </Grid>
        </>
    )
})