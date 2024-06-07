import axios from 'axios';

const API_BASE_URL = 'http://localhost:5288/api';

const apiService = axios.create({
    baseURL: API_BASE_URL,
    headers: {
        'Content-Type': 'application/json',
    },
});

// Authentication
export const login = (userData) => {
    return apiService.post('/api/auth/login', userData);
};

// Book Borrowings
export const getBookBorrowings = () => {
    return apiService.get('/api/book-borrowings');
};

export const getBookBorrowingById = (id) => {
    return apiService.get(`/api/book-borrowings/${id}`);
};

export const createBookBorrowing = (borrowingData) => {
    return apiService.post('/api/book-borrowings', borrowingData);
};

export const updateBookBorrowing = (id, borrowingData) => {
    return apiService.put(`/api/book-borrowings/${id}`, borrowingData);
};

export const deleteBookBorrowing = (id) => {
    return apiService.delete(`/api/book-borrowings/${id}`);
};

export const requestBookBorrowing = (requestData) => {
    return apiService.post('/api/book-borrowings/request', requestData);
};

export const approveBookBorrowing = (id) => {
    return apiService.put(`/api/book-borrowings/approve/${id}`);
};

// Books
export const getBooks = () => {
    return apiService.get('/api/books');
};

export const getBookById = (id) => {
    return apiService.get(`/api/books/${id}`);
};

export const createBook = (bookData) => {
    return apiService.post('/api/books', bookData);
};

export const updateBook = (id, bookData) => {
    return apiService.put(`/api/books/${id}`, bookData);
};

export const deleteBook = (id) => {
    return apiService.delete(`/api/books/${id}`);
};

// Categories
export const getCategories = () => {
    return apiService.get('/api/categories');
};

export const getCategoryById = (id) => {
    return apiService.get(`/api/categories/${id}`);
};

export const createCategory = (categoryData) => {
    return apiService.post('/api/categories', categoryData);
};

export const updateCategory = (id, categoryData) => {
    return apiService.put(`/api/categories/${id}`, categoryData);
};

export const deleteCategory = (id) => {
    return apiService.delete(`/api/categories/${id}`);
};

// Users
export const getUsers = () => {
    return apiService.get('/api/users');
};

export const getUserById = (id) => {
    return apiService.get(`/api/users/${id}`);
};

export const createUser = (userData) => {
    return apiService.post('/api/users', userData);
};

export const updateUser = (id, userData) => {
    return apiService.put(`/api/users/${id}`, userData);
};

export const deleteUser = (id) => {
    return apiService.delete(`/api/users/${id}`);
};

export default apiService;
