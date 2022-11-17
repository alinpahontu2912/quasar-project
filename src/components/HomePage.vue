
<template>
  <SubmitForm @newPerson="insertPerson" />
  <DemoGrid :rows="gridData" :columns="gridColumns" />
</template>

<script setup>

import localStorageControl from '../compositionFunctions/localStorageControl'
import SubmitForm from './SubmitForm.vue'
import DemoGrid from './GridView.vue'
import { ref } from 'vue'

const { LOCAL_STORAGE_KEY, addToLocalStorage, retrieveGridData } = localStorageControl()

const gridColumns = [{
  name: 'surname',
  required: true,
  label: 'Nume de familie',
  align: 'center',
  field: row => row.surname,
  format: val => `${val}`,
  sortable: true
},
{
  name: 'name',
  label: 'Prenume',
  align: 'center',
  field: row => row.name,
  format: val => `${val}`,
  sortable: true
},
{
  name: 'birthDate',
  label: 'Data Nasterii',
  align: 'center',
  field: row => row.birthDate,
  format: val => `${val}`,
  sortable: true
}]
const gridData = ref(
  retrieveGridData()
)

function insertPerson(name, surname, birthDate) {
  gridData.value.push({ surname, name, birthDate })
  console.log(LOCAL_STORAGE_KEY.GRID_ITEMS)
  addToLocalStorage(LOCAL_STORAGE_KEY.GRID_ITEMS, gridData.value)
}

</script>
