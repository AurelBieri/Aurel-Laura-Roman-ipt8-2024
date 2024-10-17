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
    path: '/watchlist/:id',
    name: 'Watchlist',
    component: WatchlistPage,
    props: true, // Übergibt die ID als Prop an die WatchlistPage
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
