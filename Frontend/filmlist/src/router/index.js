import { createRouter, createWebHistory } from 'vue-router';
import Loginview from '../views/LoginView.vue';
import ListView from '../views/ListView.vue';

const router = createRouter({
    history: createWebHistory('/'),
    routes: [
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
    ]
})

router.beforeEach((to, from, next) => {
  const isAuthenticated = localStorage.getItem('session_token'); 

  if (to.meta.requiresAuth && !isAuthenticated) {
    next('/login'); 
  } else {
    next();
  }
});

export default router
