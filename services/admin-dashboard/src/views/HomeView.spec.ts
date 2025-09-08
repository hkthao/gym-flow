import { describe, it, expect } from 'vitest'
import { mount } from '@vue/test-utils'
import HomeView from '@/views/HomeView.vue'

describe('HomeView.vue', () => {
  it('renders', () => {
    const wrapper = mount(HomeView)
    expect(wrapper.exists()).toBe(true)
  })
})
