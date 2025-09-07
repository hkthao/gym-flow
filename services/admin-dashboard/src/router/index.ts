import { createRouter, createWebHistory } from 'vue-router'
import customerRoutes from '../modules/customers/router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: '/customers'
    },
    ...customerRoutes
  ]
})

export default router
