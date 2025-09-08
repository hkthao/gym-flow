import { defineStore } from 'pinia'
import { ref } from 'vue'
import type { Customer } from '@/modules/customers/types'
import axios from 'axios'

// The API is always accessed from the browser, so it must use the host's localhost and exposed port.
const API_URL = 'http://localhost:5001/api/customers';

export const useCustomerStore = defineStore('customer', () => {
  const customers = ref<Customer[]>([])
  const total = ref(0)
  const currentPage = ref(1)
  const pageSize = ref(10)
  const loading = ref(false)
  const statusFilter = ref('All')
  const search = ref('')

  const fetchCustomers = async () => {
    loading.value = true
    try {
      const params = new URLSearchParams()
      params.append('pageNumber', currentPage.value.toString())
      params.append('pageSize', pageSize.value.toString())
      if (search.value) {
        params.append('search', search.value)
      }
      if (statusFilter.value !== 'All') {
        params.append('status', statusFilter.value)
      }

      const response = await axios.get(API_URL, { params })
      customers.value = response.data.data
      total.value = response.data.pagination.totalRecords
    } catch (error) {
      console.error('Failed to fetch customers:', error)
      // Handle error appropriately in a real app
    } finally {
      loading.value = false
    }
  }

  const addCustomer = async (customer: Omit<Customer, 'id'>) => {
    try {
      await axios.post(API_URL, customer)
      await fetchCustomers() // Refresh data
    } catch (error) {
      console.error('Failed to add customer:', error)
    }
  }

  const updateCustomer = async (customer: Customer) => {
    try {
      await axios.put(`${API_URL}/${customer.id}`, customer)
      await fetchCustomers() // Refresh data
    } catch (error) {
      console.error('Failed to update customer:', error)
    }
  }

  const deleteCustomer = async (id: number) => {
    try {
      await axios.delete(`${API_URL}/${id}`)
      await fetchCustomers() // Refresh data
    } catch (error) {
      console.error('Failed to delete customer:', error)
    }
  }

  return {
    customers,
    total,
    currentPage,
    pageSize,
    loading,
    statusFilter,
    search,
    fetchCustomers,
    addCustomer,
    updateCustomer,
    deleteCustomer
  }
})
