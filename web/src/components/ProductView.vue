<template>
  <v-layout row :class="layoutClass">
    <v-flex xs12 sm12 md6 lg6>
      <v-img
          src="/Image 2.png"
          :max-width="imageWidth"
          class="mx-auto"
      ></v-img>
    </v-flex>
    <v-flex xs12 sm12 md6 lg6 class="text-left">
      <v-flex lg7>
        <div>
          <h1>{{ currentProduct.name }}</h1>
        </div>
        <div class="mb-4">
          <h3> {{ currentProduct.price }} nok</h3>
        </div>
        <v-divider class="black"></v-divider>
        <div class="mt-4">
      <span class="description">
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
      </span>
        </div>
        <div>
          <p class="mt-2">Størrelse: 123x23</p>
        </div>
        <div class="mb-5">
          <BuyButton :btnText="'Kjøp nå'"></BuyButton>
        </div>
        <v-divider class="black"></v-divider>
      </v-flex>
    </v-flex>


  </v-layout>
</template>

<script>
import BuyButton from "@/components/Buttons/BuyButton";
export default {
  name: "ProductView",
  components: {BuyButton},
  computed: {
    currentProduct() {
      return this.$store.state.ProductModule.currentProduct;
    },
    imageWidth() {
      if (this.$vuetify.breakpoint.name === "xs" || this.$vuetify.breakpoint.name === "sm") return "100%"
      return "90%";
    }
  },
  methods: {
    layoutClass() {
      switch (this.$vuetify.breakpoint.name) {
        case 'xs':
          return "mr-5 ml-5"
        case 'sm':
          return "mr-5 ml-5"
        case 'md':
          return "mr-5 ml-5"
        case 'lg':
          return ""
        case 'xl':
          return ""
      }
    },
  }
}

</script>

<style scoped>

.description {
  font-size:1.3rem;
}

</style>