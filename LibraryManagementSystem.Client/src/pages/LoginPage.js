// LoginPage.js
import React from 'react';
import { Typography, Button, TextField, Box, Container } from '@mui/material';
import { Link } from 'react-router-dom';
import Layout from '../components/Layout';

const LoginPage = () => {
    return (
        <Layout>
            <Container>
                <Box sx={{ maxWidth: 400, margin: 'auto', textAlign: 'center', mt: 4 }}>
                    <Typography variant="h3" gutterBottom>Login</Typography>
                    <TextField label="Username" variant="outlined" fullWidth margin="normal" />
                    <TextField label="Password" variant="outlined" type="password" fullWidth margin="normal" />
                    <Button variant="contained" color="primary" fullWidth>
                        Login
                    </Button>
                    <Typography variant="body2" mt={2}>
                        Don't have an account? <Link to="/register">Register</Link>
                    </Typography>
                </Box>
            </Container>
        </Layout>
    );
};

export default LoginPage;
