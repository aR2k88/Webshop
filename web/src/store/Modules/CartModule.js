import axios from "axios";
export default {
    state: {
        cart: {}
    },
    getters: {
        
    },
    mutations: {
        updateCart(state, cart){
            state.cart = cart;
        }
    },
    actions: {
       addToCart(state, payload){
           let newCartitem = {
               CartId: payload.cartId,
               Product: payload.product
           }
           axios.post(`api/cart/add`, newCartitem).then(response => {
               state.commit("updateCart", response.data)
           })
       }
    }
}