<template>
  <div id="data" class="center">
    <form class="dataForm" @submit.prevent="addPerson">
      <div class="q-pa-md">
        <q-input name="firstName" v-model="firstName" color="primary" label="Introdu prenume" filled clearable />
      </div>
      <div class="q-pa-md">
        <q-input name="lastName" v-model="lastName" color="primary" label="Introdu nume" filled clearable />
      </div>
      <div class="q-pa-md">
        <q-input filled v-model="birthDate">
          <template v-slot:append>
            <q-icon name="event" class="cursor-pointer">
              <q-popup-proxy cover transition-show="scale" transition-hide="scale">
                <q-date v-model="birthDate" hint="Data nasterii">
                  <div class="row items-center justify-end">
                    <q-btn v-close-popup label="Close" color="primary" flat />
                  </div>
                </q-date>
              </q-popup-proxy>
            </q-icon>
          </template>
        </q-input>
      </div>
      <div class="q-pa-md row justify-center">
        <q-btn type="submit" color="primary" label="Submit" />
      </div>
    </form>
  </div>
</template>

<script setup>
import { ref } from 'vue'
const lastName = ref('')
const firstName = ref('')
const birthDate = ref(new Date().toISOString().split('T')[0])
const emit = defineEmits(['newPerson'])

function capitalize(str) {
  return str.charAt(0).toUpperCase() + str.slice(1).toLowerCase()
}

function addPerson() {
  if (firstName.value !== '' && lastName.value !== '' && birthDate.value !== '') {
    emit('newPerson', capitalize(firstName.value), capitalize(lastName.value), birthDate.value)
    firstName.value = ''
    lastName.value = ''
    birthDate.value = ''
  }
  else {
    alert('Introdu toate datele!')
  }
}
</script>


<style>
#data .dataForm {

  width: "85vw";
  padding: 3em;

}
</style>