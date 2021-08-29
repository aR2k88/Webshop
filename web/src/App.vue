<template>
  <v-app id="app">
    <v-main class="background">
      <v-card color="background">
      <MainToolbar></MainToolbar>
      <MainNavBar></MainNavBar>
      </v-card>
      <v-container>
        <router-view :key="$route.fullPath"></router-view>
      </v-container>
    </v-main>
  </v-app>

</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

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
import MainNavBar from "@/components/MainNavBar";
import MainToolbar from "@/components/MainToolbar";

export default {
  components: {MainNavBar, MainToolbar},
  mounted() {
     this.$store.dispatch("fetchProducts");
     this.handleCart();
  },
  methods: {
    handleCart() {
      let cartId = this.$cookie.get('cartId')
      if(cartId !== null){
        this.$store.dispatch("fetchCart", cartId)
      }
    }
  }
}
</script>