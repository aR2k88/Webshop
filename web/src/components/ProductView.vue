<template>
<v-container>
  <v-row>
    <v-col cols="6">
      <v-img>image</v-img>
    </v-col>
    <v-col cols="6">
      <h1>Product name</h1>
    </v-col>
  </v-row>
</v-container>
</template>

<script>
export default {
  name: "ProductView",
  props: ["product"],
  
}
</script>

<style scoped>

</style>