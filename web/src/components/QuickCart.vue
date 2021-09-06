<template>
    <v-menu offset-y :close-on-content-click="false">
      <template v-slot:activator="{ on }">
        <div class="text-center">
        <v-btn v-on="on" fab dark color="primary" class="mt-2" x-small>
          <h3 class="white--text">{{getProductCountInCart}}</h3>
        </v-btn>
        </div>
      </template>
      <v-list>
        <template v-for="item in cart.cartItems">
          <v-list-item :key="item.product._id">{{ item.product.name }} - {{item.quantity}}</v-list-item>
        </template>
        <v-list-item v-if="getProductCountInCart > 0">Gå til Kasse</v-list-item>
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