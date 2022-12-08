<template>

  <div class="col-12 col-sm-6 col-md-4 q-pa-md">
    <q-card flat bordered>
      <div class="row">
        <div class="col-4 col-sm-12 col-md-12 q-pa-sm row content-center">
          <q-img :src="product.image" />
        </div>
        <div class="col-8 col-sm-12 col-md-12">
          <div class="row">
            <div class="col-12 col-md-12">
              <div class="row justify-around ">
                <div class="col-5 col-md-5 col-sm-5 row justify-center content-center q-pa-md">
                  <p style="font-size:2em; text-transform: capitalize">{{ product.name }}</p>
                </div>
                <div class="col-7 col-md-7 col-sm-7 row justify-center content-center q-pa-md">
                  <q-btn q-pa-md flat icon=" local_grocery_store" @click="addToCart" />
                </div>
              </div>
            </div>
            <div class="col-12 col-md-12">
              <div class="row justify-between">
                <div class="col-5 col-sm-5 col-md-6 q-pa-md row justify-center">
                  <p v-if="!more" @click="readMore">{{ product.description.slice(0, 80) }}
                    ...read more</p>
                  <p v-else><span @click="readMore">{{ product.description }}</span></p>
                </div>
                <div class="col-7 col-sm-7 col-md-6 row justify-center content-center q-pl-sm">
                  <q-input input-class="text-center" outlined type="text" maxlength="2" size="2" v-model="quantity"
                    :rules="numberOnlyRule">
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
        </div>
      </div>
    </q-card>
  </div>
</template>
<script setup>
// q-gutter-md
import { ref } from 'vue'
import { Product } from '../models/Product.js'
import useInputRules from '../compositionFunctions/useInputRules'
import { useCartStore } from '../stores/cart'

const { numberOnlyRule } = useInputRules()
const store = useCartStore()
const more = ref(false)

const props = defineProps({
  product: Product
})
const quantity = ref(0)

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
  if (quantity.value !== 0) { store.addProducts(props.product, quantity.value) }
  quantity.value = 0
}

</script>
