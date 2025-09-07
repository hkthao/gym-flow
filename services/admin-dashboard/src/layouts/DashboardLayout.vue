<template>
  <el-container class="h-screen">
    <el-aside width="200px" class="bg-gray-800 text-white">
      <div class="p-4 text-xl font-bold">Admin Dashboard</div>
      <el-menu
        :default-active="activeIndex"
        class="el-menu-vertical-demo"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b"
        router
      >
        <el-menu-item index="/customers">
          <el-icon><User /></el-icon>
          <span>Customers</span>
        </el-menu-item>
        <el-menu-item index="/checkin">
          <el-icon><Checked /></el-icon>
          <span>Check-in</span>
        </el-menu-item>
        <el-menu-item index="/face-recognition">
          <el-icon><View /></el-icon>
          <span>Face Recognition</span>
        </el-menu-item>
      </el-menu>
    </el-aside>
    <el-main>
      <router-view />
    </el-main>
  </el-container>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { User, Checked, View } from '@element-plus/icons-vue'

const activeIndex = ref('/customers')
</script>

<style scoped>
.el-menu-vertical-demo:not(.el-menu--collapse) {
  width: 200px;
  min-height: 400px;
}
</style>
