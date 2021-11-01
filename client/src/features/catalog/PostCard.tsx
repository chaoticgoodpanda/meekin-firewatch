import {Avatar, Box, Button} from "@mui/material";
import {Post} from "../../app/models/post";
import * as React from 'react';
import Card from '@mui/material/Card';
import CardHeader from '@mui/material/CardHeader';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import CardActions from '@mui/material/CardActions';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import FavoriteIcon from '@mui/icons-material/Favorite';
import ShareIcon from '@mui/icons-material/Share';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import {Link} from "react-router-dom";

interface Props {
    post: Post;
}


export default function PostCard({post}: Props) {

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
            {post.media?.map((media) => (
                <CardMedia
                    key={media.id}
                    component="img"
                    sx={{height: 200, backgroundSize: 'center', bgcolor: 'transparent', justifyContent: 'center'}}
                    image={media.url}
                    alt="Post image"
                />
            ))}
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
            <Box textAlign='center' sx={{mb: 2}}>
                <Button component={Link} to={`/catalog/${post.platformId}`} color="secondary">Analyze</Button>&nbsp;&nbsp;&nbsp;
                <Button component={Link} to={`/catalog/${post.platformId}`} variant="contained" color="success">
                    Label
                </Button>&nbsp;&nbsp;&nbsp;
                <Button variant="outlined" color="error">
                    Appeal
                </Button>
            </Box>

        </Card>
    );
}

