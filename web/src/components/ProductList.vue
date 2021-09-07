<template>
  <v-layout row wrap>
    <v-flex xs12 sm6 md4 lg3 v-for="product in productList" :key="product._id">
      <product-card :product="product"></product-card>
    </v-flex>
  </v-layout>
</template>
<script>
import ProductCard from "@/components/ProductCard";

export default {
  name: "ProductList",
  props: ["productList"],
  components: {
    ProductCard
  },
  computed: {},
  methods: {

  }
}
</script>

<style scoped>

</style>