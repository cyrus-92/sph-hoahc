import config from 'config';
import { authHeader } from '../_helpers';
import axios from 'axios';

export const userService = {
    login,
    logout,
    register,
    getProfile
};

function login(email, password) {
    const requestOptions = {
        url: `${config.apiUrl}/api/users/sign_in`,
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        data: JSON.stringify({ email, password })
    };

    return axios.request(requestOptions)
        .then(handleResponse)
        .then(function(res) {
            if (res.access_token) {
                localStorage.setItem('user', JSON.stringify(res));
            }
        });
}

function logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('user');
}

function register(user) {
    const requestOptions = {
        url: `${config.apiUrl}/api/users/sign_up`,
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        data: {
            first_name: user.firstName,
            last_name: user.lastName,
            email: user.email,
            password: user.password,
            contact_number: user.contactPhone
        }
    };

    return axios.request(requestOptions)
        .then(handleResponse);
}

function getProfile() {
    const requestOptions = {
        url: `${config.apiUrl}/api/users/me`,
        method: 'GET',
        headers: authHeader()
    };

    return axios.request(requestOptions)
        .then(handleResponse);
}

function handleResponse(response) {
    if (response.status === 401) {
        // auto logout if 401 response returned from api
        logout();
        location.reload();
    }

    if (!response.data.status)
        return Promise.reject(response.data.error);

    return Promise.resolve(response.data);
}