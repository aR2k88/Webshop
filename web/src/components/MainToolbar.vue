<template>
  <v-container color="background">
      <v-app-bar color="background" flat>
        <v-app-bar-nav-icon class="d-flex d-md-none" @click="drawer = true"></v-app-bar-nav-icon>
        <v-toolbar-title>
          logo
        </v-toolbar-title>
        <v-spacer></v-spacer>
       <MainNavBar></MainNavBar>
        <v-spacer></v-spacer>
        <v-btn icon>
          <v-icon large>mdi-magnify</v-icon>
        </v-btn>
        <QuickCart></QuickCart>
      </v-app-bar>
      <v-navigation-drawer
          v-model="drawer"
          absolute
          temporary>
        <v-list
            nav
            dense>
          <v-list-item-group>
            <v-list-item v-for="(item, index) in items" :key="item">
              <v-list-item-title @click="tab = index">{{ item }}</v-list-item-title>
            </v-list-item>
          </v-list-item-group>
        </v-list>
      </v-navigation-drawer>
    </v-container>
</template>

<script>
import QuickCart from "@/components/QuickCart";
import MainNavBar from "@/components/MainNavBar";

export default {
  name: "MainToolbar",
  components: {
    MainNavBar,
    QuickCart
  },
  data: function () {
    return {
      tab: null,
      drawer: false,
      items: [
        'Hjem', 'Produkter', 'Historie', 'Kontakt oss',
      ],
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