<template>

  <q-btn class="btn btn-small btn-info btn-popup q-pa-md" icon="local_grocery_store" label="Cart">
    <q-menu max-height="150px" wid>
      <q-list style="min-width: 230px">
        <q-item clickable v-for="product in products" :key="product.id">
          <div class="row">
            <div class="col-5">
              <q-img style="width: 70px; height: 70px;" :src="product.image" no-native-menu>
                <div class="absolute-bottom-right text-subtitle2">
                  {{ product.name }}
                </div>
              </q-img>
            </div>
            <div class="col-4 q-mt-md q-ml-md">
              <q-item-section>Cantitate: </q-item-section>
              <q-item-section>1</q-item-section>
            </div>
            <div class="col q-ml-md">
              <q-btn dense flat icon="close" @click="deleteProduct"></q-btn>
            </div>
          </div>
          <q-separator></q-separator>
        </q-item>
      </q-list>
    </q-menu>
  </q-btn>
</template>
<script setup>
import { dummyProduct } from 'src/products/dummyProduct'
import { Product } from 'src/models/Product'
import { ref } from 'vue'
// const props = defineProps({
//   products: Array
// })

const dummy = new Product(...Object.values(dummyProduct))
const products = ref([dummy, dummy, dummy])

function deleteProduct() {

}

</script>
