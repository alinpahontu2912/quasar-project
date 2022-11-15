<template>
    <div class="q-pa-md">
        <q-table :rows="rows" :columns="columns" row-key="lastName" separator="vertical" style="height: 30vh">
        </q-table>
    </div>
</template>


<script setup>

import { ref } from 'vue'

const props = defineProps({
    rows: Array,
    columns: Array
})

const pagination = ref({
    rowsPerPage: 0
})
</script>
