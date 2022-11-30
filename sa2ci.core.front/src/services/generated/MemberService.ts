 
import { MemberDto } from '@/models/generated/MemberDto';
 
import api from '@/infrastructure/api'

export class MemberService {
    

    public getMembers (){
        return api.request<MemberDto[]>({
            url:`api/Member/getMembers`,
            method: "get",
            params : null
        });
    }
}

export const memberService= new MemberService();
