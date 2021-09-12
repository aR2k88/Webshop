import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Hjem',
    component: () => import('../views/Home.vue')
  },
  {
    path: '/produkter',
    name: 'Produkter',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/Products.vue')
  },
  {
    path: '/historie',
    name: 'Historie',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/History.vue')
  },
  {
    path: '/kontakt',
    name: 'Kontakt',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/Contact.vue')
  },
  {
    path: '/kasse',
    name: 'Kasse',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/Checkout.vue')
  },
  // {
  //   path: '/:category/:productUrl',
  //   name: 'Produkt',
  //   // route level code-splitting
  //   // this generates a separate chunk (about.[hash].js) for this route
  //   // which is lazy-loaded when the route is visited.
  //   component: () => import(/* webpackChunkName: "about" */ '../views/Product.vue')
  // },
  {
    path: '/Admin',
    name: 'Admin',
    component: () => import(/* webpackChunkName: "about" */ '../views/admin/Dashboard.vue')
  },
  {
    path: '/Admin/Login',
    name: 'Login',
    component: () => import(/* webpackChunkName: "about" */ '../views/admin/Login.vue')
  },
  { path: "/*", 
    name: "NotFound",
    component: () => import(/* webpackChunkName: "about" */ '../views/PageNotFound.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
