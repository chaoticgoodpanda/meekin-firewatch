import React from 'react';
import axios from 'axios';
import {Box, Button, Typography} from "@mui/material";

export default function TestErrors() {
    const baseUrl = 'https://localhost:5001/api/'

    function handleNotFound() {
        axios.get(baseUrl + 'buggy/not-found').catch(err => console.log(err.response));
    }

    function handleBadRequest() {
        axios.get(baseUrl + 'buggy/bad-request').catch(err => console.log(err.response));
    }

    function handleServerError() {
        axios.get(baseUrl + 'buggy/server-error').catch(err => console.log(err.response));
    }

    function handleUnauthorised() {
        axios.get(baseUrl + 'buggy/unauthorized').catch(err => console.log(err.response));
    }

    function handleBadGuid() {
        axios.get(baseUrl + 'reports/notaguid').catch(err => console.log(err.response));
    }

    function handleValidationError() {
        axios.post(baseUrl + 'reports', {}).catch(err => console.log(err.response));
    }

    return (
        <>
            <Typography variant='h1'>Test error component</Typography>
            <Box>
                <Button onClick={handleNotFound}>Not Found</Button>
                <Button onClick={handleBadRequest}>Bad Request</Button>
                <Button onClick={handleValidationError}>Validation Error</Button>
                <Button onClick={handleServerError}>Server Error</Button>
                <Button onClick={handleUnauthorised}>Unauthorized</Button>
                <Button onClick={handleBadGuid}>Bad Guid</Button>
            </Box>
        </>
    )
}
