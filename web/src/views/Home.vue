<template>
  <div class="about">
    <h1>This is the home page</h1>
    <ProductList></ProductList>
  </div>
</template>

<script>
// @ is an alias to /src
import ProductList from "@/components/ProductList";
export default {
  name: 'Home',
  components: {
    ProductList
  }
}
</script>
