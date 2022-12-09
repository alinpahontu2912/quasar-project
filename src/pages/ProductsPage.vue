<template>
  <div class="q-pa-md">
    <q-infinite-scroll @load="onLoad" :offset="250">
      <div class="row fit ">
        <ProductTile v-for="(item, index) in items" :key="index" :product="item" />
      </div>
      <template v-slot:loading>
        <div class="row justify-center q-my-md">
          <q-spinner-dots color="primary" size="40px" />
        </div>
      </template>
    </q-infinite-scroll>
  </div>

</template>
<script setup>
import { ref } from 'vue'
import { Product } from 'src/models/Product'
import ProductTile from 'src/components/ProductTile.vue'
import { dummyProduct1, dummyProduct2, dummyProduct3 } from 'src/products/dummyProduct'
const dummy1 = new Product(...Object.values(dummyProduct1))
const dummy2 = new Product(...Object.values(dummyProduct2))
const dummy3 = new Product(...Object.values(dummyProduct3))
const items = ref([dummy1, dummy2, dummy3, dummy1, dummy2, dummy3])

function onLoad(index, done) {
  console.log('Loading')
  setTimeout(() => {
    items.value.push(dummy3, dummy2, dummy1, dummy3, dummy2)
    done()
  }, 2000)
}

</script>
