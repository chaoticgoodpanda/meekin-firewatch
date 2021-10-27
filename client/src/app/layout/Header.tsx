import {AppBar, IconButton, Toolbar, Typography} from "@mui/material";
import MenuIcon from '@mui/icons-material/Menu';
import {Search} from "@mui/icons-material";
import SearchIcon from '@mui/icons-material/Search';


export default function Header() {
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
                <Search>
                    <SearchIcon />
                </Search>
            </Toolbar>
        </AppBar>
    )
}