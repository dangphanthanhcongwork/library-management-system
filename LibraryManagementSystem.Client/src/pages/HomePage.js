// HomePage.js
import React from 'react';
import { Typography, Container, Box } from '@mui/material';
import Layout from '../components/Layout';

const HomePage = () => {
    return (
        <Layout>
            <Container>
                <Box sx={{ textAlign: 'center', mt: 4 }}>
                    <Typography variant="h3" gutterBottom>
                        Welcome to the Library Management System
                    </Typography>
                    <Typography variant="body1" sx={{ mt: 2 }}>
                        Explore our collection and manage your books efficiently.
                    </Typography>
                </Box>
            </Container>
        </Layout>
    );
};

export default HomePage;
