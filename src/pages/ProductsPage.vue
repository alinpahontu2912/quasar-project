<template>
  <div class="q-pa-md">
    <q-infinite-scroll @load="onLoad" :offset="250">
      <div v-for="item in items" :key="item.id" class="caption">
        <ProductTile :product="item" />
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
import { dummyProduct } from 'src/products/dummyProduct'
const dummy = new Product(...Object.values(dummyProduct))
const items = ref([dummy, dummy, dummy])

function onLoad(index, done) {
  console.log('Loading')
  // uncomment for infinite loading
  // setTimeout(() => {
  //   items.value.push(dummy, dummy, dummy, dummy, dummy)
  //   done()
  // }, 2000)
}

</script>
