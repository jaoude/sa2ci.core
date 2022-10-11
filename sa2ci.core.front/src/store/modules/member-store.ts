import { VuexModule, Module } from "vuex-class-modules";
import store from "@/store";
import { MemberDto } from "@/models/generated/MemberDto";
import { memberService } from "@/services/generated/MemberService";

@Module({generateMutationSetters: true})
class MemberStore extends VuexModule {
    members: MemberDto[] = [];

    async loadMembers() {
        this.members = (await memberService.getMembers()).data;
    }
}

export const memberStore = new MemberStore({ store, name: "memberStore" });