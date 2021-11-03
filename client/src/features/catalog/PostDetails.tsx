import {
    Button,
    Divider,
    Grid,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableRow,
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

export default function PostDetails() {
    // takes the http URL as a string for the specific post detail
    const {id} = useParams<{id: string}>();
    const [post, setPost] = useState<Post[]>([]);
    // set loading indicator to true when initializing this component
    const [loading, setLoading] = useState(true);
    
    // same as OnInit in Angular
    useEffect(() => {
        axios.get(`https://localhost:5001/api/posts/${id}`)
            .then(response => {
                    setPost((response.data.result.posts))
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
                {post.map((onePost) => (
                    <><Grid item xs={6} key={onePost.id}>
                        {onePost.media.map((media) => (
                            <img key={media.id} src={media.url} alt={onePost.account.name} style={{width: '100%'}}/>
                        ))}
                        <Button onClick={() => history.push('/catalog')} color="secondary">Back to Catalog</Button>
                    </Grid><Grid item xs={6}>
                        <Typography variant='h3'>{onePost.description}</Typography>
                        <Divider sx={{mb: 2}} />
                        <Typography variant='h4' color='secondary'>{onePost.message}</Typography>
                        <TableContainer>
                            <Table>
                                <TableBody>
                                    <TableRow>
                                        <TableCell>Account Name</TableCell>
                                        <TableCell>{onePost.account.name}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Last updated</TableCell>
                                        <TableCell>{onePost.date}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Title (if any)</TableCell>
                                        <TableCell>{onePost.title}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Post content</TableCell>
                                        <TableCell>{onePost.message}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Translated post content</TableCell>
                                        <TableCell>
                                            <GoogleTranslate language="en" text={onePost.message} />
                                        </TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Original post URL</TableCell>
                                        <TableCell><a target="_blank" rel="noopener noreferrer" href={onePost.postUrl}>{onePost.postUrl}</a></TableCell>
                                    </TableRow>
                                    
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </Grid></>
                    ))}
            </Grid>
        </>

    )
}

// <Typography variant='h2'>
//     {post.map((onePost) => (
//             <Card key={onePost.id}>
//                 <CardContent>
//                     {onePost.message}
//                 </CardContent>
//             </Card>
//         )
//
//     )}
// </Typography>