<template>

  <q-btn class="btn btn-small btn-info btn-popup q-pa-md" icon="local_grocery_store" label="Cart">
    <q-tooltip v-if="savedProducts.length > 0" anchor="bottom middle" self="top middle">
      Number of products:{{ savedProducts.length }}
    </q-tooltip>
    <q-tooltip v-else anchor="bottom middle" self="top middle">
      No products :/
    </q-tooltip>
    <q-menu max-height="150px" wid>
      <q-list style="min-width: 230px">
        <q-item clickable v-for="prod in savedProducts" :key="prod.id">
          <div class="row">
            <div class="col-5">
              <q-img style="width: 70px; height: 70px;" :src="prod.image" no-native-menu>
                <div class="absolute-bottom-right text-subtitle2">
                  {{ prod.name }}
                </div>
              </q-img>
            </div>
            <div class="col-4 q-mt-md q-ml-md">
              <q-item-section>Cantitate: </q-item-section>
              <q-item-section>{{ prod.qt }}</q-item-section>
            </div>
            <div class="col q-ml-md">
              <q-btn dense flat icon="close" @click="() => removeProduct(prod)"></q-btn>
            </div>
          </div>
          <q-separator></q-separator>
        </q-item>
        <q-item v-if="savedProducts.length > 0">
          <q-btn dense flat icon class="btn btn-small btn-info btn-popup q-pa-md">Checkout</q-btn>
        </q-item>
      </q-list>
    </q-menu>
  </q-btn>
</template>
<script setup>
import useLocalStorage from '../compositionFunctions/useLocalStorage'
import { useCartStore } from '../stores/cart'
import { ref, inject } from 'vue'
import { EVENT_KEYS } from 'src/utils/eventKeys'
const bus = inject('bus')
const store = useCartStore()
const { retrieveCartData } = useLocalStorage()
const savedProducts = ref(retrieveCartData())
console.log(savedProducts)

function removeProduct(value) {
  store.removeProducts(value)
  savedProducts.value = retrieveCartData()
}

bus.on(EVENT_KEYS.CART_CHANGE, () => {
  savedProducts.value = retrieveCartData()
})

</script>
