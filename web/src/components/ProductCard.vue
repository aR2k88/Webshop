<template>
  <v-card max-width="350" color="secondary">
    <v-img src="https://images.pexels.com/photos/90946/pexels-photo-90946.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
           max-width="350" max-height="250"></v-img>
    <v-container class="pb-11">
      <h2 class="text-left float-left"> {{product.price}}</h2>
      <v-btn color="primary" class="float-right" @click="clickBuy(product._id)">Kjøp</v-btn>
    </v-container>
  </v-card>
</template>

<script>
export default {
  name: "ProductCard",
  props: ['product'],
  return() {

  },
  methods: {
    clickBuy(id) {
      console.log(id);
    }
  }
}
</script>

<style scoped>

</style>