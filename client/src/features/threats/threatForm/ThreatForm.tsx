import React, {useState} from 'react';
import {Box, Button, Card, CardHeader, TextField, Typography} from "@mui/material";
import {Segment} from "@mui/icons-material";
import {history} from "../../../index";
import {PostLabeling} from "../../../app/models/postLabeling";
import {RabatCountry} from "../../../app/models/rabatCountry";
import {RabatSpeaker} from "../../../app/models/rabatSpeaker";
import {RabatOffensive} from "../../../app/models/rabatOffensive";
import {RabatJustifications} from "../../../app/models/rabatJustifications";
import {RabatIntent} from "../../../app/models/rabatIntent";

interface Props {
    report: PostLabeling | undefined;
    closeForm: () => void;
}

// {report: selectedReport, closeForm}

export default function ThreatForm() {
    
    // const initialState = selectedReport ?? {
    //     id: '',
    //     organizationId: '',
    //     userId: '',
    //     postId: '',
    //     platformId: '',
    //     facebookGuid: '',
    //     country: '',
    //     speaker: '',
    //     offensive: '',
    //     isDangerous: '',
    //     justifications: '',
    //     rabatVirality: '',
    //     intent: '',
    //     rabatLikelihoodHarm: '',
    //     language: '',
    //     offensiveContent: '',
    //     humanTarget: '',
    //     facebookDecision: '',
    //     createdDate: '',
    //     decisionDate: '',
    //     accessTime: '',
    //     analysisReport: '',
    //     summaryAnalysis: '',
    //     analysisDate: ''
    // }
    
    // const [report, setReport] = useState(initialState);
    
    // function handleSubmit() {
    //     console.log(report);
    // }
    
    return (
        <>
            <Box
                component="form"
                sx={{
                    '& > :not(style)': { m: 1, width: '60ch' },
                }}
                noValidate
                autoComplete="on"
            >
                <TextField id="outlined-basic" label="Report title" variant="outlined" />
                <TextField id="filled-multiline-flexible" label="Analysis" variant="filled"
                           multiline rows={8}
                />
            </Box>
            <Button sx={{ml: 1, mt: 1}} type='submit' onClick={() => history.push('/catalog')} color="warning" variant="contained">Submit Report</Button>
        </>
          
    )
    
}