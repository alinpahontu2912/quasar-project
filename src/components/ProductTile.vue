<template>
  <div id="q-app">
    <div class="q-pa-md row items-start q-gutter-md" style="width: 40vh; height: 40vh;">
      <q-card flat bordered>
        <q-img :src="product.image"></q-img>
        <q-card-section>
          <div class="text-h5 q-mt-sm q-mb-xs">{{ product.name }}</div>
          <div clas="full-width row wrap justify-evenly">
            <div class="col-1">
              <container class="text-caption text-grey col-1">
                {{ product.description }}
              </container>
            </div>
            <div>
              <container clas="full-width row wrap justify-evenly">
                <q-btn class="col-1" @click="decreaseQuantity">&lt;</q-btn>
                <q-btn disable>
                  <template v-slot:default>
                    <q-input type="text" maxlength="2" size="2" v-model="quantity" :rules="numberOnlyRule" />
                  </template>
                </q-btn>
                <q-btn class="col-1" @click="increaseQuantity">&gt;</q-btn>
              </container>
            </div>
          </div>
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
