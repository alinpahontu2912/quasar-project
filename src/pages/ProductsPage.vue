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
import { ref, inject } from 'vue'
import { Product } from 'src/models/Product'
import { endpoints } from 'src/endpoints/endpoints'
import { EVENT_KEYS } from '../utils/eventKeys.js'
import ProductTile from 'src/components/ProductTile.vue'

const items = ref([])
const pageSize = ref(10)
const bus = inject('bus')
const httpReq = new XMLHttpRequest()

bus.on(EVENT_KEYS.CHANGE_PAGE_SIZE, (newSize) => {
  pageSize.value = newSize
})

function createQeury(pageNumber) {
  const target = new URL(endpoints.ALL_PRODUCTS)
  const params = new URLSearchParams()
  params.set('pgsize', pageSize.value)
  params.set('page', pageNumber)
  target.search = params.toString()
  return target.href
}

async function onLoad(index, done) {
  httpReq.open('GET', createQeury(index))
  console.log(createQeury(index))
  httpReq.send()
  httpReq.onload = async function () {
    if (httpReq.status === 200) {
      const data = JSON.parse(httpReq.responseText)
      for (let i = 0; i < data.length; i++) {
        items.value.push(new Product(...Object.values(data[i])))
      }
      done()
    } else {
      console.log('No other products available')
    }
  }
}

</script>
