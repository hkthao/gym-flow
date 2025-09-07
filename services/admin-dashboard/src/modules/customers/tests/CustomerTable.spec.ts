import { describe, it, expect, vi, beforeEach } from 'vitest'
import { mount, VueWrapper } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerTable from '../components/CustomerTable.vue'
import { useCustomerStore } from '../stores/customerStore'
import { nextTick } from 'vue'

describe('CustomerTable.vue', () => {
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  let wrapper: VueWrapper<any>
  let store: ReturnType<typeof useCustomerStore>

  beforeEach(() => {
    wrapper = mount(CustomerTable, {
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn,
          }),
        ],
        stubs: {
          'el-table': false, // Use real component
          'el-table-column': false,
          'el-button': false,
          'el-popconfirm': false,
          'el-pagination': false,
          'el-input': false,
        }
      },
    })
    store = useCustomerStore()
  })

  it('fetches customers on mount', () => {
    expect(store.fetchCustomers).toHaveBeenCalledTimes(1)
  })

  it('displays customer data', async () => {
    const customer = { id: 1, fullName: 'John Doe' }
    store.customers = [customer]
    await nextTick()
    expect(wrapper.text()).toContain('John Doe')
  })

  it('emits edit event when edit button is clicked', async () => {
    const customer = { id: 1, fullName: 'John Doe' }
    store.customers = [customer]
    await nextTick()
    const editButton = wrapper.findAll('.el-button').find(b => b.text() === 'Edit')
    await editButton!.trigger('click')
    expect(wrapper.emitted('edit')).toBeTruthy()
    expect(wrapper.emitted('edit')![0][0]).toEqual(customer)
  })

  it('calls deleteCustomer when delete is confirmed', () => {
    wrapper.vm.handleDelete(1)
    expect(store.deleteCustomer).toHaveBeenCalledWith(1)
  })

  it('handles page changes', async () => {
    await wrapper.vm.handlePageChange(2)
    expect(store.currentPage).toBe(2)
    expect(store.fetchCustomers).toHaveBeenCalledTimes(2)
  })
})
