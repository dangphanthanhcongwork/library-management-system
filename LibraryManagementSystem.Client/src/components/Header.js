// Header.js
import React from 'react';
import { AppBar, Toolbar, Typography } from '@mui/material';

const Header = () => {
    return (
        <AppBar position="static" color="primary">
            <Toolbar>
                <Typography variant="h6">
                    Library Management System
                </Typography>
            </Toolbar>
        </AppBar>
    );
};

export default Header;
