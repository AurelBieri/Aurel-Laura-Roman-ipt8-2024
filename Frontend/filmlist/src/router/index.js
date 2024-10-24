import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '@/views/HomePage.vue';
import WatchlistPage from '@/views/WatchlistPage.vue';

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomePage,
  },
  {
    path: '/watchlist/:id', // Dynamische Route für Watchlist
    name: 'Watchlist',
    component: WatchlistPage,
    props: true, // Übergibt die Route-Parameter als Props
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
