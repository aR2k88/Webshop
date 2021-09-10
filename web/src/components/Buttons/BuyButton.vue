<template>
  <v-btn color="primary" :class="btnClass" @click="clickBuy(product)" large>{{ btnText }}</v-btn>
</template>

<script>
export default {
  name: "BuyButton",
  props: ['product', 'btnText', 'class', 'btnSize'],
  methods: {
    async clickBuy(product) {
      let payload = {
        cartId: this.cart._id,
        product: product
      }
      await this.$store.dispatch("addToCart", payload)
    },
  },
  computed: {
    btnClass() {
      return this.class;
    }
  }
}
</script>

<style scoped>

</style>