import { describe, it, expect, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerTable from '../components/CustomerTable.vue'

describe('CustomerTable.vue', () => {
  it('renders', () => {
    const wrapper = mount(CustomerTable, {
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
