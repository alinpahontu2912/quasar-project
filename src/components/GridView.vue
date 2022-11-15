<script setup>
import { ref, computed } from 'vue'
const props = defineProps({
    rows: Array,
    columns: Array
})

// script for no quasar
// const sortKey = ref('')
// const sortOrders = ref(
//     props.columns.reduce((o, key) => ((o[key] = 1), o), {})
// )
// const filteredData = computed(() => {
//     let { rows } = props
//     const key = sortKey.value
//     if (key) {
//         const order = sortOrders.value[key]
//         rows = rows.slice().sort((a, b) => {
//             a = a[key]
//             b = b[key]
//             return (a === b ? 0 : a > b ? 1 : -1) * order
//         })
//     }
//     return rows
// })

</script>

<template>
    <!-- TODO template always first, before script -->
    <!-- no quasar here
     <div>
        <table class="table gridView">
            <thead>
                <tr>
                    <th v-for="key in columns" @click="sortBy(key)">{{ key }}</th>
                </tr>
                <span class="arrow">
                </span>
            </thead>
            <tbody>
                <tr v-for="entry in filteredData">
                    <td v-for="key in columns">
                        {{ capitalize(entry[key]) }}
                    </td>
                </tr>
            </tbody>
        </table>
    </div> -->

    <!-- quasar  -->
    <div class="q-pa-md">
        <q-table :rows="rows" :columns="columns" row-key="Nume" separator="vertical"></q-table>
    </div>
</template>
