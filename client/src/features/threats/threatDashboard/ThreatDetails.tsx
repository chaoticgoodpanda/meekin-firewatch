import {observer} from "mobx-react-lite";
import {Box, Button, Card, CardContent, CardHeader} from "@mui/material";
import {PostLabeling} from "../../../app/models/postLabeling";
import IconButton from "@mui/material/IconButton";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import React from "react";
import {Link} from "react-router-dom";

interface Props {
    report: PostLabeling;
}

export default observer(function ThreatDetails({report}: Props) {
    return (
        <Card>
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
                <a target="_blank" rel="noopener noreferrer" href={report.originalPostUrl}>{report.originalPostUrl}</a> <br/>
                {report.analysisReport}
            </CardContent>
            <Box>
                <Button sx={{mr: 2}} variant="outlined" color="primary">
                    Edit
                </Button>
                <Button variant="outlined" color="error">
                    Delete
                </Button>
            </Box>
        </Card>
    )
    
    
});