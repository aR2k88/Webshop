<template>
  <ProductList :productList="products"></ProductList>
</template>

<script>
// @ is an alias to /src
import ProductList from "@/components/ProductList";
export default {
  name: 'Home',
  components: {
    ProductList,
  },
  computed: {
    products() {
      return this.$store.state.ProductModule.products;
    }
  }
}
</script>
