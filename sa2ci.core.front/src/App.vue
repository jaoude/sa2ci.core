<template>
  <v-app>

  
    <v-app-bar app clipped-left>{{userStore.userName}}</v-app-bar> 
    <v-navigation-drawer app  expand-on-hover rail>
      <v-list nav dense>
        <v-list-item prepend-icon="mdi-view-dashboard" title="Home" link @click="$router.push({ path: ' '});$router.push({ path: '/'})"></v-list-item>
        <v-list-item prepend-icon="mdi-account-multiple" title="Members" link @click="$router.push({ path: ' '});$router.push({ path: 'members'})"></v-list-item>
        <v-list-item prepend-icon="mdi-forum" title="About" link @click="$router.push({ path: ' '});$router.push({ path: 'about'})"></v-list-item>
        <v-list-item prepend-icon="mdi-login" title="Login" link @click="$router.push({ path: ' '});$router.push({ path: 'login'})"></v-list-item>
      </v-list>
    </v-navigation-drawer>
    <!-- Sizes your content based upon application components -->
    <v-main>
  
      <!-- Provides the application the proper gutter -->
      <v-container fluid>
  
        <!-- If using vue-router -->
        <router-view></router-view>
      </v-container>
    </v-main>
  
    <v-footer app>
      <!-- -->
    </v-footer>
  </v-app>
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
  async created() {
    await memberStore.loadMembers();
  }
}
</script>

