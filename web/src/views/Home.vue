<template>
  <v-layout row wrap class="bck pb-5">
    <v-flex xs12>
      <MainBanner></MainBanner>
    </v-flex>
    <v-flex xs12 class="background pt-10 pb-10">
      <div>
        <h3>En liten intro her</h3>
      </div>
      <div>Random tekst her</div>
      <div class="mt-6">
        <v-btn color="tertiary" class="text-none" depressed  >Les mer</v-btn>
      </div>
    </v-flex>
    <v-flex xs12 class="pt-6">
      <div><span class="textStyle">Denne månedes favoritter</span></div>
    </v-flex>
    <v-flex v-if="mobileDevice">
      <v-carousel hide-delimiters height="100%">
        <v-carousel-item v-for="product in products" :key="product._id">
          <ProductCard :product="product"></ProductCard>
        </v-carousel-item>
      </v-carousel>
    </v-flex>
    <v-flex sm6 md4 lg3 v-for="product in products" :key="product._id">
      <product-card :product="product" v-if="!mobileDevice"></product-card>
    </v-flex>
  </v-layout>
</template>

<script>
// @ is an alias to /src
import MainBanner from "@/components/MainBanner";
import ProductCard from "@/components/ProductCard";
export default {
  name: 'Home',
  components: {
    MainBanner, ProductCard
  },
  methods: {
  },
  computed: {
    products() {
      return this.$store.state.ProductModule.products;
    },
    mobileDevice() {
      switch (this.$vuetify.breakpoint.name) {
        case 'xs':
          return true
        default:
          return false
      }
    },
  }
}
</script>
<style scoped>
.bck {
  background-color: white;
}

.textStyle {
  font-size: 1.2rem;
  font-weight: bold;
}
</style>