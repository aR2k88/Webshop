<template>
  <v-toolbar color="background" >
    <v-img>logo</v-img>
    <v-spacer></v-spacer>

    <v-btn icon>
      <v-icon>mdi-magnify</v-icon>
    </v-btn>

    <v-btn icon>
      {{getProductCountInCart}}
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
    getProductCountInCart(){
      return this.$store.getters.getProductCountInCart
    },
  }
}
</script>

<style scoped>

</style>