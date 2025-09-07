<template>
  <div>
    <!-- Dashboard Cards -->
    <div class="grid grid-cols-1 sm:grid-cols-2 xl:grid-cols-4 gap-6 mb-6">
      <div class="bg-white p-6 rounded-lg shadow-md">
        <h3 class="text-lg font-medium text-body">Total Customers</h3>
        <p class="text-3xl font-bold text-dark">1,234</p>
      </div>
      <div class="bg-white p-6 rounded-lg shadow-md">
        <h3 class="text-lg font-medium text-body">Active Members</h3>
        <p class="text-3xl font-bold text-success">890</p>
      </div>
      <div class="bg-white p-6 rounded-lg shadow-md">
        <h3 class="text-lg font-medium text-body">Inactive Members</h3>
        <p class="text-3xl font-bold text-warning">344</p>
      </div>
      <div class="bg-white p-6 rounded-lg shadow-md">
        <h3 class="text-lg font-medium text-body">New Signups (Month)</h3>
        <p class="text-3xl font-bold text-info">56</p>
      </div>
    </div>

    <!-- Customer Table Section -->
    <div class="bg-white p-6 rounded-lg shadow-md">
      <div class="flex justify-between items-center mb-4">
        <h2 class="text-2xl font-bold text-dark">Customer List</h2>
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
