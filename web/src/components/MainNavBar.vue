<template>
  <v-tabs fixed-tabs background-color="background">
    <v-tab to="/">
      Hjem
    </v-tab>
    <v-tab to="/About">
      Produkter
    </v-tab>
    <v-tab @click="testFunction">
      Historie {{ testvalue }}
    </v-tab>
    <v-tab>
      Kontakt oss
    </v-tab>
  </v-tabs>
</template>

<script>
import axios from "axios";
export default {
  name: "MainNavBar",
  data: function () {
    return {
      testValue: "",
    }
  },
  components: {},
  methods: {
    testFunction() {
      var result = axios.get("api/product/test")
      this.testvalue = result.data;
    }
  }
}

</script>

<style scoped>

</style>