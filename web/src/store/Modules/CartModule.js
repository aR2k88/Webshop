import axios from "axios";
import Vue from 'vue'
export default {
    state: {
        cart: {}
    },
    getters: {
        getProductCountInCart(state){
            if(state.cart.cartItems === undefined) return 0;
            if(state.cart.cartItems.length < 1) return 0;
            let count = 0;
            state.cart.cartItems.forEach(x => {
                count += x.quantity
            })
            return count;
        },
        GetSubTotalInCart(state) {
            if(state.cart.cartItems === undefined) return 0;
            if(state.cart.cartItems.length < 1) return 0;
            let sum = 0;
            state.cart.cartItems.forEach(x => {
                sum += x.product.price * x.quantity
            })
            return sum;
        }
    },
    mutations: {
        updateCart(state, cart){
            state.cart = cart;
            Vue.prototype.$cookie.set('cartId', cart._id, 1);
        }
    },
    actions: {
       async addToCart(state, payload){
           let newCartitem = {
               CartId: payload.cartId,
               Product: payload.product
           }
           axios.post(`api/cart/add`, newCartitem).then(response => {
               state.commit("updateCart", response.data)
           })
       },
        async removeFromCart(state, payload) {
           let cartItem = {
               CartId: payload.cartId,
               Product: payload.product
           }
           console.log(cartItem)
           axios.post(`api/cart/remove`, cartItem).then(response => {
               state.commit("updateCart", response.data)
           })
        },
        fetchCart(state, cartId) {
            axios.get(`api/cart/${cartId}`).then(response => {
                state.commit("updateCart", response.data)
            })
        }
    }
}