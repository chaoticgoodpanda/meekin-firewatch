import {Grid, } from "@mui/material";
import {Post} from "../../app/models/post";
import PostCard from "./PostCard";

interface Props {
    posts: Post[];
}

export default function PostList({posts}: Props) {
    return (
        <Grid container spacing={4}>
            {posts.map((post) => (
                <Grid item xs={4} key={post.id}>
                    <PostCard post={post} />
                </Grid>
            ))}
        </Grid>
    )
}