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
  const loading = ref(false)

  const fetchCustomers = async () => {
    loading.value = true
    // In a real app, you would fetch this from an API
    // Simulate API delay
    await new Promise((resolve) => setTimeout(resolve, 500))
    customers.value = mockCustomers
    total.value = mockCustomers.length
    loading.value = false
  }

  const deleteCustomer = async (id: number) => {
    // In a real app, you would send a DELETE request to an API
    customers.value = customers.value.filter((c) => c.id !== id)
    total.value = customers.value.length
  }

  return {
    customers,
    total,
    currentPage,
    pageSize,
    loading,
    fetchCustomers,
    deleteCustomer
  }
})
