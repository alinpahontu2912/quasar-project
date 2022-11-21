<template>
  <q-header elevated class="bg-black">
    <div class="row no-wrap items-center q-mt-md q-pa-sm">
      <q-btn flat @click="toggleDrawer" round dense icon="menu"></q-btn>
      <q-space />
      <ProfilePicture />
    </div>
  </q-header>
</template>

<script setup>
import ProfilePicture from './ProfilePicture.vue'
import { inject } from 'vue'
const bus = inject('bus')
function toggleDrawer() {
  bus.emit('toggleDrawer', 1)
}
</script>
