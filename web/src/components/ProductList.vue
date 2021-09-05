<template>
  <v-container row wrap>
    <v-flex xs12>
      <v-row no-gutters>
        <v-card v-for="product in products" :key="product._id" class="ma-2" flat>
          <product-card :product="product">
          </product-card>
        </v-card>
      </v-row>
    </v-flex>
  </v-container>
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