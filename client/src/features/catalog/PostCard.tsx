import {Avatar, ListItem, ListItemAvatar, ListItemText} from "@mui/material";
import {Post} from "../../app/models/post";

interface Props {
    post: Post;
}

export default function PostCard({post}: Props) {
    return (
        <ListItem key={post.id}>
            <ListItemAvatar>
                <Avatar src={post.postUrl} />
            </ListItemAvatar>
            <ListItemText>
                {post.title} - {post.message}
            </ListItemText>
        </ListItem>
    )
}