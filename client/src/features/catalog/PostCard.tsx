import {Avatar} from "@mui/material";
import {Post} from "../../app/models/post";
import * as React from 'react';
import Card from '@mui/material/Card';
import CardHeader from '@mui/material/CardHeader';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import CardActions from '@mui/material/CardActions';
import IconButton, { IconButtonProps } from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import FavoriteIcon from '@mui/icons-material/Favorite';
import ShareIcon from '@mui/icons-material/Share';
import MoreVertIcon from '@mui/icons-material/MoreVert';

interface Props {
    post: Post;
}

interface ExpandMoreProps extends IconButtonProps {
    expand: boolean;
}


export default function PostCard({post}: Props) {
    const [expanded, setExpanded] = React.useState(false);

    const handleExpandClick = () => {
        setExpanded(!expanded);
    };

    return (
        <Card>
            <CardHeader
                avatar={
                    <Avatar sx={{ bgcolor: 'secondary.main' }} src={post.account.profileImage} aria-label="post">
                        {post.account.name}
                    </Avatar>
                }
                action={
                    <IconButton aria-label="settings">
                        <MoreVertIcon />
                    </IconButton>
                }
                title={post.account.name}
                titleTypographyProps={{
                    sx: {fontWeight: 'bold', color: 'primary.main'}
                }}
                subheader={post.date}
            />
            <CardMedia
                component="img"
                sx={{height: 200, backgroundSize: 'contain', bgcolor: 'primary.light'}}
                image={post.postUrl}
                alt="Post image"
            />
            <CardContent>
                <Typography variant="body2" color="text.secondary">
                    <strong>{post.title}</strong>
                    <br/><br/>
                    {post.message}
                </Typography>
            </CardContent>
            <CardActions disableSpacing>
                <IconButton aria-label="add to favorites">
                    {post.statistics.actual?.likeCount} 
                    <FavoriteIcon />
                </IconButton>
                <IconButton aria-label="share">
                    <ShareIcon />
                </IconButton>
            </CardActions>
        </Card>
    );
}



// <Avatar src={media.url} />