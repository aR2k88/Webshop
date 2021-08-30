import Vue from 'vue'
import Vuex from 'vuex'
import ProductModule from './Modules/ProductModule'
import CartModule from "@/store/Modules/CartModule";



Vue.use(Vuex)

export default new Vuex.Store({
  state: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    ProductModule,
    CartModule
  }
})
