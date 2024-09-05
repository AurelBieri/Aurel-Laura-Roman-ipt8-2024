import { createRouter, createWebHistory } from 'vue-router'
import Loginview from '../views/LoginView.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'List',
            component: ListView
          },,
          {
            path: '/login',
            name: 'Login',
            component: Loginview
          },
    ]
})

export default router
