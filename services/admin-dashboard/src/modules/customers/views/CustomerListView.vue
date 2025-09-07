<template>
  <div>
    <!-- Dashboard Cards -->
    <div class="grid grid-cols-1 md:grid-cols-3 gap-6 mb-6">
      <div class="bg-white p-6 rounded-lg shadow">
        <h3 class="text-lg font-medium text-gray-500">Total Customers</h3>
        <p class="text-3xl font-bold text-primary">1,234</p>
      </div>
      <div class="bg-white p-6 rounded-lg shadow">
        <h3 class="text-lg font-medium text-gray-500">Active Members</h3>
        <p class="text-3xl font-bold text-secondary">890</p>
      </div>
      <div class="bg-white p-6 rounded-lg shadow">
        <h3 class="text-lg font-medium text-gray-500">New Signups (Month)</h3>
        <p class="text-3xl font-bold text-tertiary">56</p>
      </div>
    </div>

    <!-- Customer Table Section -->
    <div class="bg-white p-6 rounded-lg shadow">
      <div class="flex justify-between items-center mb-4">
        <h2 class="text-2xl font-bold text-gray-800">Customer List</h2>
        <el-button type="primary" @click="handleAdd">Add Customer</el-button>
      </div>
      <CustomerTable @edit="handleEdit" />
    </div>

    <CustomerForm
      :visible="formVisible"
      :customer="selectedCustomer"
      @update:visible="formVisible = $event"
    />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import CustomerTable from '../components/CustomerTable.vue'
import CustomerForm from '../components/CustomerForm.vue'
import type { Customer } from '../types'

const formVisible = ref(false)
const selectedCustomer = ref<Partial<Customer>>({})

const handleAdd = () => {
  selectedCustomer.value = {}
  formVisible.value = true
}

const handleEdit = (customer: Customer) => {
  selectedCustomer.value = customer
  formVisible.value = true
}
</script>
