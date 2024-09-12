import { createRouter, createWebHistory } from 'vue-router'
import Loginview from '../views/LoginView.vue'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'Home',
            component: HomeView
          },,
          {
            path: '/login',
            name: 'Login',
            component: Loginview
          },
    ]
})

export default router
