import React, {useEffect} from 'react';
import {Grid} from "@mui/material";
import ThreatList from "./ThreatList";
import {useStore} from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import ThreatDetails from "./ThreatDetails";

export default function ThreatDashboard() {
    const {reportStore} = useStore();
    const {reportsByDate, loadingInitial, deleteReport, openReportForm, closeReportForm, editMode, 
        selectReport, selectedReport, loadPost, selectedPost} = reportStore;

    // another useEffect, this time for loading the reports for the posts
    useEffect( () => {
        reportStore.loadReports();
    }, [reportStore]);
    

    if (loadingInitial) return <LoadingComponent message='Loading reports...' />;
    
    return (
        <>
            <Grid container spacing={4}>
                <Grid item xs={8}>
                    <ThreatList/>
                </Grid>
                <Grid item xs={4}>
                    {selectedReport && !editMode && 
                    <ThreatDetails
                    />}
                </Grid>
            </Grid>
        </>

    )
}

// {editMode &&
// <ThreatForm
//     deleteReport={deleteReport}
//     post={selectedPost}
// />}