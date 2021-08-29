import Vue from 'vue'
import './plugins/axios'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'
import store from './store'
import VueCookie from 'vue-cookie'

Vue.config.productionTip = false
Vue.use(VueCookie)

new Vue({
  vuetify,
  router,
  store,
  VueCookie,
  render: h => h(App)
}).$mount('#app')
