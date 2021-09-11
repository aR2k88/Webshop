<template>
  <v-container>
    <CategoryMenu @filterCat="filterCategory"></CategoryMenu>
    <ProductList :productList="filteredProducts"></ProductList>
  </v-container>
</template>

<script>
import ProductList from "@/components/ProductList";
import CategoryMenu from "@/components/CategoryMenu";

export default {
  name: "Products",
  components: {ProductList, CategoryMenu},
  data() {
    return {
      currentFilter: '',
    }
  },
  mounted() {
    let urlCategory = this.$route.query.kategori;
    if(urlCategory !== undefined) this.currentFilter = urlCategory.toLowerCase();

  },
  methods: {
    filterCategory(cat) {
      if (this.currentFilter === cat) this.currentFilter = ''
      else
        this.currentFilter = cat;
    }
  },
  computed: {
    products() {
      return this.$store.state.ProductModule.products;
    },
    filteredProducts() {
      if(this.currentFilter === '') return this.$store.state.ProductModule.products;
      return this.$store.state.ProductModule.products.filter(x => x.category.toLowerCase() === this.currentFilter.toLowerCase());
    }
  }
}
</script>

<style scoped>

</style>