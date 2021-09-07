<template>
<v-container>
  <v-row>
    <v-col cols="6">
      <v-img>image</v-img>
    </v-col>
    <v-col cols="6">
      <h1>{{ currentProduct.name }}</h1>
    </v-col>
  </v-row>
</v-container>
</template>

<script>
export default {
  name: "ProductView",
  computed: {
    currentProduct() {
      return this.$store.state.ProductModule.currentProduct;
    }
  }
  
}
</script>

<style scoped>

</style>