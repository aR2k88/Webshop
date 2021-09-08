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
        color="background"
        class="text-left"
        v-model="drawer"
        app>
      <v-list
          nav
          dense>
        <v-list-item to="/">
          <v-list-item-title><span class="menuFont">Hjem</span></v-list-item-title>
        </v-list-item>
        <v-list-group>
          <v-list-item slot="activator">
              <v-list-item-title><span class="menuFont">Produkter</span></v-list-item-title>
          </v-list-item>
          <v-list-item to="/Produkter">
            <v-list-item-title><span class="menuFont ml-3">Se Alle</span></v-list-item-title>
          </v-list-item>
          <v-list-item v-for="subItem in allCategories" :key="subItem" @click="goToCategory(subItem)">
            <span class="menuFont ml-3">{{subItem}}</span>
          </v-list-item>
        </v-list-group>
        <v-list-item to="/Historie">
          <v-list-item-title><span class="menuFont">Historie</span></v-list-item-title>
        </v-list-item>
        <v-list-item to="/Kontakt">
          <v-list-item-title><span class="menuFont">Kontakt oss</span></v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-container>
</template>

<script>
import QuickCart from "@/components/QuickCart";
import MainNavBar from "@/components/MainNavBar";
import axios from "axios";

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
      allCategories: [],
      items: [
        { 
          text: "Hjem",
          value: 0,
          active: false,
          items: this.allCategories},
        { text: "Produkter", value: 1, active: false },
        { text: "Historie", value: 2, active: false },
        { text: "Kontakt oss", value: 3, active: false },
      ],
    }
  },
  async mounted() {
    axios.get(`api/product/categories`).then(response => {
      this.allCategories = response.data;
    })
  },
  methods: {
    goToCategory(category) {
      this.$router.push(`/${category}`);
    }

  },
  computed: {
    cart() {
      return this.$store.state.CartModule.cart;
    },
  },
  watch: {
    tab() {
      console.log(this.tab)
    }
  }
}
</script>

<style scoped>

.menuFont {
  font-size: 20px;
}

</style>