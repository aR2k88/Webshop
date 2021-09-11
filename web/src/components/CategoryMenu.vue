<template>
  <v-row row>
    <v-col v-for="cat in allCategories" :key="cat">
      <v-btn text @click="filterCat(cat)"><span>{{cat}}</span></v-btn>
    </v-col>
  </v-row>
</template>

<script>
import axios from "axios";

export default {
  name: "CategoryMenu",
  data() {
    return {
      allCategories: [],
    }
  },
  methods: {
    filterCat(cat) {
      this.$emit("filterCat", cat);
    }
  },
  mounted() {
    axios.get(`api/product/categories`).then(response => {
      this.allCategories = response.data;
    })
  }
}
</script>

<style scoped>
.v-btn {
  font-size:1.1rem
}
.v-btn--active{
  text-decoration: underline;
}
.v-btn::before {
  background-color: #F0EFED;
}


</style>