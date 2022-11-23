<template>
  <div class="q-pa-md">
    <q-table :rows="gridData" :columns=columns separator="vertical" style="height: 75vh" binary-state-sort>
      <template v-slot:top-right>
        <span>
          <q-btn icon="add" color="primary" @click="toggle" />
          <q-dialog v-model="alert">
            <q-card style="width: 700px; max-width: 80vw;">
              <q-card-section class="q-pa-md">
                <SubmitForm @new-person="insertPerson" />
              </q-card-section>
            </q-card>
          </q-dialog>
        </span>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit v-model="props.row.name" buttons v-slot="scope" @update:model-value="updateGrid(gridData)">
              <q-input type="text" v-model="scope.value" dense autofocus counter />
            </q-popup-edit>
          </q-td>
          <q-td key="surname" :props="props">
            {{ props.row.surname }}
            <q-popup-edit v-model="props.row.surname" buttons v-slot="scope" @update:model-value="updateGrid(gridData)">
              <q-input type="text" v-model="scope.value" dense autofocus counter />
            </q-popup-edit>
          </q-td>
          <q-td key="birthDate" :props="props">
            {{ props.row.birthDate }}
            <q-popup-edit v-model="props.row.birthDate" buttons v-slot="scope"
              @update:model-value="updateGrid(gridData)">
              <q-input type="date" v-model="scope.value" dense autofocus />
            </q-popup-edit>
          </q-td>
        </q-tr>
      </template>
    </q-table>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import SubmitForm from './SubmitForm.vue'
import useLocalStorage from '../compositionFunctions/useLocalStorage'
const { updateGrid, retrieveGridData } = useLocalStorage()

const columns = [{
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

const alert = ref(false)
const gridData = ref(
  retrieveGridData()
)

function toggle() {
  alert.value = !alert.value
}

function insertPerson(name, surname, birthDate) {
  gridData.value.push({ surname, name, birthDate })
  updateGrid(gridData.value)
}

</script>
