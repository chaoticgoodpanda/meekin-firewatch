import React from 'react';
import {Grid} from "@mui/material";
import ThreatList from "./ThreatList";

export default function ThreatDashboard() {
    return (
        <Grid container spacing={4}>
            <Grid item md={10}>
                <ThreatList />
            </Grid>
            <Grid item md={2}>
                <h2>Right Column</h2>
            </Grid>
        </Grid>
    )
}