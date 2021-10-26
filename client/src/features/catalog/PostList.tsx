import {Avatar, List, ListItem, ListItemAvatar, ListItemText} from "@mui/material";
import {Post} from "../../app/models/post";
import PostCard from "./PostCard";

interface Props {
    posts: Post[];
}

export default function PostList({posts}: Props) {
    return (
        <List>
            {posts.map((post) => (
                <PostCard key={post.id} post={post} />
            ))}
        </List>
    )
}