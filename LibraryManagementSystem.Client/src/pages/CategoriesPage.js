// CategoryPage.js
import React, { useState } from 'react';
import { Typography, Grid, Card, CardContent, CardActions, IconButton, Container, Box, Dialog, DialogTitle, DialogContent, DialogActions, Button, TextField } from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import Layout from '../components/Layout';

function CategoriesPage() {
    // Dummy data for categories
    const [categories, setCategories] = useState(['Category 1', 'Category 2', 'Category 3']);

    // State for Add/Edit Category Dialog
    const [openDialog, setOpenDialog] = useState(false);
    const [actionType, setActionType] = useState(''); // 'add' or 'edit'
    const [selectedCategory, setSelectedCategory] = useState('');
    const [newCategory, setNewCategory] = useState('');

    // Functions to handle dialog open and close
    const handleOpenDialog = (action, category = '') => {
        setActionType(action);
        setSelectedCategory(category);
        setOpenDialog(true);
    };

    const handleCloseDialog = () => {
        setOpenDialog(false);
        setNewCategory('');
    };

    // Functions to handle category management
    const handleDelete = (category) => {
        setCategories(categories.filter(cat => cat !== category));
    };

    const handleEdit = (category) => {
        handleOpenDialog('edit', category);
    };

    const handleAdd = () => {
        handleOpenDialog('add');
    };

    const handleSave = () => {
        if (actionType === 'add') {
            setCategories([...categories, newCategory]);
        } else if (actionType === 'edit') {
            setCategories(categories.map(cat => cat === selectedCategory ? newCategory : cat));
        }
        handleCloseDialog();
    };

    return (
        <Layout>
            <Container>
                <Typography variant="h3" gutterBottom>Categories</Typography>
                <IconButton color="primary" aria-label="add request" onClick={handleAdd}>
                    <AddIcon fontSize="large" />
                </IconButton>
                <Box sx={{ textAlign: 'center', mt: 2 }}>
                </Box>
                <Grid container spacing={2}>
                    {categories.map((category, index) => (
                        <Grid item xs={12} sm={6} md={4} lg={3} key={index}>
                            <Card variant="outlined">
                                <CardContent>
                                    <Typography variant="h6">{category}</Typography>
                                </CardContent>
                                <CardActions>
                                    <IconButton size="small" onClick={() => handleEdit(category)} aria-label="edit">
                                        <EditIcon />
                                    </IconButton>
                                    <IconButton size="small" onClick={() => handleDelete(category)} aria-label="delete">
                                        <DeleteIcon />
                                    </IconButton>
                                </CardActions>
                            </Card>
                        </Grid>
                    ))}
                </Grid>
            </Container>

            {/* Add/Edit Category Dialog */}
            <Dialog open={openDialog} onClose={handleCloseDialog}>
                <DialogTitle>{actionType === 'add' ? 'Add New Category' : 'Edit Category'}</DialogTitle>
                <DialogContent>
                    <TextField
                        autoFocus
                        margin="dense"
                        label="Category Name"
                        fullWidth
                        value={newCategory}
                        onChange={(e) => setNewCategory(e.target.value)}
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

export default CategoriesPage;
