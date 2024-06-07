// RegisterPage.js
import React from 'react';
import { Typography, Button, TextField, Box, Container } from '@mui/material';
import { Link } from 'react-router-dom';
import Layout from '../components/Layout';

const RegisterPage = () => {
    return (
        <Layout>
            <Container>
                <Box sx={{ maxWidth: 400, margin: 'auto', textAlign: 'center', mt: 4 }}>
                    <Typography variant="h3" gutterBottom>Register</Typography>
                    <TextField label="Username" variant="outlined" fullWidth margin="normal" />
                    <TextField label="Email" variant="outlined" type="email" fullWidth margin="normal" />
                    <TextField label="Password" variant="outlined" type="password" fullWidth margin="normal" />
                    <Button variant="contained" color="primary" fullWidth>
                        Register
                    </Button>
                    <Typography variant="body2" mt={2}>
                        Already have an account? <Link to="/login">Login</Link>
                    </Typography>
                </Box>
            </Container>
        </Layout>
    );
};

export default RegisterPage;
