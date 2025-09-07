import { setActivePinia, createPinia } from 'pinia'
import { describe, it, expect, vi, beforeEach } from 'vitest'
import { useCustomerStore } from '../stores/customerStore'
import axios from 'axios'

vi.mock('axios')

describe('Customer Store', () => {
  beforeEach(() => {
    setActivePinia(createPinia())
    vi.resetAllMocks()
  })

  it('fetches customers via API', async () => {
    const store = useCustomerStore()
    const mockData = {
      data: {
        data: [{ id: 1, fullName: 'Test' }],
        pagination: { totalRecords: 1 }
      }
    }
    vi.mocked(axios.get).mockResolvedValue(mockData)

    await store.fetchCustomers()

    expect(axios.get).toHaveBeenCalledWith('http://localhost:5001/api/customers', expect.any(Object))
    expect(store.customers).toEqual(mockData.data.data)
    expect(store.total).toBe(1)
  })

  it('deletes a customer via API and refetches', async () => {
    const store = useCustomerStore()
    // Since fetchCustomers is part of the action, we can't spy on it directly in this context.
    // Instead, we verify the side effect: the GET call for refetching.
    vi.mocked(axios.delete).mockResolvedValue({})
    vi.mocked(axios.get).mockResolvedValue({ data: { data: [], pagination: { totalRecords: 0 } } }) // Mock the refetch call

    await store.deleteCustomer(1)

    expect(axios.delete).toHaveBeenCalledWith('http://localhost:5001/api/customers/1')
    expect(axios.get).toHaveBeenCalledTimes(1) // Verify that a refetch was made
  })

  it('adds a customer via API and refetches', async () => {
    const store = useCustomerStore()
    const newCustomer = { fullName: 'New Guy' }
    vi.mocked(axios.post).mockResolvedValue({})
    vi.mocked(axios.get).mockResolvedValue({ data: { data: [], pagination: { totalRecords: 0 } } })

    await store.addCustomer(newCustomer)

    expect(axios.post).toHaveBeenCalledWith('http://localhost:5001/api/customers', newCustomer)
    expect(axios.get).toHaveBeenCalledTimes(1)
  })

  it('updates a customer via API and refetches', async () => {
    const store = useCustomerStore()
    const customer = { id: 1, fullName: 'Updated Guy' }
    vi.mocked(axios.put).mockResolvedValue({})
    vi.mocked(axios.get).mockResolvedValue({ data: { data: [], pagination: { totalRecords: 0 } } })

    await store.updateCustomer(customer)

    expect(axios.put).toHaveBeenCalledWith('http://localhost:5001/api/customers/1', customer)
    expect(axios.get).toHaveBeenCalledTimes(1)
  })
})