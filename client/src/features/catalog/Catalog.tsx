import {Post} from "../../app/models/post";
import {Avatar, Button, List, ListItem, ListItemAvatar, ListItemText} from "@mui/material";
import {Medium} from "../../app/models/medium";
import PostList from "./PostList";

interface Props {
    posts: Post[];
    media: Medium[];
}

export default function Catalog({posts}: Props) {
    return (
        <>
            <PostList posts={posts} />
            <Button variant='contained'>Add Post</Button>
        </>

)
}