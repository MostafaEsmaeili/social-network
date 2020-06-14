﻿import axios, { AxiosResponse } from 'axios';
import createBrowserHistory from '../utils/createBrowserHistory';
import * as constants from '../utils/constants';
import { toast } from 'react-toastify';

const sleepTime = 10;

const axiosInstance = axios.create({
    baseURL: "http://localhost/socialnetwork/api/",
    withCredentials: true,
    timeout: 30000
});

axiosInstance.interceptors.response.use((response) => response, (err) => {
    //const { response, config, data } = err;   
    const { response } = err;
    if (err.message === "Network Error" && !response) {
        toast.error('Network error server is down for maintenance, Please try after sometime');
        return;
    }
    switch (response.status) {
        case 400:
            toast.error('Bad request, Please check data');
            break;
        case 404:
            createBrowserHistory.push(constants.NOT_FOUND);
            break;
        case 500:
            toast.error('Server Issue - Oops, something went wrong');
            break;
        default:
            throw err.message;
    }
    console.log(err);
    throw err.response;
});

const processResponse = (dbResponse: AxiosResponse) => {
    return dbResponse.data;
};

const addDelay = (ms: number) => (dbResponse: AxiosResponse) => {
    return new Promise<AxiosResponse>(resolve => setTimeout(() => resolve(dbResponse), ms));
};

const httpService = {
    get: async (url: string) => {
        const dbResponse: AxiosResponse = await axiosInstance.get(url).then(addDelay(sleepTime));
        return processResponse(dbResponse);
    },
    post: async (url: string, body: {}) => {
        const dbResponse: AxiosResponse = await axiosInstance.post(url, body).then(addDelay(sleepTime));
        return processResponse(dbResponse);
    },
    put: async (url: string, body: {}) => {
        const dbResponse: AxiosResponse = await axiosInstance.put(url, body).then(addDelay(sleepTime));
        return processResponse(dbResponse);
    },
    delete: async (url: string) => {
        const dbResponse: AxiosResponse = await axiosInstance.delete(url).then(addDelay(sleepTime));
        return processResponse(dbResponse);
    }
};

export default httpService;