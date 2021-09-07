<template>
<ProductList :productList="productList">
</ProductList>
</template>

<script>
import ProductList from "@/components/ProductList";
import axios from "axios";
export default {
  name: "Category",
  components: {ProductList},
  data: function() {
    return {
      productList: []
    }
  },
  mounted() {
    let category = this.$route.params.category;
    axios.get(`api/product/category/${category}`).then(response => {
      this.productList = response.data;
    });
  }
}
</script>

<style scoped>

</style>