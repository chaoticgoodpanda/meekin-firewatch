import { observer } from 'mobx-react-lite';
import React from 'react'
import {PostLabeling} from "../../../app/models/postLabeling";
import {Box, Grid, Typography} from "@mui/material";
import {DateRange, EventNote, Language} from "@mui/icons-material";


interface Props {
    report: PostLabeling;
}

export default observer(function ThreatDetailedInfo({report}: Props) {
    return (
        <>
            <Box>
            <Grid container spacing={6}>
                <Grid item xs={1}>
                    <EventNote />
                </Grid>
                <Grid item xs={12}>
                    <Typography variant='body1' sx={{mb: 3}}><a target="_blank" rel="noopener noreferrer" href={report.originalPostUrl}>{report.originalPostUrl}</a></Typography>
                    <Typography variant='h4' color='primary' sx={{mb: 3}}>{report.analysisReport}</Typography>
                </Grid>
            </Grid>
        </Box>
            <Box>
            <Grid>
                <Grid item xs={1}>
                    <DateRange/>
                </Grid>
                <Grid item xs={12}>
                        <span>
                            {report.analysisDate}
                        </span>
                </Grid>
            </Grid>
        </Box>
            <Box>
            <Grid >
                <Grid item xs={1}>
                    <Language/>
                </Grid>
                <Grid item xs={11}>
                    <span>{report.country}, {report.language}</span>
                </Grid>
            </Grid>
        </Box>
        </>
    )
})