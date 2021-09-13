<template>
  <v-layout class="backWhite pa-5" row wrap>
    <v-flex xs12>
      <v-list v-for="cartItem in cart.cartItems" :key="cartItem.product._id">
        <v-list-item class="mb-5">
          <v-layout row wrap>
            <v-flex xs4>
              <v-img :src="getProductUrl(cartItem.product.url)" max-width="100px" max-height="100px" aspect-ratio="1"></v-img>
            </v-flex>
            <v-flex row wrap class="mt-2">
              <v-flex class="ml-2" xs12>
                <span class="float-left">{{cartItem.product.name}}</span>
                <span class="float-right">{{cartItem.product.price}} nok</span>
              </v-flex>
              <v-flex xs12 class="ml-2">
                <span class="float-left">Antall {{cartItem.quantity}}</span>
              </v-flex>
            </v-flex>
          </v-layout>
        </v-list-item>
      </v-list>
    </v-flex>
    <v-flex xs12>
      <v-divider></v-divider>
    </v-flex>
    <v-flex xs12 class="mt-2">
      <span class="float-left">Subtotal</span>
      <span class="float-right">{{subTotal}}</span>
    </v-flex>
    <v-flex xs12 class="mt-2">
      <span class="float-left">Estimert frakt</span>
      <span class="float-right">0</span>
    </v-flex>
    <v-flex xs12 class="mt-2">
      <v-divider></v-divider>
    </v-flex>
    <v-flex xs12 class="mt-2">
      <span class="float-left">Totalt</span>
      <span class="float-right">{{subTotal}}</span>
    </v-flex>
  </v-layout>
</template>

<script>

export default {
  name: "Checkout",
  data() {
    return {
      productUrls: [],
    }
  },
  mounted() {

  },
  methods: {
   getProductUrl(productUrl){
     return "/images/products/" + productUrl + "/1.png"
   }
  },
  computed: {
    cart() {
      return this.$store.state.CartModule.cart;
    },
    subTotal() {
      return this.$store.getters.GetSubTotalInCart;
    }
  }
}
</script>

<style scoped>
.backWhite {
  background-color: white;
}

</style>