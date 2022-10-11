import { userStore } from '@/store/modules/user-store';
import axios from 'axios';
import * as Qs from 'qs'

const API = axios.create({
    baseURL : process.env.VUE_APP_API_URL,
    paramsSerializer: params => Qs.stringify(params, { arrayFormat: 'repeat' }),
});

API.interceptors.request.use(config => {
    // debugger;
    if(!config) config = {};
    if(!config.headers) config.headers = {};
    const accessToken :string = userStore.getAccessToken();
    if(accessToken != '')
        config.headers.Authorization = "Bearer " + accessToken;
    return config;
})

export default API;

