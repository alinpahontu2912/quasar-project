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
import { endpoints } from 'src/endpoints/endpoints'
const items = ref([])
const httpReq = new XMLHttpRequest()
httpReq.open('GET', endpoints.ALL_PRODUCTS)
httpReq.send()
httpReq.onload = function () {
  if (httpReq.status === 200) {
    const data = JSON.parse(httpReq.responseText)
    for (let i = 0; i < data.length; i++) {
      items.value.push(new Product(...Object.values(data[i])))
    }
  } else if (httpReq.status === 404) {
    console.log('No records found')
  }
}

// function onLoad(index, done) {
//   console.log('Loading')
//   setTimeout(() => {
//     items.value.push(dummy3, dummy2, dummy1, dummy3, dummy2)
//     done()
//   }, 2000)
// }

</script>
