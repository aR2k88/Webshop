<template>
    <v-menu offset-y :close-on-content-click="false">
      <template v-slot:activator="{ on }">
          <v-icon v-on="on">mdi-heart</v-icon>
        {{getProductCountInCart}}
      </template>
      <v-list>
        <template v-for="item in cart.cartItems">
          <v-list-item :key="item.product._id">{{ item.product.name }} - {{item.quantity}}</v-list-item>
        </template>
      </v-list>
    </v-menu>
</template>

<script>
export default {
  name: "QuickCart",
  computed: {
    cart() {
      return this.$store.state.CartModule.cart
    },
    getProductCountInCart() {
      return this.$store.getters.getProductCountInCart
    },
  }
}
</script>

<style scoped>

</style>