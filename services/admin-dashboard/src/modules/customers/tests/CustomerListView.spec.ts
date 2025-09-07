import { describe, it, expect, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerListView from '../views/CustomerListView.vue'
import CustomerTable from '../components/CustomerTable.vue'

describe('CustomerListView.vue', () => {
  const mountComponent = () => {
    return mount(CustomerListView, {
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn
          })
        ],
        // Use real components where possible, shallow mount others
        shallow: true,
      }
    })
  }

  it('renders dashboard cards and customer table', () => {
    const wrapper = mountComponent()
    // Check if cards and table are rendered
    expect(wrapper.findAllComponents({ name: 'VCard' }).length).toBe(5) // 4 stat cards + 1 table card
    expect(wrapper.findComponent(CustomerTable).exists()).toBe(true)
  })

  it('opens the form when add button is clicked', async () => {
    const wrapper = mountComponent()
    const addButton = wrapper.find('[data-testid="add-customer-btn"]')
    await addButton.trigger('click')
    expect(wrapper.vm.formVisible).toBe(true)
    expect(wrapper.vm.selectedCustomer).toEqual({})
  })

  it('opens the form with customer data when edit event is received from table', async () => {
    const wrapper = mountComponent()
    const customerTable = wrapper.findComponent(CustomerTable)
    const customerData = { id: 1, fullName: 'Test User' }
    
    // Simulate the edit event from the child component
    await customerTable.vm.$emit('edit', customerData)
    
    expect(wrapper.vm.formVisible).toBe(true)
    expect(wrapper.vm.selectedCustomer).toEqual(customerData)
  })
})