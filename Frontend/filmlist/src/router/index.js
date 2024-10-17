import Vue from 'vue';
import VueRouter from 'vue-router';
import HomePage from '@/views/HomePage.vue';
import Watchlist from '@/views/Watchlist.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomePage,
  },
  {
    path: '/watchlist/:id',
    name: 'Watchlist',
    component: Watchlist,
  },
];

const router = new VueRouter({
  mode: 'history',
  routes,
});

export default router;
