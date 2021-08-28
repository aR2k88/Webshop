<template>
  <v-btn color="primary" class="float-right" @click="buyClick">Kjøp</v-btn>
</template>

<script>
export default {
  name: "BuyButton",
  props: ['productId'],
  methods: {
    buyClick() {
      this.$emit("buyClick", this.productId);
    }
  }
}
</script>

<style scoped>

</style>