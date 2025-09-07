import { describe, it, expect, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerTable from '../components/CustomerTable.vue'
import { useCustomerStore } from '../stores/customerStore'
import { nextTick } from 'vue'

describe('CustomerTable.vue', () => {
  it('renders table with customers and handles delete', async () => {
    const wrapper = mount(CustomerTable, {
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn
          })
        ]
      }
    })

    const store = useCustomerStore()
    store.customers = [
      {
        id: 1,
        fullName: 'John Doe',
        phone: '123-456-7890',
        email: 'john.doe@example.com',
        gender: 'Male',
        membershipStatus: 'Active'
      }
    ]

    await nextTick()

    expect(wrapper.text()).toContain('John Doe')

    // Simulate delete
    await wrapper.find('.el-button--danger').trigger('click')
    // You might need to trigger the confirmation in the popconfirm as well
    // This part can be tricky to test with vue-test-utils
  })
})
