import { defineStore } from 'pinia'
import { ref } from 'vue'
import type { Customer } from '../types'

// Mock data for now
const mockCustomers: Customer[] = [
  {
    id: 1,
    fullName: 'John Doe',
    phone: '123-456-7890',
    email: 'john.doe@example.com',
    gender: 'Male',
    membershipStatus: 'Active'
  },
  {
    id: 2,
    fullName: 'Jane Smith',
    phone: '098-765-4321',
    email: 'jane.smith@example.com',
    gender: 'Female',
    membershipStatus: 'Inactive'
  }
]

export const useCustomerStore = defineStore('customer', () => {
  const customers = ref<Customer[]>([])
  const total = ref(0)
  const currentPage = ref(1)
  const pageSize = ref(10)

  const fetchCustomers = async () => {
    // In a real app, you would fetch this from an API
    customers.value = mockCustomers
    total.value = mockCustomers.length
  }

  const deleteCustomer = async (id: number) => {
    // In a real app, you would send a DELETE request to an API
    customers.value = customers.value.filter((c) => c.id !== id)
  }

  return {
    customers,
    total,
    currentPage,
    pageSize,
    fetchCustomers,
    deleteCustomer
  }
})
