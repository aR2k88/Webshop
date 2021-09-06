<template>
  <v-container color="background">
    <!-- MOBILE -->
    <v-app-bar color="background" flat fixed>
      <v-app-bar-nav-icon class="d-flex d-lg-none" @click="drawer = true"></v-app-bar-nav-icon>
      <v-spacer></v-spacer>
      <v-toolbar-title>
        logo
      </v-toolbar-title>
      <v-spacer class="d-none d-lg-flex"></v-spacer>
      <MainNavBar class="d-none d-lg-flex"></MainNavBar>
      <v-spacer></v-spacer>
      <QuickCart></QuickCart>
      <v-spacer class="d-none d-lg-flex"></v-spacer>
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
  methods: {
    screenSize() {
      switch (this.$vuetify.breakpoint.name) {
        case 'xs':
          return false
        case 'sm':
          return false
        case 'md':
          return false
        default:
          return true
      }
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