import axios from "axios";
export default {
    state: {
        cart: {}
    },
    getters: {
        getProductCount(state){
            if(state.cart.cartItems === undefined) return 0;
            console.log(state.cart)
            if(state.cart.cartItems.length < 1) return 0;
            let count = 0;
            state.cart.cartItems.forEach(x => {
                count += x.number
            })
            return count;
        }
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