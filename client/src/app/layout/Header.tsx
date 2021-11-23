import {AppBar, Badge, Box, Button, IconButton, List, ListItem, Switch, Toolbar, Typography} from "@mui/material";
import MenuIcon from '@mui/icons-material/Menu';
import {Link, NavLink} from "react-router-dom";
import {Notifications, ShoppingCart} from "@mui/icons-material";
import {useStore} from "../stores/store";


interface Props {
    darkMode: boolean;
    handleThemeChange: () => void;
}

const midLinks = [
    {title: 'catalog', path: '/catalog'},
    {title: 'threats', path: '/threats'},
    {title: 'about', path: '/about'},
    {title: 'contact', path: '/contact'},
    {title: 'sandbox', path: '/sandbox'},
]

const rightLinks = [
    {title: 'login', path: '/login'},
    {title: 'register', path: '/register'},
]

const navStyles = {
    color: 'inherit',
    textDecoration: 'none',
    typography: 'h6',
    '&:hover': {
        color: 'secondary.main'
    },
    '&.active': {
        color: 'error.light'
    }
}

export default function Header({darkMode, handleThemeChange}: Props) {
    const {reportStore} = useStore();
    
    return (
        <AppBar position ='static' sx={{mb: 4}}>
            <Toolbar sx={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                <Box display='flex' sx={{alignItems: 'center'}}>
                    <IconButton
                        size="large"
                        edge="start"
                        color="inherit"
                        aria-label="open drawer"
                        sx={{ mr: 2 }}
                    >
                        <MenuIcon />
                    </IconButton>
                    <Typography variant='h6' color='warning.main' component={NavLink} to='/' sx={{textDecoration: 'none'}} exact>
                        Meekin Firewatch
                    </Typography>
                    <Switch checked={darkMode} onChange={handleThemeChange} color="secondary" name="Dark mode"/>
                    <Button onClick={() => reportStore.openReportForm()} sx={{ml: 1}} variant='contained' color='success'>Create Report</Button>
                </Box>
                
                <List sx={{display: 'flex'}}>
                    {midLinks.map(({title, path}) => (
                        <ListItem 
                            component={NavLink}
                            to={path}
                            key={path}
                            sx={navStyles}
                        >
                            {title.toUpperCase()}
                        </ListItem>
                    ))}
                </List>
                <Box display='flex' alignItems='center'>
                    <IconButton size='large' sx={{color: 'inherit'}}>
                        <Badge badgeContent={12} color='primary'>
                            <Notifications />
                        </Badge>
                    </IconButton>
                    <IconButton>
                        <Badge badgeContent={4} color='secondary'>
                            <ShoppingCart />
                        </Badge>
                    </IconButton>
                    <List sx={{display: 'flex'}}>
                        {rightLinks.map(({title, path}) => (
                            <ListItem
                                component={NavLink}
                                to={path}
                                key={path}
                                sx={navStyles}
                            >
                                {title.toUpperCase()}
                            </ListItem>
                        ))}
                    </List>
                </Box>
            </Toolbar>
        </AppBar>
    )
}