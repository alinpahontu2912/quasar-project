/* eslint-disable no-extra-boolean-cast */
import { defineStore } from 'pinia'
import { ref } from 'vue'
import useLocalStorage from '../compositionFunctions/useLocalStorage'
const { updateCart } = useLocalStorage()

export const useCartStore = defineStore('cart', () => {
  const products = ref(new Map())
  const totalProducts = ref(0)

  function addProducts(product, quantity) {
    let qt = quantity
    if (!!products.value.get(product.id)) {
      qt += products.value.get(product.id).qt
      products.value.set(product.id, { ...product, qt })
    } else {
      products.value.set(product.id, { ...product, qt })
    }
    totalProducts.value += quantity
    updateCart(createListOfProducts())
  }

  function removeProducts(product) {
    totalProducts.value -= products.value.get(product.id).qt
    products.value.delete(product.id)
    updateCart(createListOfProducts())
  }

  function createListOfProducts() {
    return Array.from(products.value.values())
  }

  function getNumberOfProducts() {
    return totalProducts.value
  }

  return { products, addProducts, removeProducts, createListOfProducts, getNumberOfProducts }
})
