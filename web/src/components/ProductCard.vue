<template>
  <v-card max-width="350" color="secondary" flat>
    <v-img src="https://images.pexels.com/photos/90946/pexels-photo-90946.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
           max-width="350" max-height="250"></v-img>
    <v-container class="pb-11">
      <p class="float-left">{{product.name}}</p>
      <p class="text-left float-left"> {{productPrice}}</p>
      <v-btn color="primary" class="float-right" @click="clickBuy(product)">Kjøp</v-btn>
    </v-container>
  </v-card>
</template>

<script>
export default {
  name: "ProductCard",
  props: ['product'],
  return() {

  },
  methods: {
    clickBuy(product) {
      let payload = {
        cartId: this.cart._id,
        product: product
      }
      this.$store.dispatch("addToCart", payload);
    }
  },
  computed: {
    productPrice() {
      if(!this.product) return 0
      return this.product.price;
    },
    cart() {
      return this.$store.state.CartModule.cart;
    }
  }
}
</script>

<style scoped>

</style>