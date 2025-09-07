import { describe, it, expect, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerForm from '../components/CustomerForm.vue'

describe('CustomerForm.vue', () => {
  it('renders', () => {
    const wrapper = mount(CustomerForm, {
      props: {
        visible: true
      },
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn
          })
        ]
      }
    })
    expect(wrapper.exists()).toBe(true)
  })
})
