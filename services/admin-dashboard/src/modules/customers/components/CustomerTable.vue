<template>
  <div>
    <div class="mb-4">
      <el-input v-model="search" placeholder="Search by name" class="w-64 mr-4" />
      <el-button type="primary" @click="fetchCustomers">Search</el-button>
    </div>

    <el-table :data="customers" style="width: 100%">
      <el-table-column prop="fullName" label="Full Name" />
      <el-table-column prop="phone" label="Phone" />
      <el-table-column prop="email" label="Email" />
      <el-table-column prop="gender" label="Gender" />
      <el-table-column prop="membershipStatus" label="Membership Status" />
      <el-table-column label="Actions">
        <template #default="scope">
          <el-button size="small" @click="handleEdit(scope.row)">Edit</el-button>
          <el-popconfirm
            title="Are you sure to delete this?"
            @confirm="handleDelete(scope.row.id)"
          >
            <template #reference>
              <el-button size="small" type="danger">Delete</el-button>
            </template>
          </el-popconfirm>
        </template>
      </el-table-column>
    </el-table>

    <el-pagination
      class="mt-4"
      :current-page="currentPage"
      :page-size="pageSize"
      :total="total"
      @current-change="handlePageChange"
    />
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useCustomerStore } from '../stores/customerStore'
import { storeToRefs } from 'pinia'
import type { Customer } from '../types'

const emit = defineEmits(['edit'])

const customerStore = useCustomerStore()
const { customers, total, currentPage, pageSize } = storeToRefs(customerStore)
const { fetchCustomers, deleteCustomer } = customerStore

const search = ref('')

onMounted(() => {
  fetchCustomers()
})

const handlePageChange = (page: number) => {
  currentPage.value = page
  fetchCustomers()
}

const handleEdit = (customer: Customer) => {
  emit('edit', customer)
}

const handleDelete = (id: number) => {
  deleteCustomer(id)
}
</script>
