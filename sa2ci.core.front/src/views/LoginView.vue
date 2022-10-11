 <template>
  <div id="login">
    <h1>Login</h1>
    <v-text-field v-model="email" placeholder="Email"></v-text-field>
    <v-text-field v-model="password" placeholder="Password"></v-text-field>
    <v-btn @click="login">Login</v-btn>
  </div>
</template>

<script lang="ts">
import { Vue } from "vue-class-component";
import { userStore } from "@/store/modules/user-store";

export default class LoginView extends Vue {
  email = '';
  password = '';

  async login() {
    if (this.email != "" && this.password != "") {
      await userStore.login(this.email, this.password); 
      // if(this.username == this.$parent.mockAccount.username 
      //     && this.input.password == this.$parent.mockAccount.password) {
      //     this.$emit("authenticated", true);
      //     this.$router.replace({ name: "secure" });
      // } else {
      //     console.log("The username and / or password is incorrect");
      // }
    } else {
      console.log("A username and password must be present");
    }
  }
}

</script>

<style scoped>
#login {
  width: 500px;
  border: 1px solid #CCCCCC;
  background-color: #FFFFFF;
  margin: auto;
  margin-top: 200px;
  padding: 20px;
}
</style>