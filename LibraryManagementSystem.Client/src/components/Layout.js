// Layout.js
import React from 'react';
import Header from './Header';
import Footer from './Footer';
import Navbar from './Navbar';
import { Container } from '@mui/material';

const Layout = ({ children }) => {
    return (
        <div style={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
            <Header />
            <Navbar />
            <Container maxWidth="lg" style={{ flex: 1 }}>
                {children}
            </Container>
            <Footer />
        </div>
    );
};

export default Layout;
