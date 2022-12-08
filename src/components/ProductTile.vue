<template>
<<<<<<< HEAD
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
=======
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
>>>>>>> 8f744d416a1af96ea7354a81364e41654f7d358a
            <q-btn disable>
              <template v-slot:default>
                <q-input type="text" maxlength="2" size="2" v-model="quantity" :rules="numberOnlyRule" />
              </template>
            </q-btn>
<<<<<<< HEAD
            <q-btn class="col" @click="increaseQuantity">&gt;</q-btn>
          </div>
        </div>
      </div>

    </q-card>
  </div>
</template>
<script setup>
import { ref, inject } from 'vue'
import { Product } from '../models/Product.js'
=======
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
>>>>>>> 8f744d416a1af96ea7354a81364e41654f7d358a
import useInputRules from '../compositionFunctions/useInputRules'
import { useCartStore } from '../stores/cart'
import { EVENT_KEYS } from 'src/utils/eventKeys'

const { numberOnlyRule } = useInputRules()
const store = useCartStore()
const bus = inject('bus')
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
  bus.emit(EVENT_KEYS.CART_CHANGE, '')
}

</script>
