<template>
  <v-container color="secondary" flat @click="goToProduct()" max-width="90%" class="mt-6">
    <v-layout>
        <v-img width="100%" :src="mainImage" max-height="325px" min-height="325px" aspect-ratio="1"></v-img>
      </v-layout>
    <v-layout class="ml-1 mr-1 mt-3" row wrap>
      <v-flex xs12 class="text-left text-wrap text-break">
        <span class="text-align-last productName">{{ product.name }}</span>
      </v-flex>
      <v-flex xs12>
        <span class="float-left">{{ product.price }} nok</span>
      </v-flex>
      <v-flex xs12 class="text-left text-wrap text-break mt-2">
        <span class="float-left">{{product.shortDescription}}</span>
      </v-flex>
      <v-flex xs12 class="mt-2">
        <v-btn color="primary" @click.stop="clickBuy(product)" class="float-left text-none">Legg i handlekurven</v-btn>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  name: "ProductCard",
  props: ['product'],
  data: function () {
    return {
    }
  },

  mounted() {
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
        this.$router.push(`Produkter/${this.product.category}/${this.product.url}`)
    },
  },
  computed: {
    cart() {
      return this.$store.state.CartModule.cart;
    },
    mainImage() {
      return '/images/products/'+ this.product.url + '/1.png';
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