// BookBorrowingPage.js
import React, { useState } from 'react';
import { Typography, Grid, Card, CardContent, CardActions, IconButton, Container, Dialog, DialogTitle, DialogContent, DialogActions, Button, TextField } from '@mui/material';
import CheckCircleIcon from '@mui/icons-material/CheckCircle';
import CancelIcon from '@mui/icons-material/Cancel';
import VisibilityIcon from '@mui/icons-material/Visibility';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import Layout from '../components/Layout';

function BookBorrowingPage() {
    // Dummy data for borrowing requests
    const [borrowingRequests, setBorrowingRequests] = useState([
        { id: 1, user: 'User 1', status: 'Pending', books: [{ id: 1, title: 'Book 1' }, { id: 2, title: 'Book 2' }] },
        { id: 2, user: 'User 2', status: 'Approved', books: [{ id: 3, title: 'Book 3' }] },
        { id: 3, user: 'User 3', status: 'Rejected', books: [{ id: 4, title: 'Book 4' }, { id: 5, title: 'Book 5' }] },
    ]);

    // State for Edit Borrowing Request Dialog
    const [openEditDialog, setOpenEditDialog] = useState(false);
    const [editedRequest, setEditedRequest] = useState(null);

    // Functions to handle dialog open and close
    const handleOpenEditDialog = (request) => {
        setEditedRequest(request);
        setOpenEditDialog(true);
    };

    const handleCloseEditDialog = () => {
        setOpenEditDialog(false);
    };

    // Functions to handle borrowing request management
    const handleEdit = (id) => {
        const requestToEdit = borrowingRequests.find(request => request.id === id);
        handleOpenEditDialog(requestToEdit);
    };

    const handleSaveEdit = () => {
        // Implement save edit logic here
        handleCloseEditDialog();
    };

    const handleDelete = (id) => {
        setBorrowingRequests(borrowingRequests.filter(request => request.id !== id));
    };

    const handleApprove = (id) => {
        setBorrowingRequests(borrowingRequests.map(request => request.id === id ? { ...request, status: 'Approved' } : request));
    };

    const handleReject = (id) => {
        setBorrowingRequests(borrowingRequests.map(request => request.id === id ? { ...request, status: 'Rejected' } : request));
    };

    return (
        <Layout>
            <Container>
                <Typography variant="h3" gutterBottom>Borrowing Requests</Typography>
                <Grid container spacing={3}>
                    {borrowingRequests.map((request) => (
                        <Grid item xs={12} sm={6} md={4} key={request.id}>
                            <Card elevation={3}>
                                <CardContent>
                                    <Typography variant="h6" gutterBottom>User: {request.user}</Typography>
                                    <Typography variant="body1" gutterBottom>Status: {request.status}</Typography>
                                    <Typography variant="body1" gutterBottom>Books:</Typography>
                                    <ul>
                                        {request.books.map((book) => (
                                            <li key={book.id}>{book.title}</li>
                                        ))}
                                    </ul>
                                </CardContent>
                                <CardActions>
                                    <IconButton size="small" onClick={() => handleEdit(request.id)} aria-label="edit">
                                        <EditIcon />
                                    </IconButton>
                                    <IconButton size="small" onClick={() => handleDelete(request.id)} aria-label="delete">
                                        <DeleteIcon />
                                    </IconButton>
                                    <IconButton size="small" onClick={() => handleApprove(request.id)} aria-label="approve">
                                        <CheckCircleIcon />
                                    </IconButton>
                                    <IconButton size="small" onClick={() => handleReject(request.id)} aria-label="reject">
                                        <CancelIcon />
                                    </IconButton>
                                </CardActions>
                            </Card>
                        </Grid>
                    ))}
                </Grid>
            </Container>

            {/* Edit Borrowing Request Dialog */}
            <Dialog open={openEditDialog} onClose={handleCloseEditDialog}>
                <DialogTitle>Edit Borrowing Request</DialogTitle>
                <DialogContent>
                    {/* Form fields for editing */}
                    {/* Example: <TextField label="User" value={editedRequest.user} onChange={(e) => setEditedRequest({ ...editedRequest, user: e.target.value })} /> */}
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseEditDialog}>Cancel</Button>
                    <Button onClick={handleSaveEdit}>Save</Button>
                </DialogActions>
            </Dialog>
        </Layout>
    );
}

export default BookBorrowingPage;
