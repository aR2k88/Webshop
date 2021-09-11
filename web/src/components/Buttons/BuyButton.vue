<template>
  <v-btn color="primary" :class="getBtnClass" @click="clickBuy(product)" large>{{ btnText }}</v-btn>
</template>

<script>
export default {
  name: "BuyButton",
  props: ['product', 'btnText', 'btnClass', 'btnSize'],
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
    getBtnClass() {
      return this.btnClass;
    }
  }
}
</script>

<style scoped>

</style>