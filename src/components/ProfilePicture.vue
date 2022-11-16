<template>
  <q-btn round class="bg-white">
    <q-tooltip transition-show="flip-right" transition-hide="flip-left" class="bg-indigo text-black shadow-4"
      :offset="[10, 10]">
      Poza de profil
    </q-tooltip>
    <q-avatar size="60px">
      <q-file filled outlined v-model="model" spinner-color="white" />
      <img src="photo">
    </q-avatar>
  </q-btn>
</template>

<script setup>

import { ref, watch } from 'vue'

const model = ref(null)
const photo = ref(null)

watch(model, (photo) => {
  const reader = new FileReader()
  reader.readAsDataURL(model.value)
  reader.onload = (e) => {
    photo.value = e.target.result
  }
  console.log('Change')
})

</script>
