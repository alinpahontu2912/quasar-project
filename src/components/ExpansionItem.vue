<template>
  <q-expansion-item :header-inset-level="1" expand-separator icon="receipt" label="Pages" default-closed>
    <InsideExpansionItem v-for="item in items" :key="item.id" :content="item.content" :label="item.labelName" />
  </q-expansion-item>
</template>
<script setup>
import InsideExpansionItem from './InsideExpansionItem.vue'
import { ref } from 'vue'

const props = defineProps({
  items: Array
})

</script>
