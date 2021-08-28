<template>
  <v-toolbar color="background" >
    <v-img>logo</v-img>
    <v-spacer></v-spacer>

    <v-btn icon>
      <v-icon>mdi-magnify</v-icon>
    </v-btn>

    <v-btn icon>
      {{countCartItems}}
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
    countCartItems(){
      if(this.cart.cartItems === undefined) return 0;
      return this.$store.state.CartModule.cart.cartItems.length;
    }
  }
}
</script>

<style scoped>

</style>