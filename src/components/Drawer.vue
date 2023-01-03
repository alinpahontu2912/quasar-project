<template>
  <q-drawer overlay bordered :width="300" :breakpoint="300" show-if-above v-model="toggled">
    <q-scroll-area class="fit">
      <q-list padding class="menu-list">
        <q-item>
          <div class="col-12">
            <q-img src="https://cdn.quasar.dev/img/parallax2.jpg" no-native-menu :ratio="4 / 3">
              <div class="absolute-bottom-right text-subtitle2">
                Logo Test
              </div>
            </q-img>
          </div>
        </q-item>
        <q-item class="q-pl-md" style="width: 5vw;">
          <ExpansionItem :items="storePages" icon="receipt" page="pages" />
        </q-item>
        <q-item class="q-pl-md" style="width: 5vw;">
          <ExpansionItem :items="accountSettings" icon="camera_front" page="account" />
        </q-item>
      </q-list>
    </q-scroll-area>
  </q-drawer>
</template>

<script setup>
import ExpansionItem from './ExpansionItem.vue'
import { ref, inject } from 'vue'
import { EVENT_KEYS } from '../utils/eventKeys.js'
const toggled = ref(true)
const bus = inject('bus')

let id = 0
const storePages = ref([
  { id: id++, pageRoute: '/store/home', pageName: 'Home' },
  { id: id++, pageRoute: '/store/hello', pageName: 'Hello' },
  { id: id++, pageRoute: '/store/products', pageName: 'Products' },
  { id: id++, pageRoute: '/store/control', pageName: 'Control' }
])

id = 0
const accountSettings = ref([
  { id: id++, pageRoute: '/', pageName: 'Your Account' }
])

bus.on(EVENT_KEYS.TOGGLE_DRAWER, () => {
  const desktop = screen.width >= 600
  if (desktop) {
    toggled.value = !toggled.value
  }
})

</script>
