<template>
  <v-row>
    <v-col cols="3">
      <ProductCard></ProductCard>
    </v-col>
    <v-col cols="3">
      <ProductCard></ProductCard>
    </v-col>
    <v-col cols="3">
      <ProductCard></ProductCard>
    </v-col>
    <v-col cols="3">
      <ProductCard></ProductCard>
    </v-col>
  </v-row>

</template>

<script>
import ProductCard from "@/components/ProductCard";
export default {
  name: "ProductList",
  components: {
    ProductCard
  }
}
</script>

<style scoped>

</style>