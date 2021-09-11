<template>
  <ProductView :productUrl="productUrl"></ProductView>
</template>
<script>
import ProductView from "@/components/ProductView";
export default {
  name: "Product",
  components: {ProductView},
  data: function () {
    return {
      productUrl: '',
    }
  },
  methods: {},
  async mounted() {
    let category = this.$route.params.category;
    this.productUrl = this.$route.params.productUrl;
    let payload = {
      category: category,
      productUrl: this.productUrl
    }
    await this.$store.dispatch("fetchProductByUrl", payload)
  },
  computed: {
  }
}
</script>

<style scoped>

</style>