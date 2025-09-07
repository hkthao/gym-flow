<template>
  <div class="flex h-screen bg-gray">
    <!-- Sidebar -->
    <aside
      :class="isSidebarOpen ? 'w-72' : 'w-20'"
      class="flex flex-col bg-secondary text-white transition-width duration-300"
    >
      <div class="flex items-center justify-between p-4 h-16">
        <span v-if="isSidebarOpen" class="text-2xl font-bold">GymFlow Dashboard v2</span>
        <button @click="toggleSidebar" class="p-2 rounded-md hover:bg-dark">
          <el-icon><Menu /></el-icon>
        </button>
      </div>
      <nav class="mt-5 flex-1">
        <router-link
          to="/customers"
          class="flex items-center px-4 py-3 text-gray-300 hover:bg-dark hover:text-white"
          active-class="bg-primary text-white"
        >
          <el-icon size="24"><User /></el-icon>
          <span v-if="isSidebarOpen" class="mx-4">Customers</span>
        </router-link>
        <router-link
          to="/checkin"
          class="flex items-center px-4 py-3 mt-2 text-gray-300 hover:bg-dark hover:text-white"
          active-class="bg-primary text-white"
        >
          <el-icon size="24"><Checked /></el-icon>
          <span v-if="isSidebarOpen" class="mx-4">Check-in</span>
        </router-link>
        <router-link
          to="/face-recognition"
          class="flex items-center px-4 py-3 mt-2 text-gray-300 hover:bg-dark hover:text-white"
          active-class="bg-primary text-white"
        >
          <el-icon size="24"><View /></el-icon>
          <span v-if="isSidebarOpen" class="mx-4">Face Recognition</span>
        </router-link>
      </nav>
    </aside>

    <!-- Main content -->
    <div class="flex flex-col flex-1 overflow-hidden">
      <!-- Header -->
      <header class="flex items-center justify-end p-4 bg-white border-b border-stroke h-16">
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
import { ref } from 'vue'
import { User, Checked, View, Menu } from '@element-plus/icons-vue'

const isSidebarOpen = ref(true)

const toggleSidebar = () => {
  isSidebarOpen.value = !isSidebarOpen.value
}

const logout = () => {
  console.log('Logout clicked')
}
</script>
