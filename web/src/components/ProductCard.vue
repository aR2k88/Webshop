<template>
  <v-container color="secondary" flat @click="goToProduct(product._id)" max-width="90%" class="mt-6">
    <v-layout>
    <v-img width="100%" src="https://images.pexels.com/photos/90946/pexels-photo-90946.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
           ></v-img>
    </v-layout>
    <v-layout class="ml-1 mt-3 mr-1">
      <v-flex class="text-left text-wrap text-break">
        <span class="text-align-last productName">{{product.name}}</span>
      </v-flex>
    </v-layout>
    <v-layout row class="ml-1 mr-1 mt-1">
      <v-flex>
        <span class="float-left">{{product.price}} nok</span>
      </v-flex>
      <v-flex>
        <v-btn color="primary" @click="clickBuy(product)" class="float-end">Kjøp</v-btn>
      </v-flex>
    </v-layout>
  </v-container>
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
    goToProduct(item) {
      console.log(item)
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

.productName {
  font-size: 1.1rem;
  font-weight: 600;
}

</style>