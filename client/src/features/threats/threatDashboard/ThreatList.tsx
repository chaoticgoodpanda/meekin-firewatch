import { Grid } from '@mui/material';
import React from 'react';
import ThreatListItem from "./ThreatListItem";

export default function ThreatList() {
    return (
        <Grid container spacing={2}>
            <Grid item md={10}>
                <ThreatListItem />
            </Grid>
            <Grid item md={10}>
                <ThreatListItem />
            </Grid>
            <Grid item md={10}>
                <ThreatListItem />
            </Grid>
            <Grid item md={10}>
                <ThreatListItem />
            </Grid>
            
            

        </Grid>
        
    )
}