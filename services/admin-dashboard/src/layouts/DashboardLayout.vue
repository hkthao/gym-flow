<template>
  <v-app :theme="theme.global.name.value">
    <!-- Left Navigation Drawer -->
    <v-navigation-drawer v-model="drawer" border>
      <v-toolbar title="MANAGEMENT" color="surface"></v-toolbar>
      <v-divider></v-divider>
      <v-list nav>
        <v-list-item to="/customers" link rounded="lg" slim>
          <template v-slot:prepend>
            <v-icon icon="mdi-account-group"></v-icon>
          </template>
          <v-list-item-title class="text-subtitle-1">Customers</v-list-item-title>
        </v-list-item>
        <v-list-item to="/checkin" link rounded="lg" slim>
          <template v-slot:prepend>
            <v-icon icon="mdi-check-circle-outline"></v-icon>
          </template>
          <v-list-item-title class="text-subtitle-1">Check-in</v-list-item-title>
        </v-list-item>
        <v-list-item to="/face-recognition" link rounded="lg" slim>
          <template v-slot:prepend>
            <v-icon icon="mdi-face-recognition"></v-icon>
          </template>
          <v-list-item-title class="text-subtitle-1">Face Recognition</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <!-- Right Settings Drawer -->
    <v-navigation-drawer v-model="settingsDrawer" location="right" temporary>
      <v-list>
        <v-list-subheader>SETTINGS</v-list-subheader>
        <v-list-item>
          <v-switch
            :model-value="isDark"
            @update:model-value="toggleTheme"
            label="Dark Mode"
            color="primary"
            hide-details
          ></v-switch>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <!-- App Bar -->
    <v-app-bar elevation="0" border>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title>GymFlow</v-toolbar-title>
      <v-spacer></v-spacer>

      <!-- User Menu -->
      <v-menu>
        <template v-slot:activator="{ props }">
          <v-btn v-bind="props" class="text-none">
            <v-avatar color="brown" size="small" class="mr-2">
              <span class="text-h6">A</span>
            </v-avatar>
            Admin
            <v-icon>mdi-chevron-down</v-icon>
          </v-btn>
        </template>
        <v-list>
          <v-list-item link prepend-icon="mdi-account-circle" @click="goToProfile" slim>
            <v-list-item-title>Profile</v-list-item-title>
          </v-list-item>
          <v-list-item link prepend-icon="mdi-logout" @click="logout" slim>
            <v-list-item-title>Logout</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>

      <v-btn icon @click="settingsDrawer = !settingsDrawer" class="ml-2">
        <v-icon>mdi-cog-outline</v-icon>
      </v-btn>
    </v-app-bar>

    <!-- Main Content -->
    <v-main>
      <v-container fluid>
        <router-view />
      </v-container>
    </v-main>
  </v-app>
</template>

<script lang="ts" setup>
import { ref, computed } from 'vue'
import { useTheme } from 'vuetify'
import { useRouter } from 'vue-router'

const drawer = ref(true)
const settingsDrawer = ref(false)

const theme = useTheme()
const router = useRouter()

const isDark = computed(() => theme.global.current.value.dark)

function toggleTheme() {
  theme.global.name.value = isDark.value ? 'light' : 'dark'
}

function goToProfile() {
  router.push('/profile')
}

function logout() {
  router.push('/login')
}
</script>

<style scoped>
/* Add any component-specific styles here if needed */
</style>
