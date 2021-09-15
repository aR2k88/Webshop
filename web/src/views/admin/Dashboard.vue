<template>
  <v-layout>
    admin
  </v-layout>
</template>

<script>
import axios from "axios";

export default {
  name: "Dashboard",
  created() {
    axios.get(`api/admin/valid`).then(response => {
      console.log(response)
      if (!response.data) this.$router.push("/admin/login")
    }).catch(this.$router.push("/admin/login"))
  }
}

</script>

<style scoped>

</style>