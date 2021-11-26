import {Box, Button, Card, CardContent, CardHeader, CardMedia, Grid, List, ListItem} from '@mui/material';
import React, {SyntheticEvent, useState} from 'react';
import ThreatListItem from "./ThreatListItem";
import {useStore} from "../../../app/stores/store";
import {Link} from "react-router-dom";
import IconButton from "@mui/material/IconButton";
import MoreVertIcon from "@mui/icons-material/MoreVert";

export default function ThreatList() {
    const {reportStore} = useStore();
    const {reportsByDate, postsByDate, selectedPost, editMode, openReportForm, selectReport, deleteReport} = reportStore;
    const [target, setTarget] = useState('');
    
    function handleReportDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        setTarget(e.currentTarget.name);
        deleteReport(id);
    }
    
    return (
        <Grid container spacing={2}>
            <Grid item md={10}>
                {reportsByDate.map((report) => (
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
                            <Button sx={{mr: 2}} variant='contained' onClick={() => selectReport(report.id)} color="secondary">View</Button>
                            <Button sx={{mr: 2}} onClick={() => openReportForm(report.id)}  variant="outlined" color="primary">
                                Edit
                            </Button>
                            <Button variant="outlined" color="error"
                                name={report.id}
                                onClick={(e) => handleReportDelete(e, report.id)}
                            >
                                Delete
                            </Button>
                        </Box>
                    </Card>
                    ))}
            </Grid>
        </Grid>
        
    )
}

// component={Link} to={`/catalog/${report.facebookGuid}`}