import {observer} from "mobx-react-lite";
import {Box, Button, Card, CardContent, CardHeader, Grid} from "@mui/material";
import IconButton from "@mui/material/IconButton";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import React, {useEffect} from "react";
import {Link, useParams} from "react-router-dom";
import {useStore} from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import ThreatDetailedHeader from "./ThreatDetailedHeader";
import ThreatDetailedInfo from "./ThreatDetailedInfo";
import ThreatDetailedChat from "./ThreatDetailedChat";
import ThreatDetailedSidebar from "./ThreatDetailedSidebar";


export default observer(function ThreatDetails() {
    const {reportStore} = useStore();
    const {selectedReport: report, openReportForm, deleteReport, cancelSelectedReport, loadReport, loadingInitial} = reportStore;
    const {id} = useParams<{id: string}>();
    
    useEffect(() => {
        if (id) loadReport(id);
    }, [id, loadReport]);
    
    if (loadingInitial|| !report) return <LoadingComponent />;
    
    return (
        <Grid container spacing={4}>
            <Grid item xs={10}>
                <ThreatDetailedHeader report={report} />
                <ThreatDetailedInfo report={report} />
                <ThreatDetailedChat />
            </Grid>
            <Grid item xs={2}>
                <ThreatDetailedSidebar />
            </Grid>
        </Grid>
    )
    
    
});



// <Card>
//     <CardHeader action={
//         <IconButton aria-label="settings">
//             <MoreVertIcon />
//         </IconButton>
//     }
//                 title={report.summaryAnalysis}
//                 titleTypographyProps={{
//                     sx: {fontWeight: 'bold', color: 'primary.main'}
//                 }}
//     />
//     <CardContent>
//         <a target="_blank" rel="noopener noreferrer" href={report.originalPostUrl}>{report.originalPostUrl}</a> <br/>
//         {report.analysisReport}
//     </CardContent>
//     <Box>
//         <Button sx={{mr: 2}} variant="outlined" color="primary"
//                 component={Link} to={`/manage/${report.id}`}
//         >
//             Edit
//         </Button>
//         <Button variant="outlined" color="error"
//                 component={Link} to={'/threats'}
//         >
//             Cancel
//         </Button>
//     </Box>
// </Card>