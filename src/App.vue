
<template>
  <RouterView />
</template>

<script setup>
import useLocalStorage from 'src/compositionFunctions/useLocalStorage'
import { useQuasar } from 'quasar'
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
const router = useRouter()
const { retrieveUserData } = useLocalStorage()
const { retrieveDarkMode } = useLocalStorage()
const darkMode = ref(retrieveDarkMode())
const $q = useQuasar()
onMounted(() => {
  if (darkMode.value) $q.dark.set(true)
  if (retrieveUserData()) {
    router.replace({
      path: '/store/products'
    })
  }
})
</script>
