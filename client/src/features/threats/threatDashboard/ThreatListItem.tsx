import {Avatar, Box, Button, Card, CardContent, CardHeader, IconButton} from "@mui/material";
import {LoadingButton} from "@mui/lab";
import {PostLabeling} from "../../../app/models/postLabeling";
import {SyntheticEvent, useState} from "react";
import {observer} from "mobx-react-lite";

import {useStore} from "../../../app/stores/store";
import {Link} from "react-router-dom";
import * as React from "react";


interface Props {
    report: PostLabeling;
}

function MoreVertIcon() {
    return null;
}

export default observer(function ThreatListItem({report}: Props) {
    const {reportStore} = useStore();
    const {deleteReport, loading} = reportStore;
    const [target, setTarget] = useState('');

    function handleReportDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        setTarget(e.currentTarget.name);
        deleteReport(id);
    }
    
    return (
        <Card key={report.id}>
            <CardHeader
                avatar={
                    <Avatar sx={{ bgcolor: 'secondary.main'}} src='/public/favicon.ico' aria-label="user">
                        User
                    </Avatar>
                }    
                action={
                <IconButton aria-label="settings">
                    <MoreVertIcon />
                </IconButton>
            }
                        title={report.summaryAnalysis}
                        component={Link} to={`/threats/${report.id}`}
                        titleTypographyProps={{
                            sx: {fontWeight: 'bold', color: 'primary.main', typography: 'h4'}
                        }}
            />
            <CardContent>
                Written by User Bob <br/>
                {report.originalPostUrl} <br/>
                {report.analysisReport}
            </CardContent>
            <Box sx={{mb: 2}}>
                Followers / Likes / Comments go here
            </Box>
            <Box textAlign='center' sx={{mb: 2}}>
                <Button sx={{mr: 2}} variant='contained'
                        component={Link} to={`/threats/${report.id}`}
                        color="secondary">View</Button>
                <LoadingButton variant="outlined" color="error"
                               name={report.id}
                               onClick={(e) => handleReportDelete(e, report.id)}
                               loading={loading && target === report.id}
                >
                    Delete
                </LoadingButton>
            </Box>
        </Card>
    )
})

// onClick={() => openReportForm(report.id)}