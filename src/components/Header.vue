<template>
  <q-header elevated class="bg-black row no-wrap items-center" style="height: 10vh;">
    <q-btn flat @click="toggleDrawer" round dense icon="menu"></q-btn>
    <ShoppingCart />
    <q-space />
    <q-select @update:model-value="changePageSize" class="q-pa-md" color="grey" outlined label-color="white"
      v-model="pageSize" :options="options">
      <template v-slot:append>
        <q-icon name="receipt" color="white" />
      </template>
    </q-select>
    <q-btn-dropdown label="Settings">
      <div class="row no-wrap q-pa-md">
        <q-checkbox v-model="darkMode" label="Dark Mode" />
      </div>
    </q-btn-dropdown>
    <ProfilePicture />
  </q-header>
</template>

<script setup>
import { ref, inject, watch } from 'vue'
import ProfilePicture from './ProfilePicture.vue'
import { EVENT_KEYS } from '../utils/eventKeys.js'
import ShoppingCart from './ShoppingCart.vue'
import { useQuasar } from 'quasar'
import useLocalStorage from 'src/compositionFunctions/useLocalStorage'
const { setDarkMode, retrieveDarkMode } = useLocalStorage()
const bus = inject('bus')
const options = ref([10, 15, 20])
const pageSize = ref(10)
const darkMode = ref(retrieveDarkMode())
const $q = useQuasar()
function toggleDrawer() {
  bus.emit(EVENT_KEYS.TOGGLE_DRAWER, '')
}

function changePageSize(value) {
  console.log(pageSize.value)
  pageSize.value = value
  console.log(pageSize.value)
  bus.emit(EVENT_KEYS.CHANGE_PAGE_SIZE, pageSize.value)
}

watch(darkMode, () => {
  $q.dark.toggle()
  setDarkMode($q.dark.isActive)
})

</script>
