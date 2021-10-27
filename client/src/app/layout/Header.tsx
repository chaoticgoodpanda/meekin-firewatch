import {AppBar, IconButton, Switch, Toolbar, Typography} from "@mui/material";
import MenuIcon from '@mui/icons-material/Menu';


interface Props {
    darkMode: boolean;
    handleThemeChange: () => void;
}

export default function Header({darkMode, handleThemeChange}: Props) {
    return (
        <AppBar position ='static' sx={{mb: 4}}>
            <Toolbar>
                <IconButton
                    size="large"
                    edge="start"
                    color="inherit"
                    aria-label="open drawer"
                    sx={{ mr: 2 }}
                >
                    <MenuIcon />
                </IconButton>
                <Typography variant='h6'>
                    MEEKIN FIREWATCH
                </Typography>
                <Switch checked={darkMode} onChange={handleThemeChange} color="secondary" name="Dark mode"/>
            </Toolbar>
        </AppBar>
    )
}