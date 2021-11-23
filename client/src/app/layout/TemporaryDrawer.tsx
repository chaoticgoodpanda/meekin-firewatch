import * as React from 'react';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import Button from '@mui/material/Button';
import PostDetails from "../../features/catalog/PostDetails";
import {useStore} from "../stores/store";
import {useParams} from "react-router-dom";
import {Post} from "../models/post";
import {observer} from "mobx-react-lite";
import {useEffect} from "react";

interface Props {
    post: Post;
    postId: string;
    cancelSelectPost: () => void;
}

type Anchor = 'right';

export default observer (function TemporaryDrawer({post, cancelSelectPost}: Props) {
    const {id} = useParams<{id: string}>();
    const {reportStore} = useStore();
    const {selectedPost, loadPost} = reportStore;

    useEffect(() => {
        if (id) loadPost(id);
    }, [id, loadPost])
    
    const [state, setState] = React.useState({
        top: false,
        left: false,
        bottom: false,
        right: false,
    });

    const toggleDrawer =
        (anchor: Anchor, open: boolean) =>
            (event: React.KeyboardEvent | React.MouseEvent) => {
                if (
                    event.type === 'keydown' &&
                    ((event as React.KeyboardEvent).key === 'Tab' ||
                        (event as React.KeyboardEvent).key === 'Shift')
                ) {
                    return;
                }

                setState({ ...state, [anchor]: open });
            };

    const list = (anchor: Anchor) => (
        <Box
            sx={{ width: 500 }}
            role="presentation"
            onClick={toggleDrawer(anchor, false)}
            onKeyDown={toggleDrawer(anchor, false)}
        >
            <PostDetails />
        </Box>
    );

    // useEffect(() => {
    //     if (id) loadPost(id);
    //     console.log(selectedPost);
    // }, [id, loadPost])

    return (
        <>
            {(['right'] as const).map((anchor) => (
                <React.Fragment key={anchor}>
                    <Button variant='contained' color='warning' onClick={toggleDrawer(anchor, true)}>View</Button>
                    <Drawer
                        anchor='right'
                        open={state[anchor]}
                        onClose={toggleDrawer(anchor, false)}
                    >
                        {list(anchor)}
                    </Drawer>
                </React.Fragment>
            ))}
        </>
    );
})
