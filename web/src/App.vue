<template>
  <v-app id="app">
    <v-main class="background">
      <MainNavBar></MainNavBar>
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
export default {
  components: {MainNavBar}
}
</script>