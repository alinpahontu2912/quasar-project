<template>
  <q-drawer bordered :width="300" :breakpoint="600" show-if-above v-model="model">
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
import { ref, inject } from 'vue'
import ExpansionItem from './ExpansionItem.vue'
const model = ref(true)
const bus = inject('bus')

bus.on('toggleDrawer', () => {
  model.value = !model.value
})
let id = 0
const items = ref([
  { id: id++, content: 'Test', labelName: 'Test1' },
  { id: id++, content: 'Test', labelName: 'Test2' }
])

</script>
