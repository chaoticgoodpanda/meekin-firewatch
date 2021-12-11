import React, {useEffect, useState} from 'react';
import Catalog from "../../features/catalog/Catalog";
import {Container, createTheme, CssBaseline, ThemeProvider} from "@mui/material";
import Header from "./Header";
import {Route, Switch, useLocation} from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import PostDetails from "../../features/catalog/PostDetails";
import AboutPage from "../../features/about/AboutPage";
import ContactPage from "../../features/contact/ContactPage";
import {ToastContainer} from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import ServerError from "../errors/ServerError";
import NotFound from "../errors/NotFound";
import Sandbox from "../../features/sandbox/Sandbox";
import ThreatDashboard from "../../features/threats/threatDashboard/ThreatDashboard";
import ThreatForm from "../../features/threats/threatForm/ThreatForm";
import {observer} from "mobx-react-lite";
import ThreatDetails from "../../features/threats/threatDetails/ThreatDetails";
import TestErrors from "../errors/TestErrors";
import LoginForm from "../../features/account/LoginForm";
import {useStore} from "../stores/store";
import LoadingComponent from "./LoadingComponent";
import ModalContainer from "../common/modals/ModalContainer";
import RegisterForm from "../../features/account/RegisterForm";
import PrivateRoute from "./PrivateRoute";



function App() {
    const location = useLocation();
    const {commonStore, userStore} = useStore();
    
    useEffect(() => {
        // see if user is logged in
        if (commonStore.token) {
            userStore.getUser().finally(() => commonStore.setAppLoaded());
        } else {
            commonStore.setAppLoaded();
        }
    }, [commonStore, userStore]);

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
    
    if (!commonStore.appLoaded) return <LoadingComponent message='Loading app...' />
    
    // toggles between dark and light mode
    function handleThemeChange() {
        setDarkMode(!darkMode);
    }
    
  return (
    <ThemeProvider theme={theme}>
        <ToastContainer position='bottom-right' hideProgressBar />
        <ModalContainer />
        <CssBaseline />
        <Header darkMode={darkMode} handleThemeChange={handleThemeChange}/>
        <Route exact path='/' component={HomePage}/>
        <Route
            path={'/(.+)'}
            render={() => (
                <Container>
                    <Switch>
                        <PrivateRoute exact path='/catalog' component={Catalog}/>
                        <Route exact path='/sandbox' component={Sandbox}/>
                        <PrivateRoute key={location.key}  path='/catalog/:id' component={PostDetails}/>
                        <Route path='/about' component={AboutPage}/>
                        <Route path='/contact' component={ContactPage}/>
                        <Route path='/login' component={LoginForm}/>
                        <Route path='/register' component={RegisterForm}/>
                        <PrivateRoute exact path='/threats' component={ThreatDashboard} />
                        <PrivateRoute key={location.key}  path='/threats/:id' component={ThreatDetails} />
                        <PrivateRoute key={location.key} path={['/createReport', '/manage/:id']} component={ThreatForm} />
                        <Route path='/server-error' component={ServerError} />
                        <Route path='/errors' component={TestErrors} />
                        <Route component={NotFound} />
                    </Switch>
                </Container>
            )}
            />

        
        

    </ThemeProvider>
  );
}

// observer enables stores to observe components
export default observer(App);
