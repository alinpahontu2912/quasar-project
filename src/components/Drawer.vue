<template>
  <q-drawer bordered :width="300" :breakpoint="300" show-if-above v-model="toggled">
    <q-scroll-area class="fit">
      <q-list padding class="menu-list">
        <q-item>
          <div class="col-6">
            <q-img src="https://cdn.quasar.dev/img/parallax2.jpg" no-native-menu :ratio="4 / 3">
              <div class="absolute-bottom-right text-subtitle2">
                Logo Test
              </div>
            </q-img>
          </div>
        </q-item>
        <q-item>
          <ExpansionItem :items="items" />
        </q-item>
      </q-list>
    </q-scroll-area>
  </q-drawer>
</template>

<script setup>
import ExpansionItem from './ExpansionItem.vue'
import { ref, inject } from 'vue'

const toggled = ref(true)
const bus = inject('bus')

let id = 0
const items = ref([
  { id: id++, pageRoute: '/', pageName: 'Home' },
  { id: id++, pageRoute: '/hello', pageName: 'Hello' }
])

bus.on('toggleDrawer', () => {
  toggled.value = !toggled.value
})

</script>
