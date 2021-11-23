import {Grid, } from "@mui/material";
import {Post} from "../../app/models/post";
import PostCard from "./PostCard";
import {useEffect, useState} from "react";
import axios from "axios";
import {Medium} from "../../app/models/medium";
import agent from "../../app/api/agent";
import {useStore} from "../../app/stores/store";
import {observer} from "mobx-react-lite";
import PostDetails from "./PostDetails";
import TemporaryDrawer from "../../app/layout/TemporaryDrawer";

interface Props {
}


export default observer(function PostList() {
    const {reportStore} = useStore();
    const {reportsByDate, postsByDate, selectedPost, editMode} = reportStore;

    
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