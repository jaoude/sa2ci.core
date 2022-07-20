<!-- <template>
  <div>
    <v-btn>AAAAAAAA</v-btn>
    <v-data-table :headers="headers" :items="items" fixed-header dense>
    {{items}}
      <template v-slot:body="{ items }">
        <tbody>
          <tr v-for="item in items" :key="item.ID">
            <td>{{ items.ID }}</td>
            <td>{{ items.FirstName }}</td>
            <td>{{ items.LastName }}</td>
            <td>{{ items.Email }}</td>
            <td>{{ items.DOB }}</td>
          </tr>
        </tbody>
      </template>
    </v-data-table>
    <h1>This is the members page</h1>
  </div>
</template> -->
<template>
  <v-table>
    <thead>
      <tr >
        <th class="text-left"  v-for="header in headers" :key="header.text">
          {{header.text}}
        </th>
        
      </tr>
    </thead>
    <tbody>
      <tr
        v-for="item in items" :key="item.ID"
      >
          <td>{{ item.ID }}</td>
          <td>{{ item.FirstName }}</td>
          <td>{{ item.LastName }}</td>
          <td>{{ item.Email }}</td>
          <td>{{ item.DOB }}</td> 
      </tr>
    </tbody>
  </v-table>
</template>
<script lang="ts">

import { MemberDto } from "@/models/generated/MemberDto";
import { memberStore } from "@/store/modules/member-store";
import { Vue } from "vue-class-component";

export default class MembersView extends Vue {
  headers = [
    { text: "ID", value: "ID" },
    { text: "First Name", value: "FirstName" },
    { text: "Last Name", value: "LastName" },
    { text: "Email", value: "Email" },
    { text: "Date Of Birth", value: "DOB" },
  ];

  get items(): MemberDto[] {
    return this.tmp1;
  }

  tmp1 = memberStore.members;

  tmp = [{
      "ID": 1,
      "FirstName": "Penny",
      "LastName": "Beahan",
      "Email": "Penny_Beahan@gmail.com",
      "DOB": new Date(1964 - 9 - 25)
    },
    {
      "ID": 2,
      "FirstName": "Judith",
      "LastName": "Crooks",
      "Email": "Judith30@hotmail.com",
      "DOB": new Date(1962 - 2 - 21)
    },
    {
      "ID": 3,
      "FirstName": "Stephen",
      "LastName": "Altenwerth",
      "Email": "Stephen_Altenwerth62@hotmail.com",
      "DOB": new Date(1975 - 9 - 27)
    },
    {
      "ID": 4,
      "FirstName": "Stella",
      "LastName": "Flatley",
      "Email": "Stella.Flatley79@gmail.com",
      "DOB": new Date(1997 - 3 - 4)
    },
    {
      "ID": 5,
      "FirstName": "Isaac",
      "LastName": "Breitenberg",
      "Email": "Isaac.Breitenberg24@hotmail.com",
      "DOB": new Date(1977 - 8 - 7)
    },
    {
      "ID": 6,
      "FirstName": "Albert",
      "LastName": "Wunsch",
      "Email": "Albert2@gmail.com",
      "DOB": new Date(1998 - 2 - 24)
    },
    {
      "ID": 7,
      "FirstName": "Wendell",
      "LastName": "Russel",
      "Email": "Wendell.Russel59@hotmail.com",
      "DOB": new Date(1999 - 5 - 20)
    },
    {
      "ID": 8,
      "FirstName": "Darlene",
      "LastName": "Mills",
      "Email": "Darlene.Mills87@hotmail.com",
      "DOB": new Date(1970 - 8 - 16)
    },
    {
      "ID": 9,
      "FirstName": "Elvira",
      "LastName": "Gorczany",
      "Email": "Elvira_Gorczany@yahoo.com",
      "DOB": new Date(1954 - 11 - 26)
    },
    {
      "ID": 10,
      "FirstName": "Johanna",
      "LastName": "Spinka",
      "Email": "Johanna_Spinka@yahoo.com",
      "DOB": new Date(1982 - 7 - 24)
  }]
  
}
</script>
