import {Box, Button, Card, CardContent, CardHeader, IconButton} from "@mui/material";
import {LoadingButton} from "@mui/lab";
import {PostLabeling} from "../../../app/models/postLabeling";
import {SyntheticEvent, useState} from "react";
import {observer} from "mobx-react-lite";

import {useStore} from "../../../app/stores/store";
import {Link} from "react-router-dom";


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
                {report.originalPostUrl} <br/>
                {report.analysisReport}
            </CardContent>
            <Box textAlign='center' sx={{mb: 2}}>
                <Button sx={{mr: 2}} variant='contained'
                        component={Link} to={`/threats/${report.id}`}
                        color="secondary">View</Button>
                <Button sx={{mr: 2}} component={Link} to={`/threats/${report.id}`} variant="outlined" color="primary">
                    Edit
                </Button>
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