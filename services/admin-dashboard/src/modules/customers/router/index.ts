import type { RouteRecordRaw } from 'vue-router'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/customers',
    name: 'Customers',
    component: () => import('../views/CustomerListView.vue')
  }
]

export default routes
