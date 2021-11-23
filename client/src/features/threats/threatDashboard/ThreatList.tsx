import {Box, Button, Card, CardContent, CardHeader, CardMedia, Grid, List, ListItem} from '@mui/material';
import React, {useState} from 'react';
import ThreatListItem from "./ThreatListItem";
import {useStore} from "../../../app/stores/store";
import {Link} from "react-router-dom";
import IconButton from "@mui/material/IconButton";
import MoreVertIcon from "@mui/icons-material/MoreVert";

export default function ThreatList() {
    const {reportStore} = useStore();
    const {reportsByDate, postsByDate, selectedPost, editMode} = reportStore;
    
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
                            <Button variant='contained' component={Link} to={`/catalog/${report.facebookGuid}`} color="secondary">View</Button>&nbsp;&nbsp;&nbsp;
                            <Button variant="outlined" color="primary">
                                Edit
                            </Button> &nbsp;&nbsp;&nbsp;
                            <Button variant="outlined" color="error">
                                Delete
                            </Button>
                        </Box>
                    </Card>
                    ))}
            </Grid>
        </Grid>
        
    )
}