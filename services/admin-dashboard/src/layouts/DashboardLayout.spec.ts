import { describe, it, expect, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import DashboardLayout from '@/layouts/DashboardLayout.vue'
import { VApp, VNavigationDrawer, VAppBar } from 'vuetify/components'

// Mock the router
const mockRouter = {
  push: vi.fn()
}

vi.mock('vue-router', () => ({
  useRouter: () => mockRouter
}))

describe('DashboardLayout.vue', () => {
  // Reset mock before each test
  vi.clearAllMocks()

  const mountComponent = () => {
    return mount(DashboardLayout, {
      global: {
        stubs: {
          'router-view': true
        }
      }
    })
  }

  it('renders the main layout components', () => {
    const wrapper = mountComponent()
    expect(wrapper.findComponent(VApp).exists()).toBe(true)
    expect(wrapper.findComponent(VNavigationDrawer).exists()).toBe(true)
    expect(wrapper.findComponent(VAppBar).exists()).toBe(true)
  })

  it('navigates to profile page on profile click', async () => {
    const wrapper = mountComponent()
    wrapper.vm.goToProfile()
    expect(mockRouter.push).toHaveBeenCalledWith('/profile')
  })

  it('navigates to login page on logout click', async () => {
    const wrapper = mountComponent()
    wrapper.vm.logout()
    expect(mockRouter.push).toHaveBeenCalledWith('/login')
  })
})