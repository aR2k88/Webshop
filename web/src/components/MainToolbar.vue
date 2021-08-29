<template>
  <v-toolbar color="background">
    <v-img>logo</v-img>
    <v-spacer></v-spacer>

    <v-btn icon>
      <v-icon>mdi-magnify</v-icon>
    </v-btn>
    
    <QuickCart></QuickCart>

  </v-toolbar>
</template>

<script>
import QuickCart from "@/components/QuickCart";

export default {
  name: "MainToolbar",
  components: {
    QuickCart
  },
  data: function () {
    return {
    }
  },
  computed: {
    cart() {
      return this.$store.state.CartModule.cart;
    },
  }
}
</script>

<style scoped>

</style>