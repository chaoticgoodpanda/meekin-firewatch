import {Button, Container, Typography} from "@mui/material";
import React from "react";
import {useStore} from "../../app/stores/store";
import {Link} from "react-router-dom";

export default function HomePage() {
    const {userStore} = useStore();
    return (
        <Container sx={{mt: '7em'}}>
            <Typography variant='h2'>
            Home
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
                <Button component={Link} to={'/login'} variant='contained' size='large'>
                    Login
                </Button>
            )}

        </Container>
    )
}