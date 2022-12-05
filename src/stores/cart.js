/* eslint-disable no-extra-boolean-cast */
import { defineStore } from 'pinia'
import { ref } from 'vue'
import useLocalStorage from '../compositionFunctions/useLocalStorage'
const { updateCart, retrieveCartData, retrieveNumberOfProducts, updateTotalProducts } = useLocalStorage()

export const useCartStore = defineStore('cart', () => {
  const products = ref(retrieveCartData())
  const totalProducts = ref(retrieveNumberOfProducts())
  function addProducts(product, quantity) {
    const index = products.value.findIndex(x => x.id === product.id)
    if (index !== -1) {
      products.value[index].quantity += quantity
    } else {
      products.value.push({ ...product, quantity })
    }
    totalProducts.value += quantity
    updateTotalProducts(totalProducts.value)
    updateCart(products.value)
  }

  function removeProducts(product) {
    const index = products.value.findIndex(x => x.id === product.id)
    totalProducts.value -= products.value[index].quantity
    products.value.splice(index, 1)
    updateTotalProducts(totalProducts.value)
    updateCart(products.value)
  }

  return { products, totalProducts, addProducts, removeProducts }
})
