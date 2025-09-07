<template>
  <el-dialog v-model="dialogVisible" :title="form.id ? 'Edit Customer' : 'Add Customer'">
    <el-form :model="form" label-width="120px">
      <el-form-item label="Full Name">
        <el-input v-model="form.fullName" />
      </el-form-item>
      <el-form-item label="Phone">
        <el-input v-model="form.phone" />
      </el-form-item>
      <el-form-item label="Email">
        <el-input v-model="form.email" />
      </el-form-item>
      <el-form-item label="Gender">
        <el-select v-model="form.gender" placeholder="Select gender">
          <el-option label="Male" value="Male" />
          <el-option label="Female" value="Female" />
        </el-select>
      </el-form-item>
      <el-form-item label="Address">
        <el-input v-model="form.address" type="textarea" />
      </el-form-item>
    </el-form>
    <template #footer>
      <span class="dialog-footer">
        <el-button @click="dialogVisible = false">Cancel</el-button>
        <el-button type="primary" @click="handleSubmit">Confirm</el-button>
      </span>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import { useCustomerStore } from '../stores/customerStore'

const props = defineProps({
  visible: {
    type: Boolean,
    required: true
  },
  customer: {
    type: Object,
    default: () => ({})
  }
})

const emit = defineEmits(['update:visible'])

const customerStore = useCustomerStore()
const dialogVisible = ref(props.visible)
const form = ref({ ...props.customer })

watch(
  () => props.visible,
  (value) => {
    dialogVisible.value = value
  }
)

watch(dialogVisible, (value) => {
  if (!value) {
    emit('update:visible', false)
  }
})

watch(
  () => props.customer,
  (value) => {
    form.value = { ...value }
  }
)

const handleSubmit = () => {
  // In a real app, you would call an API to save the customer
  console.log('Form submitted:', form.value)
  dialogVisible.value = false
}
</script>
