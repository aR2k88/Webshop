<template>

  <v-layout row class="bck pb-8">
    <v-flex xs12 class="mt-8">
      <div><span class="textStyle">Denne månedes favoritter</span></div>
    </v-flex>
    <v-flex>
      <ProductList :productList="allProducts"></ProductList>
    </v-flex>
  </v-layout>

</template>

<script>

import ProductList from "@/components/ProductList";
export default {
  name: "MonthsFavorites",
  components: {ProductList},
  computed: {
    allProducts() {
      return this.$store.state.ProductModule.products
    }
  }
}
</script>

<style scoped>
.bck {
  background-color: white;
}
.textStyle {
  font-size: 1.2rem;
  font-weight: bold;
}
</style>