import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import {Link, useHistory} from "react-router-dom";

import Image from '../../maria_ressa.jpg';
import agent from "../../app/api/agent";
import {FieldValues, useForm} from 'react-hook-form';
import {LoadingButton} from "@mui/lab";
import {useStore} from "../../app/stores/store";
import {observer} from "mobx-react-lite";
import {useState} from "react";
import {Alert, AlertTitle, List, ListItem, ListItemText} from "@mui/material";
import {toast} from "react-toastify";


export default observer(function RegisterForm() {
    const history = useHistory();
    // use of the userStore
    const {userStore} = useStore();
    const {register, handleSubmit, setError, formState: {isSubmitting, errors, isValid}} = useForm({
        mode: 'all'
    });

    async function submitForm(data: any) {
        try {
            await userStore.register(data);
            toast.success('Registration successful! You can now login.');
            history.push('/login');
        } catch (error) {
            handleApiErrors(error);
        }

    }
    
    function handleApiErrors(errors: any) {
        if (errors) {
            errors.forEach((error: string) => {
                if (error.includes('Password')) {
                    setError('password', {message: error})
                } else if (error.includes('Email')) {
                        setError('email', {message: error})
                } else if (error.includes('Username')) {
                    setError('username', {message: error})
                }
            });
        }
    }

    return (
        <Grid container component={Paper} sx={{ height: '100vh' }}>
            <Grid
                item
                xs={false}
                sm={4}
                md={7}
                sx={{
                    backgroundImage: `url(${Image})`,
                    backgroundRepeat: 'no-repeat',
                    backgroundColor: (t) =>
                        t.palette.mode === 'light' ? t.palette.grey[50] : t.palette.grey[900],
                    backgroundSize: 'auto',
                    backgroundPosition: 'center',
                }}
            />
            <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
                <Box
                    sx={{
                        my: 8,
                        mx: 4,
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                    }}
                >
                    <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Register
                    </Typography>
                    <Box component="form" noValidate onSubmit={handleSubmit(submitForm)} sx={{ mt: 1 }}>
                        <TextField
                            margin="normal"
                            fullWidth
                            label="Your Full Name"
                            autoComplete="displayName"
                            autoFocus
                            {...register('displayName', {required: 'Please enter your full name.'})}
                            error={!!errors.displayName}
                            helperText={errors?.displayName?.message}
                        />
                        <TextField
                            margin="normal"
                            fullWidth
                            label="Your Organization/Company"
                            autoComplete="organization"
                            autoFocus
                            {...register('organization', {required: 'Please enter your organization\'s name.'})}
                            error={!!errors.organization}
                            helperText={errors?.organization?.message}
                        />
                        <TextField
                            margin="normal"
                            fullWidth
                            label="Username"
                            autoComplete="username"
                            {...register('username', {required: 'Please enter a username.'})}
                            error={!!errors.username}
                            helperText={errors?.username?.message}
                        />
                        <TextField
                            margin="normal"
                            fullWidth
                            label="Email Address"
                            autoComplete="email"
                            autoFocus
                            {...register('email', {
                                required: 'Please enter a valid email.',
                                pattern: {
                                    // use two forward slashes and insert the reset between them
                                    value: /^\w+[\w-.]*@\w+((-\w+)|(\w*))\.[a-z]{2,3}$/,
                                    message: 'Not a valid email address.'
                                }})}
                            error={!!errors.email}
                            helperText={errors?.email?.message}
                        />
                        <TextField
                            margin="normal"
                            fullWidth
                            label="Password"
                            type="password"
                            autoComplete="current-password"
                            {...register('password', {
                                required: 'Password is required.',
                                pattern: {
                                    value: /(?=^.{6,}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$/,
                                    message: 'Password requires 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be at least 6 characters.'
                                }})}
                            error={!!errors.password}
                            helperText={errors?.password?.message}
                        />
                        <FormControlLabel
                            control={<Checkbox value="remember" color="primary" />}
                            label="Remember me"
                        />
                        <LoadingButton
                            loading={isSubmitting}
                            disabled={!isValid}
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                        >
                            Register
                        </LoadingButton>
                        <Grid container>
                            <Grid item xs>
                                <Link to='/login' style={{color: 'white'}} >
                                    Forgot password?
                                </Link>
                            </Grid>
                            <Grid item>
                                <Link to='/login' style={{color: 'white'}}>
                                    {"Already have an account? Sign In"}
                                </Link>
                            </Grid>
                        </Grid>
                    </Box>
                </Box>
            </Grid>
        </Grid>

    );
})
