<template>
  <q-header elevated class="bg-black">
    <div class="row no-wrap items-center q-mt-md q-pa-sm">
      <q-btn flat @click="toggleDrawer" round dense icon="menu"></q-btn>
      <q-space />
      <ShoppingCart />
      <ProfilePicture />
    </div>
  </q-header>
</template>

<script setup>
import { inject } from 'vue'
import ProfilePicture from './ProfilePicture.vue'
import ShoppingCart from './ShoppingCart.vue'
import { EVENT_KEYS } from '../utils/eventKeys.js'
const bus = inject('bus')
function toggleDrawer() {
  bus.emit(EVENT_KEYS.TOGGLE_DRAWER, '')
}
</script>
