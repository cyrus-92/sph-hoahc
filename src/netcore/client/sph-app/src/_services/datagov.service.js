import config from 'config';
import { authHeader } from '../_helpers';
import axios from 'axios';

export const dataGovService = {
    getCarparkAvailability
};

function getCarparkAvailability() {
    const requestOptions = {
        url: `${config.apiUrl}/api/transports/carpark_availability`,
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