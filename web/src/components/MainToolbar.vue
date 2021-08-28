<template>
  <v-toolbar color="background" >
    <v-img>logo</v-img>
    <v-spacer></v-spacer>

    <v-btn icon>
      <v-icon>mdi-magnify</v-icon>
    </v-btn>

    <v-btn icon>
      {{getProductCount}}
      <v-icon>mdi-heart</v-icon>
    </v-btn>
    
  </v-toolbar>
</template>

<script>
export default {
  name: "MainToolbar",
  computed: {
    cart() {
      return this.$store.state.CartModule.cart;
    },
    getProductCount(){
      let test =  this.$store.getters.getProductCount
      return test;
    },
  }
}
</script>

<style scoped>

</style>