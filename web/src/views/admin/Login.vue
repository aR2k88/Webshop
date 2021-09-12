<template>
<v-container>
  <v-text-field label="Username" v-model="username"></v-text-field>
  <v-text-field label="password" v-model="password"></v-text-field>
  <v-btn @click="login">login</v-btn>
</v-container>
</template>

<script>
import axios from "axios";
export default {
  name: "Login",
  data() {
    return {
      username: '',
      password: ''
    }
  },
  methods: {
    login() {
      let payload = {
        Username: this.username,
        Password: this.password
      }
      axios.post(`/api/login`, payload).then(response => {
        this.$cookie.set('access_token', response.data.token)
      })
    }
  }
}
</script>

<style scoped>

</style>