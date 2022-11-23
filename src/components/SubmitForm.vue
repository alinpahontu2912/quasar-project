<template>
  <div d="data" iclass="center">
    <form class="dataForm" @submit.prevent="addPerson">
      <div class="q-pa-sm">
        <q-input name="name" :rules="textRules" v-model="name" color="primary" :label="$t('name')" filled clearable />
      </div>
      <div class="q-pa-sm">
        <q-input :label="$t('surname')" :rules="textRules" v-model="surname" color="primary" filled clearable />
      </div>
      <div class="q-pa-sm">
        <q-input filled v-model="birthDate" :rules="dateRules">
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
        <q-btn type="submit" color="primary" :label="$t('submit')" />
      </div>
    </form>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import useInputRules from '../compositionFunctions/useInputRules'
const { textRules, dateRules } = useInputRules()
const surname = ref('')
const name = ref('')
const birthDate = ref(new Date().toISOString().split('T')[0])
const emit = defineEmits(['newPerson'])
function capitalize(str) {
  return str.charAt(0).toUpperCase() + str.slice(1).toLowerCase()
}

function addPerson() {
  if (name.value.length > 0 && surname.value.length > 0 && !!Date.parse(birthDate.value)) {
    emit('newPerson', capitalize(name.value), capitalize(surname.value), new Date(birthDate.value).toISOString().split('T')[0])
    name.value = ''
    surname.value = ''
    birthDate.value = ''
  } else {
    alert('Date incorecte')
  }
}
</script>

<style>
#data .dataForm {

  width: "80vw";
  padding: 3em;

}
</style>
