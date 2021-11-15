import {Grid, } from "@mui/material";
import {Post} from "../../app/models/post";
import PostCard from "./PostCard";
import {PostLabeling} from "../../app/models/postLabeling";
import ReportCard from "./ReportCard";

interface Props {
    posts: Post[];
    reports: PostLabeling[];
}



export default function PostList({posts, reports}: Props) {
    return (
        <>
            <Grid container spacing={4}>
            {posts.map((post) => (
                <Grid item xs={4} key={post.id}>
                    <PostCard post={post}/>
                </Grid>
            ))}
            </Grid><Grid container spacing={2}>
                {reports.map((report) => (
                    <Grid item xs={2} key={report.id}>
                        <ReportCard />
                    </Grid>
                ))}
            </Grid>
        </>
    )
}