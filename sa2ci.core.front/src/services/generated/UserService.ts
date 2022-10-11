 
import { LoginRequestDto } from '@/models/generated/LoginRequestDto';
import { LoginResultDto } from '@/models/generated/LoginResultDto';
 
import api from '@/infrastructure/api'

export class UserService {
    

    public login (loginRequest?: LoginRequestDto){
        return api.request<LoginResultDto>({
            url:`api/User/login`,
            method: "get",
            params : loginRequest
        });
    }
}

export const userService= new UserService();
