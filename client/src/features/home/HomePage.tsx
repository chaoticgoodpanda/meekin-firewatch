import {Button, Container, Typography} from "@mui/material";
import React from "react";
import {useStore} from "../../app/stores/store";
import {Link} from "react-router-dom";
import LoginForm from "../account/LoginForm";
import RegisterForm from "../account/RegisterForm";

export default function HomePage() {
    const {userStore, modalStore} = useStore();
    return (
        <Container sx={{mt: '7em'}}>
            <Typography variant='h2'>
            Meekin Firewatch Home
            </Typography>
            {userStore.isLoggedIn ? (
                <>
                    <Typography variant='h3'>
                        Welcome to Meekin Firewatch!
                    </Typography>
                    <Button component={Link} to={'/catalog'} variant='contained' size='large'>
                        Go to the Catalog!
                    </Button>
                </>
            ) : (
                <>
                    <Button variant='contained' size='large' onClick={() => modalStore.openModal(<LoginForm/>)} sx={{mr: 3}} color='secondary'>
                    Login
                </Button>
                <Button variant='contained' size='large' onClick={() => modalStore.openModal(<RegisterForm/>)}>
                    Register
                </Button>
                </>
            )}

        </Container>
    )
}