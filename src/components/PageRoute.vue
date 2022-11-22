<template>
  <q-list bordered separator>
    <q-item clickable v-ripple>
      <q-item-section>
        <RouterLink :to=pageRoute>{{ pageName }}</RouterLink>
      </q-item-section>
    </q-item>
  </q-list>
</template>

<script setup>
const props = defineProps({
  pageName: String,
  pageRoute: String
})

</script>
