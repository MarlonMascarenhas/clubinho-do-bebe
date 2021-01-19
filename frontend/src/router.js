import Vue from 'vue';
import Router from 'vue-router';

import Home from './components/Home.vue';
import Clientes from './components/Clientes.vue';
import Produtos from './components/Produtos.vue';
import Login from './components/Login.vue';

Vue.use(Router);

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  linkActiveClass: 'active',
  linkExactActiveClass: 'exact-active',
  scrollBehavior() {
    return { x: 0, y: 0 };
  },
  routes: [
    {
      path: '*',
      redirect: '/login',
    },
    {
      path: '/',
      redirect: '/login',
    },
    {
      path: '/login',
      name: 'Login',
      component: Login,
    },
    {
      path: '/home',
      name: 'home',
      component: Home,
      meta: { requiresAuth: false },
    },
    {
      path: '/clientes',
      name: 'clientes',
      component: Clientes,
      meta: { requiresAuth: false },
    },
    {
      path: '/produtos',
      name: 'produtos',
      component: Produtos,
      meta: { requiresAuth: false },
    }
  ],
});

export default router;