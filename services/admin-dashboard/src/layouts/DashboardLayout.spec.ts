import { describe, it, expect } from 'vitest'
import { mount } from '@vue/test-utils'
import DashboardLayout from './DashboardLayout.vue'

describe('DashboardLayout.vue', () => {
  it('renders', () => {
    const wrapper = mount(DashboardLayout, {
      global: {
        stubs: {
          'router-view': true,
          'el-menu': true,
          'el-menu-item': true,
          'el-icon': true
        }
      }
    })
    expect(wrapper.exists()).toBe(true)
  })
})
