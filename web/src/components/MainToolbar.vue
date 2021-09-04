<template>
  <v-row>
    <v-col></v-col>
    <v-col cols="7">
  <v-toolbar color="background" flat>
    <v-toolbar-title>
      logo
    </v-toolbar-title>
    <v-spacer></v-spacer>
    <v-toolbar-items>
      <v-btn  icon>
        <v-icon large>mdi-magnify</v-icon>
      </v-btn>
    </v-toolbar-items>
    <v-toolbar-items>
      <QuickCart></QuickCart>
    </v-toolbar-items>

  </v-toolbar>
    </v-col>
    <v-col></v-col>
  </v-row>
</template>

<script>
import QuickCart from "@/components/QuickCart";

export default {
  name: "MainToolbar",
  components: {
    QuickCart
  },
  data: function () {
    return {}
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