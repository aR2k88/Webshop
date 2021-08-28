import axios from "axios";
export default {
    state: {
        products: []
    },
    getters: {
        getProducts(state) {
            console.log(state.products)
            return state.products;
        }
    },
    mutations: {
        setProducts(state, products){
            state.products = products;
        }
    },
    actions: {
        async fetchProducts(state){
         axios.get('/api/product').then(response => {
             state.commit("setProducts", response.data)
         });
        }
    }
}