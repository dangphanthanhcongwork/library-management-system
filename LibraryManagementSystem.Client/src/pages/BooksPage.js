// BookPage.js
import React, { useState } from 'react';
import { Typography, Grid, Card, CardContent, CardActions, IconButton, Container, Box, Dialog, DialogTitle, DialogContent, DialogActions, Button, TextField } from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import InfoIcon from '@mui/icons-material/Info';
import Layout from '../components/Layout';

function BookPage() {
    // Dummy data for books
    const [books, setBooks] = useState([
        { id: 1, title: 'Book 1', author: 'Author 1', description: 'Description 1' },
        { id: 2, title: 'Book 2', author: 'Author 2', description: 'Description 2' },
        { id: 3, title: 'Book 3', author: 'Author 3', description: 'Description 3' },
    ]);

    // State for Add/Edit Book Dialog
    const [openDialog, setOpenDialog] = useState(false);
    const [actionType, setActionType] = useState(''); // 'add' or 'edit'
    const [selectedBook, setSelectedBook] = useState(null);
    const [editedBook, setEditedBook] = useState({ id: '', title: '', author: '', description: '' });

    // Functions to handle dialog open and close
    const handleOpenDialog = (action, book = null) => {
        setActionType(action);
        setSelectedBook(book);
        if (action === 'edit' && book) {
            setEditedBook(book);
        } else {
            setEditedBook({ id: '', title: '', author: '', description: '' });
        }
        setOpenDialog(true);
    };

    const handleCloseDialog = () => {
        setOpenDialog(false);
    };

    // Functions to handle book management
    const handleDelete = (id) => {
        setBooks(books.filter(book => book.id !== id));
    };

    const handleBorrow = (id) => {
        // Handle borrow logic
    };

    const handleDetails = (id) => {
        // Handle details logic
    };

    const handleEdit = (book) => {
        handleOpenDialog('edit', book);
    };

    const handleAdd = () => {
        handleOpenDialog('add');
    };

    const handleSave = () => {
        if (actionType === 'add') {
            setBooks([...books, { id: books.length + 1, ...editedBook }]);
        } else if (actionType === 'edit' && selectedBook) {
            setBooks(books.map(book => book.id === selectedBook.id ? editedBook : book));
        }
        handleCloseDialog();
    };

    return (
        <Layout>
            <Container>
                <Typography variant="h3" gutterBottom>Books</Typography>
                <IconButton color="primary" aria-label="add request" onClick={handleAdd}>
                    <AddIcon fontSize="large" />
                </IconButton>
                <Box sx={{ textAlign: 'center', mt: 2 }}>
                </Box>
                <Grid container spacing={2}>
                    {books.map((book) => (
                        <Grid item xs={12} sm={6} md={4} lg={3} key={book.id}>
                            <Card variant="outlined">
                                <CardContent>
                                    <Typography variant="h6">{book.title}</Typography>
                                    <Typography variant="subtitle1">Author: {book.author}</Typography>
                                    <Typography variant="body2" color="textSecondary" component="p">
                                        {book.description}
                                    </Typography>
                                </CardContent>
                                <CardActions>
                                    <IconButton size="small" onClick={() => handleDetails(book.id)} aria-label="details">
                                        <InfoIcon />
                                    </IconButton>
                                    <IconButton size="small" onClick={() => handleEdit(book)} aria-label="edit">
                                        <EditIcon />
                                    </IconButton>
                                    <IconButton size="small" onClick={() => handleDelete(book.id)} aria-label="delete">
                                        <DeleteIcon />
                                    </IconButton>
                                    <IconButton size="small" onClick={() => handleBorrow(book.id)} aria-label="borrow">
                                        <AddIcon />
                                    </IconButton>
                                </CardActions>
                            </Card>
                        </Grid>
                    ))}
                </Grid>
            </Container>

            {/* Add/Edit Book Dialog */}
            <Dialog open={openDialog} onClose={handleCloseDialog}>
                <DialogTitle>{actionType === 'add' ? 'Add New Book' : 'Edit Book'}</DialogTitle>
                <DialogContent>
                    <TextField
                        autoFocus
                        margin="dense"
                        label="Title"
                        fullWidth
                        value={editedBook.title}
                        onChange={(e) => setEditedBook({ ...editedBook, title: e.target.value })}
                    />
                    <TextField
                        margin="dense"
                        label="Author"
                        fullWidth
                        value={editedBook.author}
                        onChange={(e) => setEditedBook({ ...editedBook, author: e.target.value })}
                    />
                    <TextField
                        margin="dense"
                        label="Description"
                        fullWidth
                        value={editedBook.description}
                        onChange={(e) => setEditedBook({ ...editedBook, description: e.target.value })}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseDialog}>Cancel</Button>
                    <Button onClick={handleSave}>{actionType === 'add' ? 'Add' : 'Save'}</Button>
                </DialogActions>
            </Dialog>
        </Layout>
    );
}

export default BookPage;
