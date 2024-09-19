import { createRouter, createWebHistory } from 'vue-router'; 
import HomeView from '../views/HomeView.vue'; // Home-Komponente
import WatchlistView from '../views/WatchlistView.vue'; // Watchlist-Komponente

const routes = [
  {
    path: '/', // Home-Seite
    name: 'Home',
    component: HomeView
  },
  {
    path: '/watchlist', // Watchlist-Seite
    name: 'Watchlist',
    component: WatchlistView
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
