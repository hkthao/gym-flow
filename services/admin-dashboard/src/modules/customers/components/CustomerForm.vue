<template>
  <v-dialog :model-value="visible" @update:model-value="closeDialog" max-width="600px">
    <v-card>
      <v-card-title>
        <span class="text-h5">{{ form.id ? 'Edit Customer' : 'Add Customer' }}</span>
      </v-card-title>

      <v-card-text>
        <v-container>
          <v-form ref="formRef">
            <v-row>
              <v-col cols="12">
                <v-text-field v-model="form.fullName" label="Full Name" required></v-text-field>
              </v-col>
              <v-col cols="12" sm="6">
                <v-text-field v-model="form.phone" label="Phone"></v-text-field>
              </v-col>
              <v-col cols="12" sm="6">
                <v-text-field v-model="form.email" label="Email"></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-select
                  v-model="form.gender"
                  :items="['Male', 'Female']"
                  label="Gender"
                ></v-select>
              </v-col>
              <v-col cols="12">
                <v-textarea v-model="form.address" label="Address"></v-textarea>
              </v-col>
            </v-row>
          </v-form>
        </v-container>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue-darken-1" variant="text" @click="closeDialog">Cancel</v-btn>
        <v-btn color="blue-darken-1" variant="text" @click="handleSubmit">Confirm</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import type { Customer } from '../types'
import { useCustomerStore } from '@/modules/customers/stores/customerStore'

const props = defineProps<{
  visible: boolean
  customer: Partial<Customer> | null
}>()

const emit = defineEmits(['update:visible', 'submitted'])
const store = useCustomerStore()

const form = ref<Partial<Customer>>({})

watch(
  () => props.customer,
  (newVal) => {
    if (newVal) {
      form.value = { ...newVal }
    } else {
      form.value = {}
    }
  },
  { immediate: true }
)

const closeDialog = () => {
  emit('update:visible', false)
}

const handleSubmit = async () => {
  if (form.value.id) {
    await store.updateCustomer(form.value as Customer)
  } else {
    await store.addCustomer(form.value as Omit<Customer, 'id'>)
  }
  emit('submitted')
  closeDialog()
}
</script>
