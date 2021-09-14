<template>
  <v-container max-width="100%">
    <v-layout class="backWhite pa-5" row wrap>
      <v-flex xs12>
        <v-list v-for="cartItem in cart.cartItems" :key="cartItem.product._id">
          <v-list-item class="mb-5">
            <v-layout>
              <v-flex>
                <v-img :src="getProductUrl(cartItem.product.url)" max-width="100px" max-height="125px" min-width="100px"
                       min-height="125px" aspect-ratio="1"></v-img>
              </v-flex>
              <v-flex row wrap class="mt-1 ml-2">
                <v-flex xs12>
                  <span class="float-left">{{ cartItem.product.name }}</span>
                </v-flex>
                <v-flex xs12><span class="float-right">{{ cartItem.product.price }} nok</span></v-flex>
                <v-flex xs12>
                  <v-btn x-small fab class="mr-3" @click="removeProduct(cartItem.product)">
                    <v-icon>mdi-minus-circle-outline</v-icon>
                  </v-btn>
                  <span>{{cartItem.quantity}}</span>
                  <v-btn x-small fab class="ml-3 mx-2" @click="addProduct(cartItem.product)">
                    <v-icon>mdi-plus-circle-outline</v-icon>
                  </v-btn>
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
        <span class="float-right">{{ subTotal }}</span>
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
        <span class="float-right">{{ subTotal }}</span>
      </v-flex>
    </v-layout>
  </v-container>
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
    getProductUrl(productUrl) {
      return "/images/products/" + productUrl + "/1.png"
    },
    addProduct(product){
      let payload = {
        cartId: this.cart._id,
        product: product
      }
      this.$store.dispatch("addToCart", payload);
    },
    removeProduct(product) {
      let payload = {
        cartId: this.cart._id,
        product: product
      }
      this.$store.dispatch("removeFromCart", payload);
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