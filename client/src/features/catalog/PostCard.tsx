import {Avatar, Box, Button, Collapse, duration, Icon, IconButtonProps, styled, ThemeProvider} from "@mui/material";
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
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import {
    ChildCare,
    Dangerous, EmojiObjects,
    SentimentVeryDissatisfied,
    SentimentVerySatisfied,
    ThumbUpAltOutlined
} from "@mui/icons-material";

interface Props {
    post: Post;
}

interface ExpandMoreProps extends IconButtonProps {
    expand: boolean;
}

// expands text for text in posts that are too long
const ExpandMore = styled((props: ExpandMoreProps) => {
    const { expand, ...other } = props;
    return <IconButton {...other} />;
})(({theme, expand}: any) => ({
    transform: !expand ? 'rotate(0deg)' : 'rotate(180deg)',
    marginLeft: 'auto',

}));


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
                <IconButton aria-label="add to favorites" sx={{fontSize: 12}} size="small">
                    <ThumbUpAltOutlined />
                    &nbsp;{post.statistics.actual?.likeCount}
                </IconButton>
                <IconButton sx={{fontSize: 12}} size="small">
                    <Dangerous />
                    &nbsp;{post.statistics.actual?.angryCount}
                </IconButton>
                <Collapse in={expanded} timeout="auto"  unmountOnExit>
                    <IconButton sx={{fontSize: 12}} size="small">
                        <FavoriteIcon />
                        &nbsp;{post.statistics.actual?.loveCount}
                    </IconButton>
                    <IconButton sx={{fontSize: 12}} size="small">
                        <ChildCare />
                        &nbsp;{post.statistics.actual?.careCount}
                    </IconButton>
                    <IconButton sx={{fontSize: 12}} size="small">
                        <SentimentVerySatisfied />
                        &nbsp;{post.statistics.actual?.hahaCount}
                    </IconButton>
                    <IconButton sx={{fontSize: 12}} size="small">
                        <EmojiObjects />
                        &nbsp;{post.statistics.actual?.wowCount}
                    </IconButton>
                    <IconButton sx={{fontSize: 12}} size="small">
                        <SentimentVeryDissatisfied />
                        &nbsp;{post.statistics.actual?.sadCount}
                    </IconButton>
                </Collapse>
                
                <IconButton aria-label="share">
                    <ShareIcon />
                </IconButton>
                <ExpandMore
                    expand={expanded}
                    onClick={handleExpandClick}
                    aria-expanded={expanded}
                    aria-label="show more"
                >
                    <ExpandMoreIcon />
                </ExpandMore>
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

