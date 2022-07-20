import { VuexModule } from "vuex-class-modules";
import store from "@/store";
import { MemberDto } from "@/models/generated/MemberDto";
import { memberService } from "@/services/generated/MemberService";

class MemberStore extends VuexModule {
    members: MemberDto[] = [];

    async loadMembers() {
        this.members = (await memberService.getMembers()).data;
        console.log(this.members);
    }
}

export const memberStore = new MemberStore({ store, name: "memberStore" });