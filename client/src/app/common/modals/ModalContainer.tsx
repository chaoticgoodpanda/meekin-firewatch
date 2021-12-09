import React from 'react';
import {useStore} from "../../stores/store";
import {observer} from "mobx-react-lite";
import {Box, Modal} from "@mui/material";

const style = {
    width: 1000,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
};

export default observer(function ModalContainer() {
    const {modalStore} = useStore();
    

    return (
        <Modal open={modalStore.modal.open} onClose={modalStore.closeModal}>
            <Box sx={style}>
                {modalStore.modal.body!}
            </Box>
        </Modal>
    )
})