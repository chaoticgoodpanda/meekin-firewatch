import React from 'react';
import {Divider, ListItemIcon, ListItemText, MenuItem, MenuList, Paper, Typography} from "@mui/material";
import {FollowTheSigns, Group, Report} from "@mui/icons-material";

export default function ThreatFilters() {
    
    return (
        <Paper sx={{ width: 320, maxWidth: '100%' }}>
            <MenuList>
                <MenuItem>
                    <ListItemIcon>
                        <Report fontSize="small" />
                    </ListItemIcon>
                    <ListItemText>All Reports</ListItemText>
                    <Typography variant="body2" color="text.secondary">
                        1
                    </Typography>
                </MenuItem>
                <MenuItem>
                    <ListItemIcon>
                        <FollowTheSigns fontSize="small" />
                    </ListItemIcon>
                    <ListItemText>Reports I'm Following</ListItemText>
                    <Typography variant="body2" color="text.secondary">
                        2
                    </Typography>
                </MenuItem>
                <MenuItem>
                    <ListItemIcon>
                        <Group fontSize="small" />
                    </ListItemIcon>
                    <ListItemText>Users Following Me</ListItemText>
                    <Typography variant="body2" color="text.secondary">
                        3
                    </Typography>
                </MenuItem>
                <Divider />
                {/*<StaticDatePickerDemo />*/}
            </MenuList>
        </Paper>
    )
}