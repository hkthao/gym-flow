import { describe, it, expect } from 'vitest'
import { mount } from '@vue/test-utils'
import AboutView from '@/views/AboutView.vue'

describe('AboutView.vue', () => {
  it('renders', () => {
    const wrapper = mount(AboutView)
    expect(wrapper.exists()).toBe(true)
  })
})
