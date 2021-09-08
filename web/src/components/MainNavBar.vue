<template>
  <v-row class="d-none d-lg-flex">
    <v-col cols="3">
      <v-btn text to="/">
        <h2>Hjem</h2>
      </v-btn>
    </v-col>
    <v-col cols="3" id="2">
      <v-btn text to="/Produkter">
        <h2>Produkter</h2>
      </v-btn>
    </v-col>
    <v-col cols="3" id="3">
      <v-btn text to="/Historie">
        <h2>Historie</h2>
      </v-btn>
    </v-col>
    <v-col cols="3" id="4">
      <v-btn text to="/Kontakt">
        <h2>Kontakt oss</h2>
      </v-btn>
    </v-col>
  </v-row>
</template>

<script>
export default {
  name: "MainNavBar",
  data: function () {
    return {
      activeTab: 1
    }
  },
  components: {},
  methods: {
    changeTab(item) {
      console.log(item)
    }
  }
}

</script>
<style scoped>

.v-btn::before {
  background-color: #F0EFED;
}
.v-btn--active h2 {
  text-decoration: underline;
}
</style>