import {Box, Button, Container, Divider, Paper, Typography} from "@mui/material";
import {useHistory} from "react-router-dom";
import {useStore} from "../stores/store";
import {observer} from "mobx-react-lite";

export default observer(function ServerError() {
    const {commonStore} = useStore();
    // from React Router <Router>
    const history = useHistory();
    // const {state} = useLocation<any>();
    return (
        <Container component={Paper}>
            <Typography variant='h3' color='error' gutterBottom>{commonStore.error?.message}</Typography>
            <Divider />
            {commonStore.error?.details && 
                <Box>
                    <Typography variant='h4'>Stack trace</Typography>
                    <code style={{marginTop: '10px'}}>{commonStore.error.details}</code>
                </Box>
                
            }
            <Button onClick={() => history.push('/catalog')}>Go back to the Catalog</Button>
            
        </Container>
    )
})