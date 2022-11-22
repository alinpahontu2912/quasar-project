<template>
  <div class="q-pa-md">
    <q-table :rows="rows" :columns="columns" row-key="lastName" separator="vertical" style="height: 30vh">
    </q-table>
  </div>
</template>

<script setup>
const props = defineProps({
  rows: Array,
  columns: Array
})

</script>
