<template>
   
  <v-card color="basil">
    <v-card-title class="text-center justify-center py-6">
      <span>
      <h1 class="font-weight-bold text-h2 text-basil">
        BASiL
      </h1>
      <div v-if="userStore.isAuthenticated===true">{{userStore.userName}}</div>
      </span>
    </v-card-title>

    <v-tabs v-model="tab" background-color="transparent" color="basil" grow>
      <v-tab v-for="t in tabs" :key="t.name" :to="t.to">
      <v-icon>{{ t.icon }}</v-icon>{{ t.name }}
      </v-tab>
    </v-tabs>

    <v-window>
      <router-view></router-view>
    </v-window>
  </v-card>
</template>

<style>
/* Helper classes */
.bg-basil {
  background-color: #FFFBE6 !important;
}

.text-basil {
  color: #356859 !important;
}
</style>

<script lang="ts">

import { Vue } from "vue-class-component";
import { memberStore } from "@/store/modules/member-store"
import { userStore } from "@/store/modules/user-store"

export default class App extends Vue {
  userStore = userStore;
  tab = 'Appetizers';
  tabs: { "name": string, "to": string, "icon": string }[] = [
    { "name": "Home", "to": "/", "icon":"mdi-home" },
    { "name": "Members", "to": "/members", "icon":"mdi-account-multiple "},
    { "name": "Payments", "to": "/payments", "icon":"mdi-currency-usd" },
    { "name": "About", "to": "/about", "icon":"mdi-information" },
    { "name": "Login", "to": "/login", "icon":"mdi-login" }];

  async created() {
    await memberStore.loadMembers();
  }
}
</script>

