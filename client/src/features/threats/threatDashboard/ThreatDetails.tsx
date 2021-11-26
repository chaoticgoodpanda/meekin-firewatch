import {observer} from "mobx-react-lite";
import {Box, Button, Card, CardContent, CardHeader} from "@mui/material";
import {PostLabeling} from "../../../app/models/postLabeling";
import IconButton from "@mui/material/IconButton";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import React, {useEffect} from "react";
import {Link, useParams} from "react-router-dom";
import {useStore} from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";

// interface Props {
//     report: PostLabeling;
// }

export default observer(function ThreatDetails() {
    const {reportStore} = useStore();
    const {selectedReport: report, openReportForm, deleteReport, cancelSelectedReport, loadReport, loadingInitial} = reportStore;
    const {id} = useParams<{id: string}>();
    
    useEffect(() => {
        if (id) loadReport(id);
    }, [id, loadReport]);
    
    if (loadingInitial|| !report) return <LoadingComponent />;
    
    return (
        <Card>
            <CardHeader action={
                <IconButton aria-label="settings">
                    <MoreVertIcon />
                </IconButton>
            }
                title={report.summaryAnalysis}
                titleTypographyProps={{
                    sx: {fontWeight: 'bold', color: 'primary.main'}
                }}
            />
            <CardContent>
                <a target="_blank" rel="noopener noreferrer" href={report.originalPostUrl}>{report.originalPostUrl}</a> <br/>
                {report.analysisReport}
            </CardContent>
            <Box>
                <Button sx={{mr: 2}} variant="outlined" color="primary"
                    component={Link} to={`/manage/${report.id}`}
                >
                    Edit
                </Button>
                <Button variant="outlined" color="error"
                    component={Link} to={'/threats'}
                >
                    Cancel
                </Button>
            </Box>
        </Card>
    )
    
    
});