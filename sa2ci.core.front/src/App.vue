<template>
  <v-card color="basil">
    <v-card-title class="text-center justify-center py-6">
      <h1 class="font-weight-bold text-h2 text-basil">
        BASiL
      </h1>
    </v-card-title>

    <v-tabs v-model="tab" background-color="transparent" color="basil" grow>
      <v-tab v-for="t in tabs" :key="t.name" :to="t.to">{{t.name}}</v-tab>
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

export default class App extends Vue {
  tab = 'Appetizers';
  tabs: { "name": string, "to": string }[] = [{ "name": "Home", "to": "/" }, { "name": "Members", "to": "/members" }, { "name": "About", "to": "/about" }];
}
</script>

