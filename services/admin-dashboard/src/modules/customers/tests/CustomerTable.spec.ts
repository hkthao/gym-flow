import { describe, it, expect, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerTable from '../components/CustomerTable.vue'
import { useCustomerStore } from '../stores/customerStore'
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
                  { id: 1, fullName: 'John Doe', phone: '111', email: 'a@a.com', gender: 'Male', membershipStatus: 'Active' }
                ],
                total: 1,
                currentPage: 1,
                pageSize: 10,
                loading: false
              }
            }
          })
        ]
      }
    })
    const store = useCustomerStore()
    return { wrapper, store }
  }

  it('fetches customers on options update (simulating mount)', () => {
    const { store } = mountComponent()
    // v-data-table emits `update:options` on mount, which triggers this
    expect(store.fetchCustomers).toHaveBeenCalledTimes(1)
  })

  it('displays customer data in the table', () => {
    const { wrapper } = mountComponent()
    const dataTable = wrapper.findComponent({ name: 'VDataTable' })
    expect(dataTable.props('items')).toHaveLength(1)
    expect(dataTable.props('items')[0].fullName).toBe('John Doe')
  })

  it('emits edit event when handleEdit is called', async () => {
    const { wrapper, store } = mountComponent()
    const customer = store.customers[0]
    
    // Since icons inside v-data-table are hard to target, we test the method directly
    wrapper.vm.handleEdit(customer)
    await nextTick()
    
    expect(wrapper.emitted('edit')).toBeTruthy()
    expect(wrapper.emitted('edit')[0][0]).toEqual(customer)
  })

  it('opens delete dialog when openDeleteDialog is called', async () => {
    const { wrapper, store } = mountComponent()
    const customer = store.customers[0]
    
    wrapper.vm.openDeleteDialog(customer)
    await nextTick()
    
    expect(wrapper.vm.deleteDialog).toBe(true)
    expect(wrapper.vm.itemToDelete).toEqual(customer)
  })

  it('calls deleteCustomer when delete is confirmed', async () => {
    const { wrapper, store } = mountComponent()
    const customer = store.customers[0]
    
    wrapper.vm.openDeleteDialog(customer) // Open dialog first
    await nextTick()
    wrapper.vm.confirmDelete() // Then confirm
    await nextTick()
    
    expect(store.deleteCustomer).toHaveBeenCalledWith(customer.id)
    expect(wrapper.vm.deleteDialog).toBe(false)
  })
})
