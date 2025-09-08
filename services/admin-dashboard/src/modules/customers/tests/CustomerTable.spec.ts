import { describe, it, expect, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerTable from '@/modules/customers/components/CustomerTable.vue'
import { useCustomerStore } from '@/modules/customers/stores/customerStore'
import { nextTick } from 'vue'

describe('CustomerTable.vue', () => {
  const mountComponent = () => {
    const wrapper = mount(CustomerTable, {
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn,
            initialState: {
              customer: {
                customers: [
                  { id: 1, fullName: 'John Doe', membershipStatus: 'Active' },
                  { id: 2, fullName: 'Jane Smith', membershipStatus: 'Inactive' }
                ],
                total: 2,
                statusFilter: 'All'
              }
            }
          })
        ]
      }
    })
    const store = useCustomerStore()
    return { wrapper, store }
  }

  it('fetches customers on mount', () => {
    const { store } = mountComponent()
    expect(store.fetchCustomers).toHaveBeenCalled()
  })

  it('displays customer data', () => {
    const { wrapper } = mountComponent()
    const dataTable = wrapper.findComponent({ name: 'VDataTableServer' })
    expect(dataTable.props('items')).toHaveLength(2)
  })

  it('emits edit event', async () => {
    const { wrapper, store } = mountComponent()
    const customer = store.customers[0]
    wrapper.vm.handleEdit(customer)
    await nextTick()
    expect(wrapper.emitted('edit')).toBeTruthy()
  })

  it('opens delete dialog', async () => {
    const { wrapper, store } = mountComponent()
    const customer = store.customers[0]
    wrapper.vm.openDeleteDialog(customer)
    await nextTick()
    expect(wrapper.vm.deleteDialog).toBe(true)
  })

  it('calls deleteCustomer on confirm', async () => {
    const { wrapper, store } = mountComponent()
    const customer = store.customers[0]
    wrapper.vm.openDeleteDialog(customer)
    await nextTick()
    wrapper.vm.confirmDelete()
    await nextTick()
    expect(store.deleteCustomer).toHaveBeenCalledWith(customer.id)
  })

  it('refetches when filter changes', async () => {
    const { wrapper, store } = mountComponent()
    const initialFetchCount = store.fetchCustomers.mock.calls.length
    
    // Simulate user changing the filter
    const select = wrapper.findComponent({ name: 'VSelect' })
    await select.vm.$emit('update:modelValue', 'Active')
    
    expect(store.statusFilter).toBe('Active')
    expect(store.fetchCustomers).toHaveBeenCalledTimes(initialFetchCount + 1)
  })
})