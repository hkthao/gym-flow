import { createRouter, createWebHistory } from 'vue-router'
import DashboardLayout from '@/layouts/DashboardLayout.vue'
import customerRoutes from '@/modules/customers/router'

// Placeholder components for demonstration
const CheckinView = { template: '<div>Check-in Page</div>' }
const FaceRecognitionView = { template: '<div>Face Recognition Page</div>' }
const ProfileView = { template: '<div>User Profile Page</div>' }
const LoginView = { template: '<div class="d-flex align-center justify-center" style="height: 100vh;"><h1>Login Page</h1></div>' }

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      component: DashboardLayout,
      redirect: '/customers',
      children: [
        ...customerRoutes,
        {
          path: 'checkin',
          name: 'checkin',
          component: CheckinView
        },
        {
          path: 'face-recognition',
          name: 'face-recognition',
          component: FaceRecognitionView
        },
        {
          path: 'profile',
          name: 'profile',
          component: ProfileView
        }
      ]
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    }
  ]
})

export default router
