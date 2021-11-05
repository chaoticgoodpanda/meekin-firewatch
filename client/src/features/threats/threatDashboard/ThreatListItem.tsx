import React from 'react';
import {Segment} from "@mui/icons-material";
import {Avatar, AvatarGroup, Box, Button, Card, CardContent, CardHeader, CardMedia, ImageList} from "@mui/material";
import Typography from "@mui/material/Typography";
import {Link} from "react-router-dom";
import ThreatListAttendee from "./ThreatListAttendee";

export default function ThreatListItem() {
    return (
        <Card>
            <CardHeader avatar={
                <AvatarGroup>
                    <Avatar sx={{ bgcolor: 'secondary.main' }}>
                        Name
                    </Avatar>
                </AvatarGroup>
            } title="User" subheader="2021-01-01"/>
            <CardMedia image="image" />
            <CardContent>
                <Typography variant="body2" color="text.secondary">
                    <strong>Threat Title</strong>
                    <br/><br/>
                    Threat Message
                </Typography>
            </CardContent>
            <ImageList sx={{ width: 500, height: 80 }} cols={3} rowHeight={150}>
                <ThreatListAttendee />
                <ThreatListAttendee />
                <ThreatListAttendee />
            </ImageList>
            <Box textAlign='center' sx={{mb: 2}}>
                <Button color="secondary">Comment</Button>&nbsp;&nbsp;&nbsp;
                <Button variant="contained" color="success">
                    Follow
                </Button>&nbsp;&nbsp;&nbsp;
                <Button variant="outlined" color="error">
                    Save
                </Button>
            </Box>
            
        </Card>
    )
}