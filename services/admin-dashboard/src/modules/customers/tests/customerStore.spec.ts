import { describe, it, expect, beforeEach } from 'vitest'
import { setActivePinia, createPinia } from 'pinia'
import { useCustomerStore } from '../stores/customerStore'

describe('Customer Store', () => {
  beforeEach(() => {
    setActivePinia(createPinia())
  })

  it('fetches customers', async () => {
    const store = useCustomerStore()
    await store.fetchCustomers()
    expect(store.customers.length).toBeGreaterThan(0)
  })

  it('deletes a customer', async () => {
    const store = useCustomerStore()
    await store.fetchCustomers()
    const initialCount = store.customers.length
    await store.deleteCustomer(1)
    expect(store.customers.length).toBe(initialCount - 1)
  })
})
