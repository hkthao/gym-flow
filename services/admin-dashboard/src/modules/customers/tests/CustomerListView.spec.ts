import { describe, it, expect, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerListView from '../views/CustomerListView.vue'
import CustomerTable from '../components/CustomerTable.vue'

describe('CustomerListView.vue', () => {
  it('opens the form when add button is clicked', async () => {
    const wrapper = mount(CustomerListView, {
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn
          })
        ],
        stubs: {
          'CustomerForm': true
        }
      }
    })

    await wrapper.find('.el-button').trigger('click')
    expect(wrapper.vm.formVisible).toBe(true)
  })

  it('opens the form with customer data when edit event is received', async () => {
    const wrapper = mount(CustomerListView, {
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn
          })
        ],
        stubs: {
          'CustomerForm': true
        }
      }
    })

    const customer = { id: 1, name: 'John Doe' }
    await wrapper.findComponent(CustomerTable).vm.$emit('edit', customer)
    expect(wrapper.vm.formVisible).toBe(true)
    expect(wrapper.vm.selectedCustomer).toEqual(customer)
  })
})
