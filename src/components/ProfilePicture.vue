<template>
  <div class="q-pa-md">
    <q-btn round class="bg-white">
      <q-tooltip transition-show="flip-right" transition-hide="flip-left" class="bg-indigo text-black shadow-4"
        :offset="[10, 10]">
        Poza de profil
      </q-tooltip>
      <q-avatar size="60px" @click="onAvatarClick">
        <q-file v-show="false" ref="filePicker" filled outlined v-model="model" spinner-color="white" />
        <q-img :src="photo" />
      </q-avatar>
    </q-btn>
  </div>
</template>

<script setup>
import { ref, watch } from 'vue'
import useLocalStorage from '../compositionFunctions/useLocalStorage'

const { updateProfilePicture, retrieveProfilePicture } = useLocalStorage()
const filePicker = ref()
const model = ref('')
const photo = ref(retrieveProfilePicture())

watch(model, (newModel) => {
  const reader = new FileReader()
  reader.readAsDataURL(model.value)
  reader.onload = (e) => {
    photo.value = e.target.result
    updateProfilePicture(photo.value)
  }
})

function onAvatarClick() {
  filePicker.value.pickFiles()
}
</script>
