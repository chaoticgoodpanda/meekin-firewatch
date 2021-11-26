import {Grid, Typography} from '@mui/material';
import {useStore} from "../../../app/stores/store";
import {observer} from "mobx-react-lite";
import ThreatListItem from "./ThreatListItem";
import {Fragment} from "react";

export default observer(function ThreatList() {
    const {reportStore} = useStore();
    const {groupedReports} = reportStore;
    
    
    return (
        <>
            {groupedReports.map(([group, reports]) => (
                <Fragment key={group}>
                    <Typography variant='h6' color='teal'>
                        {group}
                    </Typography>
                    <Grid container spacing={2}>
                        <Grid item md={10}>
                            {reports.map((report) => (
                                <ThreatListItem key={report.id} report={report} />
                            ))}
                        </Grid>
                    </Grid>
                </Fragment>
            ))}
        </>

        
    )
})
