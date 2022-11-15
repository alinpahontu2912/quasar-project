
<template>
  <SubmitForm @newPerson="insertPerson" />
  <DemoGrid :rows="gridData" :columns="gridColumns" />
</template>

<script setup>
/**
 * TODO move all code from here to a new component
 * In general, App.vue should be the app root component and no logic should be present here
 */
import SubmitForm from './components/SubmitForm.vue'
import DemoGrid from './components/GridView.vue'
import { ref } from 'vue'

/**
 * TODO order in setup script is important
 * The order:
 * - props
 * - emits
 * - data
 * - methods
 * - computed
 * - watchers
 * - lifecycle methods (onMounted / onUnmounted etc.)
 *
 * This order should be the same in every component so it is easier to locate different functionalities
 *
 * For example here:
 * gridColumns = ...
 * gridData = ...
 * function insertPerson...
 */

/**
 * TODO between function name and "(" should be a space -> insertPerson (firstName, lastName)
 * This will be solved when linter is run so no need to worry, just to keep in mind
 */
function insertPerson(firstName, lastName, birthDate) {
  gridData.value.push({ Nume: lastName, Prenume: firstName, 'Data Nasterii': birthDate })
}

/**
 * TODO
 * From Quasar docs, name attribute is used as key for table objects
 * In general:
 *  - keys should not contain spaces (Example here: "Data Nasterii" is not a good key); row['Data Nasterii'] is "ugly", use row.birthdate instead
 *  - keys shouldn't start with capital letters
 *
 * Better key names: name, surname, birthdate / birthDate
 */
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
