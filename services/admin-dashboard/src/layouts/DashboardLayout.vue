<template>
  <div class="flex h-screen bg-gray-100">
    <!-- Sidebar -->
    <aside class="w-64 bg-white shadow-md">
      <div class="p-4 text-2xl font-bold text-gray-800">GymFlow</div>
      <nav class="mt-5">
        <router-link
          to="/customers"
          class="flex items-center px-4 py-2 text-gray-700 hover:bg-gray-200"
          active-class="bg-gray-300"
        >
          <el-icon><User /></el-icon>
          <span class="mx-4">Customers</span>
        </router-link>
        <router-link
          to="/checkin"
          class="flex items-center px-4 py-2 mt-2 text-gray-700 hover:bg-gray-200"
          active-class="bg-gray-300"
        >
          <el-icon><Checked /></el-icon>
          <span class="mx-4">Check-in</span>
        </router-link>
        <router-link
          to="/face-recognition"
          class="flex items-center px-4 py-2 mt-2 text-gray-700 hover:bg-gray-200"
          active-class="bg-gray-300"
        >
          <el-icon><View /></el-icon>
          <span class="mx-4">Face Recognition</span>
        </router-link>
      </nav>
    </aside>

    <!-- Main content -->
    <div class="flex flex-col flex-1 overflow-hidden">
      <!-- Header -->
      <header class="flex items-center justify-between p-4 bg-white border-b">
        <div>
          <!-- Breadcrumbs or page title can go here -->
        </div>
        <div>
          <el-button type="primary" @click="logout">Logout</el-button>
        </div>
      </header>

      <!-- Content -->
      <main class="flex-1 p-6 overflow-y-auto">
        <router-view />
      </main>
    </div>
  </div>
</template>

<script setup lang="ts">
import { User, Checked, View } from '@element-plus/icons-vue'

const logout = () => {
  // Handle logout
  console.log('Logout clicked')
}
</script>
