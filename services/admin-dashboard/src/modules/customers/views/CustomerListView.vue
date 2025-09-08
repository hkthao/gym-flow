<template>
  <div>
    <!-- Dashboard Cards -->
    <v-row>
      <v-col cols="12" sm="6" xl="3">
        <v-card>
          <v-card-title class="text-subtitle-1">Total Customers</v-card-title>
          <v-card-text class="text-h4 font-weight-bold">1,234</v-card-text>
        </v-card>
      </v-col>
      <v-col cols="12" sm="6" xl="3">
        <v-card>
          <v-card-title class="text-subtitle-1">Active Members</v-card-title>
          <v-card-text class="text-h4 font-weight-bold text-success">890</v-card-text>
        </v-card>
      </v-col>
      <v-col cols="12" sm="6" xl="3">
        <v-card>
          <v-card-title class="text-subtitle-1">Inactive Members</v-card-title>
          <v-card-text class="text-h4 font-weight-bold text-warning">344</v-card-text>
        </v-card>
      </v-col>
      <v-col cols="12" sm="6" xl="3">
        <v-card>
          <v-card-title class="text-subtitle-1">New Signups (Month)</v-card-title>
          <v-card-text class="text-h4 font-weight-bold text-info">56</v-card-text>
        </v-card>
      </v-col>
    </v-row>

    <!-- Customer Table Section -->
    <v-card class="mt-6">
      <v-card-title>
        <div class="d-flex justify-space-between align-center">
          <h2 class="text-h5">Customer List</h2>
          <v-btn color="primary" @click="handleAdd" data-testid="add-customer-btn">Add Customer</v-btn>
        </div>
      </v-card-title>
      <v-card-text>
        <CustomerTable @edit="handleEdit" />
      </v-card-text>
    </v-card>

    <CustomerForm
      :visible="formVisible"
      :customer="selectedCustomer"
      @update:visible="formVisible = $event"
      @submitted="handleFormSubmitted"
    />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import CustomerTable from '../components/CustomerTable.vue'
import CustomerForm from '../components/CustomerForm.vue'
import type { Customer } from '../types'

import { useCustomerStore } from '@/modules/customers/stores/customerStore'

const formVisible = ref(false)
const selectedCustomer = ref<Partial<Customer> | null>(null)
const store = useCustomerStore()

const handleAdd = () => {
  selectedCustomer.value = {}
  formVisible.value = true
}

const handleEdit = (customer: Customer) => {
  selectedCustomer.value = { ...customer }
  formVisible.value = true
}

const handleFormSubmitted = () => {
  store.fetchCustomers()
}
</script>