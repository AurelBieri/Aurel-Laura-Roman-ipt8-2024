import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '@/views/HomePage.vue';
import WatchlistPage from '@/views/WatchlistPage.vue';
import Loginview from '../views/LoginView.vue';
import ListView from '../views/ListView.vue';
import RegisterView from '@/views/RegisterView.vue';

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
    props: true, 
  },
  {
    path: '/login',
    name: 'Login',
    component: Loginview
  },
  {
    path: '/List',
    name: 'List',
    component: ListView,
    meta: {requiresAuth: true}
  },
  {
    path: '/register',
    name: 'register',
    component: RegisterView
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach((to, from, next) => {
  const isAuthenticated = localStorage.getItem("session_token");

  if (to.meta.requiresAuth && !isAuthenticated) {
    next("/login");
  } else {
    next();
  }
});

export default router;