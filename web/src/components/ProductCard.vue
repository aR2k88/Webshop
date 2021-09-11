<template>
  <v-container color="secondary" flat @click="goToProduct()" max-width="90%" class="mt-6">
    <v-layout>
      <v-img width="100%" :src="mainImage" max-height="325px" min-height="325px"></v-img>
    </v-layout>
    <v-layout class="ml-1 mt-3 mr-1">
      <v-flex class="text-left text-wrap text-break">
        <span class="text-align-last productName">{{ product.name }}</span>
      </v-flex>
    </v-layout>
    <v-layout row class="ml-1 mr-1 mt-1">
      <v-flex>
        <span class="float-left">{{ product.price }} nok</span>
      </v-flex>
      <v-flex>
        <v-btn color="primary" @click="clickBuy(product)" class="float-end">Kjøp</v-btn>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import axios from "axios";

export default {
  name: "ProductCard",
  props: ['product'],
  data: function () {
    return {
      productUrl: '',
    }
  },

  mounted() {
    axios.get(`api/url/${this.product._id}`).then(response => {
      this.productUrl = response.data
    })
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
        this.$router.push(`/${this.product.category}/${this.productUrl}`)
    },
  },
  computed: {
    cart() {
      return this.$store.state.CartModule.cart;
    },
    mainImage() {
      let test = '/images/products/' + this.productUrl + '/1.png';
      console.log(test)
      return '/images/products/'+ this.productUrl + '/1.png';

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