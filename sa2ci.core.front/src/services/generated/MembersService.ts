 
import { MemberDto } from '@/models/generated/MemberDto';
 
import api from '@/infrastructure/api'

export class MembersService {
    

    public getAll (){
        return api.request<MemberDto[]>({
            url:`Members/getAll`,
            method: "get",
            params : null
        });
    }
}

export const membersService= new MembersService();
