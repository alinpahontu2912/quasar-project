<template>
  <div id="q-app">
    <div class="q-pa-md row items-start q-gutter-md" style="width: 60vh; height: 40vh;">
      <q-card class="my-card" flat bordered>
        <q-item>
          <q-item-section>
            <q-img :src="product.image" />
          </q-item-section>
        </q-item>
        <q-separator />
        <q-item-label class="text-h5">{{ product.name }}</q-item-label>
        <q-card-section horizontal>
          <q-card-section>
            {{ product.description }}
          </q-card-section>
          <q-separator vertical />
          <q-card-section>
            <q-btn class=" col-1" @click="decreaseQuantity">&lt;</q-btn>
            <q-btn disable>
              <template v-slot:default>
                <q-input type="text" maxlength="2" size="2" v-model="quantity" :rules="numberOnlyRule" />
              </template>
            </q-btn>
            <q-btn class="col-1" @click="increaseQuantity">&gt;</q-btn>
          </q-card-section>
        </q-card-section>
      </q-card>
    </div>
  </div>
</template>
<script setup>
import { ref } from 'vue'
import { Product } from '../classes/Product.js'
import useInputRules from '../compositionFunctions/useInputRules'
const { numberOnlyRule } = useInputRules()
const props = defineProps({
  product: Product
})
const quantity = ref(0)

function increaseQuantity() {
  quantity.value += 1
}

function decreaseQuantity() {
  if (quantity.value > 0) {
    quantity.value -= 1
  }
}

</script>
