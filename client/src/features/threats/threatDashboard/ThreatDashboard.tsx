import React, {useEffect} from 'react';
import {Grid, List, ListItem} from "@mui/material";
import ThreatList from "./ThreatList";
import {useStore} from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";

export default function ThreatDashboard() {
    const {reportStore} = useStore();
    const {reportsByDate, loadingInitial} = reportStore;
    

    // another useEffect, this time for loading the reports for the posts
    useEffect( () => {
        reportStore.loadReports();
    }, [reportStore]);

    if (loadingInitial) return <LoadingComponent message='Loading reports...' />;
    
    return (
        <Grid container spacing={4}>
            <Grid item md={10}>
                <ThreatList />
            </Grid>
        </Grid>
    )
}