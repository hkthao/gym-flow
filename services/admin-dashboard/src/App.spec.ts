import { describe, it, expect } from 'vitest'
import { mount } from '@vue/test-utils'
import App from '@/App.vue'

describe('App.vue', () => {
  it('renders', () => {
    const wrapper = mount(App, {
      global: {
        stubs: {
          'DashboardLayout': true
        }
      }
    })
    expect(wrapper.exists()).toBe(true)
  })
})
