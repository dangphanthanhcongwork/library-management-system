// Footer.js
import React from 'react';
import { AppBar, Toolbar, Typography } from '@mui/material';

const Footer = () => {
    return (
        <AppBar position="static" color="primary" style={{ marginTop: 'auto' }}>
            <Toolbar>
                <Typography variant="body1">
                    © {new Date().getFullYear()} Library Management System
                </Typography>
            </Toolbar>
        </AppBar>
    );
};

export default Footer;