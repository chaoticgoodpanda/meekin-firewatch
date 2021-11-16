import {
    Button, Card, CardContent, Collapse,
    Divider,
    Grid, IconButtonProps, styled,
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
import IconButton from "@mui/material/IconButton";
import ThreatForm from "../threats/threatForm/ThreatForm";
import {PostLabeling} from "../../app/models/postLabeling";
import {v4 as uuid} from 'uuid';

interface Props {
    selectedPost: Post;
    closeForm: () => void;
    selectedReport: PostLabeling;
    selectReport: (id: string) => void;
    cancelSelectReport: () => void;
}


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

export default function PostDetails({selectedPost, closeForm, selectedReport, selectReport, cancelSelectReport}: Props) {
    // a single report that a user might generate or update
    const [report, setReport] = useState<PostLabeling>();
    // loading the existing reports
    const [reports, setReports] = useState<PostLabeling[]>([]);
    // create the edit mode state for editing reports, initial state of false
    const [editMode, setEditMode] = useState(false);
    
    // capture the translated text for persistence to DB
    const [translated, setTranslated] = useState<string>('');
    
    const [expanded, setExpanded] = React.useState(false);
    // takes the http URL as a string for the specific post detail
    const {id} = useParams<{id: string}>();
    const [post, setPost] = useState<Post>();
    // set loading indicator to true when initializing this component
    const [loading, setLoading] = useState(true);

    const handleExpandClick = () => {
        setExpanded(!expanded);
        setEditMode(!editMode);
    };
    
    
    // create or edit the report form for threats
    function handleCreateOrEditReport(report: PostLabeling) {
        // if we have a report id we know we're updating a report, rather than creating one
        report.id 
            ? setReports([...reports.filter(x => x.id !== report.id), report]) 
            : setReports([...reports, {...report, id: uuid()}]);
        setEditMode(true);
    }
    
    // deletes a report
    function handleDeleteReport(id: string) {
        setReports([...reports.filter(x => x.id !== id)])
    }
    
    // same as OnInit in Angular
    useEffect(() => {
        axios.get<Post>(`https://localhost:5001/api/posts/${id}`)
            .then(response => {
                 setPost((response.data))
                }
            )
            .catch(error => console.log(error.response))
            .finally(() => setLoading(false));
    }, [id]);

    // another useEffect, this time for loading the reports for the posts
    useEffect( () => {
        axios.get<PostLabeling[]>(`https://localhost:5001/api/reports/getReportsOnePost/${id}`)
            .then(reports => setReports(reports.data))
            .catch(error => console.log(error))
            .finally(() => setLoading(false))
    }, []);
    
    const handleTranslation = (event: React.ChangeEvent<HTMLInputElement>) => {
        setTranslated((event.target as HTMLInputElement).value);
    };

    if (post) {
        selectedPost = post;
    }
    
    
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
                        <br/>
                        {reports.map((report) => (
                            <Grid item key={report.id}>
                                <Card>
                                    <CardContent>
                                        <Typography>
                                            {report.summaryAnalysis} - {report.analysisReport}
                                        </Typography>
                                        <Button onClick={() => handleCreateOrEditReport(report)} color='warning'>Edit</Button>
                                        <Button onClick={() => handleDeleteReport(report.id)} color='error'>Delete</Button>
                                    </CardContent>
                                </Card>
                            </Grid>
                        ))}
                        <Collapse in={expanded} timeout="auto"  unmountOnExit >
                            <br/>
                            Please fill out the fields below. When you submit, the post data 
                            on the right will be submitted along with your report. 
                            <br/>
                            <ThreatForm 
                                report={report} 
                                reports={reports}
                                closeForm={closeForm} 
                                post={selectedPost} 
                                editMode={editMode} 
                                selectedReport={selectedReport}
                                createOrEdit={handleCreateOrEditReport}
                                translatedContent={translated}
                                deleteReport={handleDeleteReport}
                            />
                        </Collapse>
                        <ExpandMore
                            expand={expanded}
                            onClick={handleExpandClick}
                            aria-expanded={expanded}
                            aria-label="show more"
                            editMode={editMode}
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
                                            <GoogleTranslate language="en" text={post.message}   />
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
