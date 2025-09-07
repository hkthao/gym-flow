<template>
  <div>
    <v-row class="mb-4" align="center">
      <v-col cols="12" md="4">
        <v-text-field
          v-model="search"
          label="Search by name"
          density="compact"
          variant="outlined"
          append-inner-icon="mdi-magnify"
          @click:append-inner="fetchCustomers"
          hide-details
        ></v-text-field>
      </v-col>
      <v-col cols="12" md="3">
        <v-select
          v-model="statusFilter"
          :items="['All', 'Active', 'Inactive']"
          label="Filter by status"
          density="compact"
          variant="outlined"
          hide-details
        ></v-select>
      </v-col>
    </v-row>

    <v-data-table
      :headers="headers"
      :items="customers"
      :loading="loading"
      :items-per-page="pageSize"
      :page="currentPage"
      :server-items-length="total"
      @update:options="handleOptionsUpdate"
    >
      <template #[`item.actions`]="{ item }">
        <v-icon small class="mr-2" @click="handleEdit(item)">mdi-pencil</v-icon>
        <v-icon small @click="openDeleteDialog(item)">mdi-delete</v-icon>
      </template>
    </v-data-table>

    <!-- Delete Confirmation Dialog -->
    <v-dialog v-model="deleteDialog" max-width="500px">
      <v-card>
        <v-card-title class="text-h5">Are you sure you want to delete this item?</v-card-title>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="deleteDialog = false">Cancel</v-btn>
          <v-btn color="blue darken-1" text @click="confirmDelete">OK</v-btn>
          <v-spacer></v-spacer>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, watch } from 'vue'
import { useCustomerStore } from '../stores/customerStore'
import { storeToRefs } from 'pinia'
import type { Customer } from '../types'

interface DataTableOptions {
  page: number
  itemsPerPage: number
  sortBy: string[]
  sortDesc: boolean[]
}

const emit = defineEmits(['edit'])

const customerStore = useCustomerStore()
const { customers, total, currentPage, pageSize, loading, statusFilter, search } = storeToRefs(customerStore)
const { fetchCustomers, deleteCustomer } = customerStore

const deleteDialog = ref(false)
const itemToDelete = ref<Customer | null>(null)

const headers = [
  { title: 'Full Name', key: 'fullName' },
  { title: 'Phone', key: 'phone' },
  { title: 'Email', key: 'email' },
  { title: 'Gender', key: 'gender' },
  { title: 'Membership Status', key: 'membershipStatus' },
  { title: 'Actions', key: 'actions', sortable: false }
]

// Watch for filter changes and refetch data
watch(statusFilter, () => {
  fetchCustomers()
})

onMounted(() => {
  // fetchCustomers will be called by handleOptionsUpdate on mount
})

const handleOptionsUpdate = (options: DataTableOptions) => {
  currentPage.value = options.page
  pageSize.value = options.itemsPerPage
  fetchCustomers()
}

const handleEdit = (customer: Customer) => {
  emit('edit', customer)
}

const openDeleteDialog = (item: Customer) => {
  itemToDelete.value = item
  deleteDialog.value = true
}

const confirmDelete = () => {
  if (itemToDelete.value) {
    deleteCustomer(itemToDelete.value.id)
  }
  deleteDialog.value = false
}
</script>
