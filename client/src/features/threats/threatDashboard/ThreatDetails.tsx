import {observer} from "mobx-react-lite";
import {Box, Button, Card, CardContent, CardHeader} from "@mui/material";
import {PostLabeling} from "../../../app/models/postLabeling";
import IconButton from "@mui/material/IconButton";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import React from "react";
import {Link} from "react-router-dom";
import {useStore} from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";

// interface Props {
//     report: PostLabeling;
// }

export default observer(function ThreatDetails() {
    const {reportStore} = useStore();
    const {selectedReport: report, openReportForm, deleteReport, cancelSelectedReport} = reportStore;
    
    if (!report) return <LoadingComponent />;
    
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
                    onClick={() => openReportForm(report.id)}
                >
                    Edit
                </Button>
                <Button variant="outlined" color="error"
                    onClick={cancelSelectedReport}
                >
                    Cancel
                </Button>
            </Box>
        </Card>
    )
    
    
});