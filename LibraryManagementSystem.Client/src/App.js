import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';
import ProfilePage from './pages/ProfilePage';
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';
import BookBorrowingsPage from './pages/BookBorrowingsPage';
import BooksPage from './pages/BooksPage';
import CategoriesPage from './pages/CategoriesPage';
import NotFoundPage from './pages/NotFoundPage';

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/profile" element={<ProfilePage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route path="/register" element={<RegisterPage />} />
                <Route path="/categories" element={<CategoriesPage />} />
                <Route path="/books" element={<BooksPage />} />
                <Route path="/book-borrowings" element={<BookBorrowingsPage />} />
                <Route path="/not-found" element={<NotFoundPage />} />
            </Routes>
        </Router>
    );
};

export default App;
