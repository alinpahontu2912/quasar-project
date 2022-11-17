<template>
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
</template>

<script setup>
import localStorageControl from '../compositionFunctions/localStorageControl'
import { ref, watch } from 'vue'

const { LOCAL_STORAGE_KEY, addToLocalStorage, retrieveProfilePicture } = localStorageControl()
const filePicker = ref()
const model = ref('')
const photo = ref(retrieveProfilePicture())

watch(model, (newModel) => {
  const reader = new FileReader()
  reader.readAsDataURL(model.value)
  reader.onload = (e) => {
    photo.value = e.target.result
    addToLocalStorage(LOCAL_STORAGE_KEY.PROFILE_PICTURE, photo.value)
  }
})

function onAvatarClick() {
  filePicker.value.pickFiles()
}
</script>
