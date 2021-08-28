<template>
  <v-row>
    <template v-for="product in products">
      <v-col cols="3" :key="product._id">
        <ProductCard :product="product"></ProductCard>
      </v-col>
    </template>
  </v-row>

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
    }
  }
}
</script>

<style scoped>

</style>