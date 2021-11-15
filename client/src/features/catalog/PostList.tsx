import {Grid, } from "@mui/material";
import {Post} from "../../app/models/post";
import PostCard from "./PostCard";
import {PostLabeling} from "../../app/models/postLabeling";
import ThreatCard from "./ThreatCard";

interface Props {
    posts: Post[];
    reports: PostLabeling[];
    selectedReport: PostLabeling | undefined;
    selectReport: (id: string) => void;
    cancelSelectReport: () => void;
    editMode: boolean;
    openForm: (id: string) => void;
    closeForm: () => void;
}



export default function PostList({posts, reports, selectReport, selectedReport, cancelSelectReport, editMode, openForm, closeForm}: Props) {
    return (
        <>
            <Grid container spacing={4}>
            {posts.map((post) => (
                <Grid item xs={4} key={post.id}>
                    <PostCard 
                        post={post}
                        selectReport={selectReport}
                        cancelSelectReport={cancelSelectReport}
                        reports={reports}
                        openForm={openForm}
                        selectedReport={selectedReport}
                        
                    />
                </Grid>
            ))}
            </Grid><Grid container spacing={2}>
                {reports.map((report) => (
                    <Grid item xs={2} key={report.id}>
                        {editMode &&
                        <ThreatCard closeForm={closeForm} report={selectedReport} />
                        }
                    </Grid>
                ))}
            </Grid>
        </>
    )
}