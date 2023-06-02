import { Button, Dialog, DialogTitle, DialogContent, DialogContentText, TextField, DialogActions } from '@mui/material';
import React, { useState } from 'react';

function FormModal({ title }: Props) {
    const [open, setOpen] = useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    return (
        <>
            <DialogTitle>Create Product</DialogTitle>
            <DialogContent>
                <TextField
                    autoFocus
                    margin="dense"
                    id="name"
                    label="Email Address"
                    type="email"
                    fullWidth
                    variant="standard"
                />
            </DialogContent>
            <DialogActions>
                {/*<Button onClick={() => setModalOpen(false)}>Cancel</Button>*/}
                {/*<Button onClick={() => setModalOpen(false)}>Ok</Button>*/}
            </DialogActions>  
        </>
    );
}

type Props = {
    title: string,
}

export default FormModal;