import {Button, Fade, Menu, MenuItem} from "@mui/material";
import React from "react";
import {useStore} from "../stores/store";
import {observer} from "mobx-react-lite";

export default observer(function SignedInMenu() {
    const {userStore: {user, logout}} = useStore();
    const [anchorEl, setAnchorEl] = React.useState(null);
    const open = Boolean(anchorEl);
    const handleClick = (event: any) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };

    return (
        <>
            <Button
                onClick={handleClick}
                sx={{typography: 'h6'}}
            >
                {user?.email}
            </Button>
            <Menu
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                TransitionComponent={Fade}
            >
                <MenuItem onClick={handleClose}>Profile</MenuItem>
                <MenuItem onClick={handleClose}>My reports</MenuItem>
                <MenuItem onClick={() => logout()}>Logout</MenuItem>
            </Menu>
        </>
    );
})