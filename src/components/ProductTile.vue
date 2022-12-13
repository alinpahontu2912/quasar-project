<template>
  <div class="col-12 col-sm-6 col-md-4 q-pa-md">
    <q-card flat bordered class="q-pa-md">
      <div class="row">
        <div class="col-4 col-sm-12 col-md-12 q-pa-sm row content-center">
          <q-img :src="product.image" :ratio="4 / 3" />
        </div>
        <div class="col-8 col-sm-12 col-md-12 row">
          <div class="col-12 col-sm-6 col-md-6">
            <div class="col-12 col-sm-12 col-md-12 q-pa-sm row justify-center">
              <p style="font-size:2em; text-transform: capitalize">{{ product.name }}</p>
            </div>
            <div class="col-12 col-sm-12 col-md-12 q-pa-md row justify-center"
              style="overflow-y: scroll; height: 100px;">
              {{ product.description }}
            </div>
          </div>
          <div class="col-12 col-sm-6 col-md-6 row">
            <div class="col-3 col-sm-12 col-md-12 q-pa-md row justify-center">
              <q-btn flat icon="local_grocery_store" @click="addToCart" />
            </div>
            <div class="col-9 col-sm-12 col-md-12 row justify-center">
              <q-input class="q-pa-md" input-class="text-center" outlined type="text" maxlength="2" size="2"
                v-model="quantity" :rules="numberOnlyRule">
                <template v-slot:prepend>
                  <q-btn @click="decreaseQuantity">&lt;</q-btn>
                </template>
                <template v-slot:append>
                  <q-btn @click="increaseQuantity">&gt;</q-btn>
                </template>
              </q-input>
            </div>
          </div>
        </div>
      </div>
    </q-card>
  </div>

</template>
<script setup>

import { ref } from 'vue'
import { Product } from '../models/Product.js'
import useInputRules from '../compositionFunctions/useInputRules'
import { useCartStore } from '../stores/cart'

const { numberOnlyRule } = useInputRules()
const { addProduct } = useCartStore()
const more = ref(false)
const quantity = ref(0)
const props = defineProps({
  product: Product
})

function readMore() {
  more.value = !more.value
}

function increaseQuantity() {
  quantity.value = parseInt(quantity.value) + 1
}

function decreaseQuantity() {
  if (quantity.value > 0) {
    quantity.value = parseInt(quantity.value) - 1
  }
}

function addToCart() {
  if (quantity.value !== 0) { addProduct(props.product, quantity.value) }
  quantity.value = 0
}

</script>
