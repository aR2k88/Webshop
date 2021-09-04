<template>
  <v-app id="app">
    <v-main class="background">
      <v-card color="background">
      <MainToolbar></MainToolbar>
      <MainNavBar></MainNavBar>
      </v-card>
      <v-container>
        <v-row>
          <v-col>
          </v-col>
          <v-col cols="10">
            <router-view :key="$route.fullPath"></router-view>
          </v-col>
          <v-col></v-col>
        </v-row>
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
  h1,h2,h3,h4 {
    color: #53524E;
  }
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