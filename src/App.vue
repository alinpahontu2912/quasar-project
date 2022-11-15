
<template>
  <SubmitForm @newPerson="insertPerson" />
  <DemoGrid :rows="gridData" :columns="gridColumns" />
</template>

<script setup>
import SubmitForm from './components/SubmitForm.vue'
import DemoGrid from './components/GridView.vue'
import { ref } from 'vue'

function insertPerson(firstName, lastName, birthDate) {
  gridData.value.push({ Nume: lastName, Prenume: firstName, 'Data Nasterii': birthDate })
}
const gridColumns = [{
  name: 'Nume',
  required: true,
  label: 'Nume de familie',
  align: 'center',
  field: row => row.Nume,
  format: val => `${val}`,
  sortable: true
},
{
  name: 'Prenume',
  label: 'Prenume',
  align: 'center',
  field: row => row.Prenume,
  format: val => `${val}`,
  sortable: true
},
{
  name: 'Data Nasterii',
  label: 'Data Nasterii',
  align: 'center',
  field: row => row['Data Nasterii'],
  format: val => `${val}`,
  sortable: true
}]
const gridData = ref([])
</script>


