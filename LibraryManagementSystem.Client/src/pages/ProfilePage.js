// ProfilePage.js
import React from 'react';
import { Typography, Box, Container } from '@mui/material';
import Layout from '../components/Layout';

const ProfilePage = () => {
    return (
        <Layout>
            <Container>
                <Box sx={{ maxWidth: 400, margin: 'auto', textAlign: 'center', mt: 4 }}>
                    <Typography variant="h3" gutterBottom>User Profile</Typography>
                    {/* Add user profile information */}
                    <Typography variant="body1">
                        Welcome, John Doe!
                    </Typography>
                </Box>
            </Container>
        </Layout>
    );
};

export default ProfilePage;
