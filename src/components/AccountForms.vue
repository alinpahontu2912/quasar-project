<template>
  <div class="q-pa-md">
    <q-card class="my-card">
      <q-card-section>
        <div class="text-h6 row items-center justify-center">Welcome to the store!</div>
      </q-card-section>
      <q-tabs v-model="tab" class="text-teal" dense align="justify" :breakpoint="0">
        <q-tab label="Create account" name="one" />
        <q-tab label="Have an account?" name="two" />
      </q-tabs>
      <q-separator />
      <q-tab-panels v-model="tab" animated>
        <q-tab-panel name="one">
          <q-form class="q-gutter-md row items-center justify-center">
            <q-input square filled clearable v-model="email" type="email" label="Email" class="q-pa-sm col-12" />
            <q-input square filled clearable v-model="fullName" type="text" label="Full Name" class="q-pa-sm col-12" />
            <q-input square filled clearable mask="(###) ### - ####" unmasked-value v-model="phoneNumber"
              label="Phone number" class="q-pa-sm col-12" />
            <q-input square filled clearable v-model="password" type="password" label="Password"
              class="q-pa-sm col-12" />
            <q-input square filled clearable v-model="address" type="address" label="Address" class="q-pa-sm col-12" />
            <q-btn unelevated color="light-green-7" size="md" class="q-pa-sm col-12" label="Sign Up" @click="signUp" />
            <q-checkbox left-label v-model="remainSignedIn" label="Stay logged in" checked-icon="task_alt"
              unchecked-icon="highlight_off" />
          </q-form>
        </q-tab-panel>
        <q-tab-panel name="two">
          <q-form class="q-gutter-md row items-center justify-center">
            <q-input square filled clearable v-model="email" type="email" label="email" class="q-pa-md col-12" />
            <q-input square filled clearable v-model="password" type="password" label="password"
              class="q-pa-md col-12" />
            <q-btn unelevated color="light-green-7" size="md" class="q-pa-md col-12" label="Login" @click="login" />
            <q-checkbox left-label v-model="remainSignedIn" label="Stay logged in" checked-icon="task_alt"
              unchecked-icon="highlight_off" />
          </q-form>
        </q-tab-panel>
      </q-tab-panels>
    </q-card>
  </div>
</template>
<script setup>
import { ref } from 'vue'
import useHttpQuery from 'src/compositionFunctions/useHttpQuery'
import useLocalStorage from 'src/compositionFunctions/useLocalStorage'
import { useRouter } from 'vue-router'
const { saveUserData } = useLocalStorage()
const { addNewUser, verifyUserCredentials } = useHttpQuery()
const router = useRouter()
const tab = ref('one')
const email = ref('')
const fullName = ref('')
const password = ref('')
const address = ref('')
const phoneNumber = ref('')
const remainSignedIn = ref(true)

function resetForm() {
  email.value = ''
  fullName.value = ''
  phoneNumber.value = ''
  password.value = ''
  address.value = ''
}

async function signUp() {
  const response = await addNewUser(email.value, fullName.value, phoneNumber.value, password.value, address.value)
  resetForm()
  if (response) {
    if (remainSignedIn.value) { saveUserData(response) }
    router.replace({
      path: '/store/products'
    })
  }
}

async function login() {
  const response = await verifyUserCredentials(email.value, password.value)
  resetForm()
  if (response) {
    if (remainSignedIn.value) { saveUserData(response) }
    router.replace({
      path: '/store/products'
    })
  }
}

</script>
<style lang="sass" scoped>
.my-card
  width: 100%
  max-width: 40vw
  height: 70%
</style>
