import {Grid} from '@mui/material';
import {useStore} from "../../../app/stores/store";
import {observer} from "mobx-react-lite";
import ThreatListItem from "./ThreatListItem";

export default observer(function ThreatList() {
    const {reportStore} = useStore();
    const {reportsByDate} = reportStore;
    
    
    return (
        <Grid container spacing={2}>
            <Grid item md={10}>
                {reportsByDate.map((report) => (
                    <ThreatListItem key={report.id} report={report} />
                    ))}
            </Grid>
        </Grid>
        
    )
})
