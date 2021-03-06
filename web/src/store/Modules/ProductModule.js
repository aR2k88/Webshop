import axios from "axios";
export default {
    state: {
        products: [],
        currentProduct: {},
    },
    getters: {
    },
    mutations: {
        setProducts(state, products){
            state.products = products;
        },
        setCurrentProduct(state, product){
            state.currentProduct = product;
        }
    },
    actions: {
        async fetchProducts(state){
         axios.get('/api/product').then(response => {
             state.commit("setProducts", response.data)
         });
        },
        async fetchProductByUrl(state, payload){
            axios.get(`api/product/url/${payload.productUrl}`).then(response => {
                state.commit("setCurrentProduct", response.data)
            });
        },
    }
}