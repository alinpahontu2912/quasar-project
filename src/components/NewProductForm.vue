<template>
  <q-dialog v-model="triggered">
    <q-card>
      <q-card-section class="row items-center q-pb-none">
        <div class="text-h6">New Product</div>
        <q-space />
        <q-btn icon="close" flat round dense v-close-popup />
      </q-card-section>
      <q-card-section style="width: 30vw;" class="q-pa-md row justify-center">
        <q-input type="number" v-model="id" label="id" class="col-12 q-pa-md" />
        <q-input v-model="name" label="Name" class="col-12 q-pa-md" />
        <q-input type="number" v-model="price" label="Price" class="col-12 q-pa-md" />
        <q-input v-model="description" label="Description" class="col-12 q-pa-md" />
        <q-input v-model="image" label="Image" class="col-12 q-pa-md" />
        <q-btn label="Submit" class="col-12 q-pa-md" v-close-popup @click="addProductToDB" />
      </q-card-section>
    </q-card>
  </q-dialog>
</template>
<script setup>
import { ref, inject } from 'vue'
import { EVENT_KEYS } from '../utils/eventKeys.js'
import useHttpQuery from 'src/compositionFunctions/useHttpQuery'
const { addProduct } = useHttpQuery()
const bus = inject('bus')
const id = ref(-1)
const name = ref('')
const price = ref(1)
const description = ref('')
const image = ref('')

const triggered = ref(false)

bus.on(EVENT_KEYS.NEW_PRODUCT, (productId) => {
  id.value = productId + 1
  triggered.value = true
})

async function addProductToDB() {
  const response = await addProduct(id.value, name.value, price.value, description.value, image.value)
  name.value = ''
  price.value = 1
  description.value = ''
  image.value = ''
  return response.status === 200
}

</script>
