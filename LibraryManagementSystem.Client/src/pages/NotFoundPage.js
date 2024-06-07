// NotFoundPage.js
import React from 'react';
import { Typography, Container, Box } from '@mui/material';
import Layout from '../components/Layout';

const NotFoundPage = () => {
    return (
        <Layout>
            <Container>
                <Box sx={{ textAlign: 'center', mt: 4 }}>
                    <Typography variant="h3" gutterBottom>
                        404 Not Found
                    </Typography>
                    <Typography variant="body1">
                        The page you're looking for does not exist.
                    </Typography>
                </Box>
            </Container>
        </Layout>
    );
};

export default NotFoundPage;
