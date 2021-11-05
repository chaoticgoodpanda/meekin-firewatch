import React, {useState} from 'react';
import Catalog from "../../features/catalog/Catalog";
import {Container, createTheme, CssBaseline, ThemeProvider} from "@mui/material";
import Header from "./Header";
import {Route, Switch} from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import PostDetails from "../../features/catalog/PostDetails";
import AboutPage from "../../features/about/AboutPage";
import ContactPage from "../../features/contact/ContactPage";
import ThreatPage from "../../features/threats/ThreatPage";
import {ToastContainer} from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import ServerError from "../errors/ServerError";
import NotFound from "../errors/NotFound";
import Sandbox from "../../features/sandbox/Sandbox";
import ThreatDashboard from "../../features/threats/threatDashboard/ThreatDashboard";


function App() {
    // create a dark theme, with mode switching capability
    const [darkMode, setDarkMode] = useState(true);
    const paletteType = darkMode ? 'dark' : 'light';
    const theme = createTheme({
        palette: {
            mode: paletteType,
            background: {
                default: (paletteType === 'light' ? '#eaeaea' : '#121212')
            }
        }
    })
    
    // toggles between dark and light mode
    function handleThemeChange() {
        setDarkMode(!darkMode);
    }
    
  return (
    <ThemeProvider theme={theme}>
        <ToastContainer position='bottom-right' hideProgressBar />
        <CssBaseline />
        <Header darkMode={darkMode} handleThemeChange={handleThemeChange}/>
        <Container>
            <Switch>
                <Route exact path='/' component={HomePage}/>
                <Route exact path='/catalog' component={Catalog}/>
                <Route exact path='/sandbox' component={Sandbox}/>
                <Route path='/catalog/:id' component={PostDetails}/>
                <Route path='/about' component={AboutPage}/>
                <Route path='/contact' component={ContactPage}/>
                <Route path='/threats' component={ThreatDashboard} />
                <Route path='/server-error' component={ServerError} />
                <Route component={NotFound} />
            </Switch>
        </Container>
        

    </ThemeProvider>
  );
}

export default App;
