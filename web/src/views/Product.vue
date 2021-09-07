<template>
  <ProductView></ProductView>
</template>
<script>
import ProductView from "@/components/ProductView";
export default {
  name: "Product",
  components: {ProductView},
  data: function () {
    return {
    }
  },
  methods: {},
  async mounted() {
    let category = this.$route.params.category;
    let productUrl = this.$route.params.productUrl;
    let payload = {
      category: category,
      productUrl: productUrl
    }
    await this.$store.dispatch("fetchProductByUrl", payload)
  },
  computed: {
    currentProduct(){
      return this.$store.state.ProductModule.currentProduct;
    }
  }
}
</script>

<style scoped>

</style>