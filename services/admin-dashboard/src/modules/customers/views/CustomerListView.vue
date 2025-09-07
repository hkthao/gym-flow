<template>
  <div>
    <div class="flex justify-between items-center mb-4">
      <h1 class="text-2xl font-bold">Customer Management</h1>
      <el-button type="primary" @click="handleAdd">Add Customer</el-button>
    </div>
    <CustomerTable @edit="handleEdit" />
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

const formVisible = ref(false)
const selectedCustomer = ref({})

const handleAdd = () => {
  selectedCustomer.value = {}
  formVisible.value = true
}

const handleEdit = (customer: any) => {
  selectedCustomer.value = customer
  formVisible.value = true
}
</script>
