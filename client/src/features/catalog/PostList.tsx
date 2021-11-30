import {Grid, } from "@mui/material";
import PostCard from "./PostCard";
import {useEffect, useState} from "react";
import {Medium} from "../../app/models/medium";
import agent from "../../app/api/agent";
import {useStore} from "../../app/stores/store";
import {observer} from "mobx-react-lite";


export default observer(function PostList() {
    const {reportStore} = useStore();
    const {reportsByDate, postsByDate} = reportStore;

    
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
            {postsByDate.map((post) => (
                <Grid item xs={4} key={post.id}>
                    <PostCard 
                        post={post}
                        reports={reportsByDate}
                        medium={medium}
                    />
                </Grid>
            ))}
            </Grid>
        </>
    )
})