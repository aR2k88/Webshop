<template>
  <v-app id="app">
    <v-main class="background">
      <MainToolbar id="nav"></MainToolbar>
<!--      <MainNavBar></MainNavBar>-->
      <v-container fluid :class="navBarMargin">
        <router-view :key="$route.fullPath"></router-view>
      </v-container>
      <v-container>
        <Footer></Footer>
      </v-container>
    </v-main>
  </v-app>

</template>

<style lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Quicksand&display=swap');

#app {
  font-family: Quicksand, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin: auto;
  max-width: 1440px;
  background: #F0EFED;

  h1, h2, h3, h4 {
    color: #53524E;
  }
  
}

#nav {
  padding: 30px;
  max-width:1440px;
  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
<script>
import MainToolbar from "@/components/MainToolbar";
import Footer from "@/components/Footer";

export default {
  components: {MainToolbar, Footer},
  mounted() {
    this.$store.dispatch("fetchProducts");
    this.handleCart();
  },
  methods: {
    handleCart() {
      let cartId = this.$cookie.get('cartId')
      if (cartId !== null) {
        this.$store.dispatch("fetchCart", cartId)
      }
    }
  },
  computed: {
    navBarMargin() {
      switch (this.$vuetify.breakpoint.name) {
        case 'lg':
          return "mt-10"
        case 'xl':
          return "mt-10"
        default:
          return ""
      }
    },
  }
}
</script>