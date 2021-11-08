import {
    Box,
    Button, Collapse,
    Divider,
    Grid, IconButtonProps, styled,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableRow, TextField,
    Typography
} from "@mui/material";
import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";
import axios from "axios";
import {Post} from "../../app/models/post";
import {history} from "../../index";
import NotFound from "../../app/errors/NotFound";
import LoadingComponent from "../../app/layout/LoadingComponent";
import GoogleTranslate from "../translate/GoogleTranslate";
import * as React from "react";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import IconButton from "@mui/material/IconButton";
import ThreatForm from "../threats/threatForm/ThreatForm";


interface ExpandMoreProps extends IconButtonProps {
    expand: boolean;
}

// expands text for text in posts that are too long
const ExpandMore = styled((props: ExpandMoreProps) => {
    const { expand, ...other } = props;
    return <IconButton {...other} />;
})(({theme, expand}: any) => ({
    text: "Hide Report Form"

}));

export default function PostDetails() {
    const [report, setReport] = useState('');
    const [expanded, setExpanded] = React.useState(false);
    // takes the http URL as a string for the specific post detail
    const {id} = useParams<{id: string}>();
    const [post, setPost] = useState<Post>();
    // set loading indicator to true when initializing this component
    const [loading, setLoading] = useState(true);

    const handleExpandClick = () => {
        setExpanded(!expanded);
    };
    
    // same as OnInit in Angular
    useEffect(() => {
        axios.get<Post>(`https://localhost:5001/api/posts/${id}`)
            .then(response => {
                 setPost((response.data))
                 console.log(post);
                }
            )
            .catch(error => console.log(error.response))
            .finally(() => setLoading(false));
    }, [id]);
    
    
    if (loading) return <LoadingComponent message='Loading your post...'/>
    
    if (!post) return <NotFound />;
    
    
    return (
        <>
            <Grid container spacing={6}>
                    <>
                    <Grid item xs={6} >
                        {post.media.map((media, index2) => (
                            <img key={index2} src={media.url} alt={post.account.name} style={{width: '100%'}}/>
                        ))}
                        <Collapse in={expanded} timeout="auto"  unmountOnExit >
                            <br/>
                            Please fill out the fields below. When you submit, the post data 
                            on the right will be submitted along with your report. 
                            <br/>
                            <ThreatForm />
                        </Collapse>
                        <ExpandMore
                            expand={expanded}
                            onClick={handleExpandClick}
                            aria-expanded={expanded}
                            aria-label="show more"
                        >
                            <Button color="primary">Toggle Report Form</Button>
                        </ExpandMore>
                        <Button onClick={() => history.push('/catalog')} color="secondary">Back to Catalog</Button>
                    </Grid>
                        
                        <Grid item xs={6}>
                        <Typography variant='h3'>{post.description}</Typography>
                        <Divider sx={{mb: 2}} />
                        <Typography variant='h4' color='secondary'>{post.message}</Typography>
                        <TableContainer>
                            <Table>
                                <TableBody>
                                    <TableRow>
                                        <TableCell>Account Name</TableCell>
                                        <TableCell>{post.account.name}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Last updated</TableCell>
                                        <TableCell>{post.date}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Title (if any)</TableCell>
                                        <TableCell>{post.title}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Post content</TableCell>
                                        <TableCell>{post.message}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Translated post content</TableCell>
                                        <TableCell>
                                            <GoogleTranslate language="en" text={post.message} />
                                        </TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Original post URL</TableCell>
                                        <TableCell><a target="_blank" rel="noopener noreferrer" href={post.postUrl}>{post.postUrl}</a></TableCell>
                                    </TableRow>
                                    
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </Grid>
                    </>
            </Grid>
        </>

    )
}
