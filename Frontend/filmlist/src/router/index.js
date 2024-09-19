import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import WatchlistView from '../views/WatchlistView.vue';

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomeView
  },
  {
    path: '/watchlist',
    name: 'Watchlist',
    component: WatchlistView
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
