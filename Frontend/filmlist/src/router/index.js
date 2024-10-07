import { createRouter, createWebHistory } from 'vue-router';
import Loginview from '../views/LoginView.vue';
import ListView from '../views/ListView.vue';

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
          {
            path: '/login',
            name: 'Login',
            component: Loginview
          },
          {
            path: '/List',
            name: 'List',
            component: ListView
          },
    ]
})

export default router
