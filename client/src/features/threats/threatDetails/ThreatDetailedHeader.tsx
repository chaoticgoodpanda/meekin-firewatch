import { observer } from 'mobx-react-lite';
import React from 'react'
import {PostLabeling} from "../../../app/models/postLabeling";
import {Box, Button, Card, CardHeader, CardMedia, styled, Typography} from "@mui/material";
import {Link} from "react-router-dom";

const ReportImageStyleBox = styled(Box)({
    filter: 'brightness(30%)'
});

const ReportImageTextStyleCardMedia = styled(CardMedia)({
    position: 'absolute',
    bottom: '5%',
    left: '5%',
    width: '100%',
    height: 'auto',
    color: 'white'
});

interface Props {
    report: PostLabeling;
}

export default observer (function ThreatDetailedHeader({report}: Props) {
    return (
        <>
            <Box>
                <ReportImageStyleBox>
                    <Card sx={{padding: '0'}}>
                        <ReportImageTextStyleCardMedia src='/public/favicon.ico' />
                        <CardHeader
                            size='huge'
                            content={report.summaryAnalysis}
                            color='warning'/>
                        <p>{report.analysisDate}</p>
                        <Typography variant='h3' color='warning'>{report.summaryAnalysis}</Typography>
                        <p>
                            Hosted by <strong>Bob</strong>
                        </p>
                    </Card>
                </ReportImageStyleBox>
            </Box>
            <Box>
                <Button variant='contained' color='secondary'>Follow Report</Button>
                <Button variant='contained' sx={{ml: 2}} >Unfollow Report</Button>
                <Button variant='outlined' color='warning' sx={{ml: 2}}>
                    Manage Report
                </Button>
                <Button color='primary' sx={{ml: 2}} component={Link} to={`/threats`} >Back to Threats</Button>
            </Box></>
    )
})