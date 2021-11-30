import React, {useEffect} from 'react';
import {Grid} from "@mui/material";
import ThreatList from "./ThreatList";
import {useStore} from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import ThreatFilters from "./ThreatFilters";

export default function ThreatDashboard() {
    const {reportStore} = useStore();
    const {reportsByDate, loadingInitial, loadReports, reportRegistry} = reportStore;

    // another useEffect, this time for loading the reports for the posts
    useEffect( () => {
        if (reportRegistry.size <= 1) loadReports();
    }, [reportRegistry.size, loadReports]);
    

    if (loadingInitial) return <LoadingComponent message='Loading reports...' />;
    
    return (
        <>
            <Grid container spacing={4}>
                <Grid item xs={8}>
                    <ThreatList/>
                </Grid>
                <Grid item xs={4}>
                    <ThreatFilters />
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