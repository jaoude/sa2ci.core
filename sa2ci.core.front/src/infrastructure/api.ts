import axios from 'axios';
import * as Qs from 'qs'

const API = axios.create({
    baseURL : process.env.VUE_APP_API_URL,
    paramsSerializer: params => Qs.stringify(params, { arrayFormat: 'repeat' }),
});

export default API;

