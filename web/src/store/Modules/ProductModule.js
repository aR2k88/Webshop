export default {
    state: {
        products: []
    },
    getters: {
        getProducts(state, getters) {
            return state.products;
        }
    },
    mutations: {
        
    },
    actions: {
        async fetchProducts(state, payload){
            
        }
    }
}