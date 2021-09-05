<template>
  <v-card color="secondary" flat @click="goToProduct">
    <v-img src="https://images.pexels.com/photos/90946/pexels-photo-90946.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
           max-width="300" max-height="250"></v-img>
    <v-row>
      <v-col cols="8" class="pl-5">
        <h2 class="float-left font-weight-500">{{product.name}}</h2>
        <br />
        <br />
        <h4 class="float-left">{{product.price}} nok</h4>
      </v-col>
      <v-col cols="4">
        <v-container>
        <v-btn color="primary" class="float-right pb-6 pt-6 pa-5" @click="clickBuy(product)">Kjøp</v-btn>
        </v-container>
      </v-col>
    </v-row>
  </v-card>
</template>

<script>
export default {
  name: "ProductCard",
  props: ['product'],
  return() {

  },
  methods: {
    async clickBuy(product) {
      let payload = {
        cartId: this.cart._id,
        product: product
      }
      await this.$store.dispatch("addToCart", payload)

    },
    goToProduct() {
      
    }
  },
  computed: {
    cart() {
      return this.$store.state.CartModule.cart;
    }
  }
}
</script>

<style scoped>

</style>