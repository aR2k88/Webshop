<template>
    <v-layout row wrap>
      <v-flex xs6 md4 lg3 v-for="product in products" :key="product._id">
        <product-card :product="product"></product-card>
      </v-flex>
    </v-layout>
</template>
<script>
import ProductCard from "@/components/ProductCard";

export default {
  name: "ProductList",
  components: {
    ProductCard
  },
  computed: {
    products() {
      return this.$store.state.ProductModule.products;
    },
    productInListCount() {
      switch (this.$vuetify.breakpoint.name) {
        case 'xs':
          return 6
        case 'sm':
          return 4
        default:
          return 3
      }
    }
  }
}
</script>

<style scoped>

</style>