 
import { MemberDto } from '@/models/generated/MemberDto';
 
import api from '@/infrastructure/api'

export class MemberService {
    

    public getMembers (){
        return api.request<MemberDto[]>({
            url:`https://localhost:44330/api/Member/GetMembers`,
            method: "get",
            params : null
        });
    }
}

export const memberService= new MemberService();
