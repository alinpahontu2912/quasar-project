<template>
  <div flat bordered class="col-4 q-pa-md">
    <q-card class="q-pa-sm q-gutter-md">
      <div class="row q-pa-sm">
        <q-img class="col" :src="product.image" ratio="1" style="width: 150px; height: 150px;" />
      </div>
      <div class="row q-pa-sm">
        <div class="col"></div>
        <div class="col">
          {{ product.name }}
        </div>
        <div class="col"></div>
        <div class="col"></div>
        <div class="col"></div>
        <div class="col">
          <q-btn icon="local_grocery_store" @click="addToCart" />
        </div>
      </div>
      <div class="row q-pa-sm">
        <div class="col">
          <p class="p" v-if="!more"><span @click="readMore">{{ product.description.slice(0, 80) }}
              ...read more</span></p>
          <p class="p" v-else><span @click="readMore">{{ product.description }}</span></p>
        </div>
        <div class="col">
          <div class="row q-pt-lg">
            <q-btn class="col" @click="decreaseQuantity">&lt;</q-btn>
            <q-btn disable>
              <template v-slot:default>
                <q-input type="text" maxlength="2" size="2" v-model="quantity" :rules="numberOnlyRule" />
              </template>
            </q-btn>
            <q-btn class="col" @click="increaseQuantity">&gt;</q-btn>
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
  store.addProducts(props.product, quantity.value)
  quantity.value = 0
}

</script>
