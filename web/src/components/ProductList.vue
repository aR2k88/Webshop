<template>
  <v-layout row wrap>
    <v-flex xs12>
    <v-row no-gutters>
  <v-card v-for="product in products" :key="product._id" class="ma-2">
    <product-card :product="product">
    </product-card>
  </v-card>
    </v-row>
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
      switch(this.$vuetify.breakpoint.name) {
        case 'xs': return 2
        default: return 4
      }
    }
  }
}
</script>

<style scoped>

</style>