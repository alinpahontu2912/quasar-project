<template>
  <q-header elevated class="bg-black">
    <div class="row no-wrap items-center q-mt-md q-pa-sm">
      <q-btn flat @click="toggleDrawer" round dense icon="menu"></q-btn>
      <ShoppingCart />
      <q-space />
      <q-select @update:model-value="changePageSize" class="q-pa-md" color="grey" outlined label-color="white"
        v-model="pageSize" :options="options">
        <template v-slot:append>
          <q-icon name="receipt" color="white" />
        </template>
      </q-select>
      <ProfilePicture />
    </div>
  </q-header>
</template>

<script setup>
import { ref, inject } from 'vue'
import ProfilePicture from './ProfilePicture.vue'
import { EVENT_KEYS } from '../utils/eventKeys.js'
import ShoppingCart from './ShoppingCart.vue'
const bus = inject('bus')
const options = ref([10, 15, 20])
const pageSize = ref(10)
function toggleDrawer() {
  bus.emit(EVENT_KEYS.TOGGLE_DRAWER, '')
}

function changePageSize(value) {
  console.log(pageSize.value)
  pageSize.value = value
  console.log(pageSize.value)
  bus.emit(EVENT_KEYS.CHANGE_PAGE_SIZE, pageSize.value)
}

</script>
