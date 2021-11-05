import React, {useState} from 'react';
import {Box, Card, CardHeader, TextField, Typography} from "@mui/material";
import {Formik} from "formik";
import {useSelector} from "react-redux";

export default function ThreatForm() {

    // const initialValues = selectedEvent ?? {
    //     title: '',
    //     category: '',
    //     description: '',
    //     city: {
    //         address: '',
    //         latLng: null,
    //     },
    //     venue: {
    //         address: '',
    //         latLng: null,
    //     },
    //     date: '',
    // };
    
    return (
        <>
            <Typography variant='h2' sx={{mb: 5}}>
                Report a Threat
            </Typography>
            <Box
                component="form"
                sx={{
                    '& > :not(style)': { m: 1, width: '25ch' },
                }}
                noValidate
                autoComplete="on"
            >
                
                <TextField id="outlined-basic" label="Report title" variant="outlined" />
                <TextField id="filled-basic" label="Filled" variant="filled" />
                <TextField id="standard-basic" label="Standard" variant="standard" />
            </Box>
        </>
    )
    
}