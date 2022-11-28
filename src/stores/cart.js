/* eslint-disable no-extra-boolean-cast */
import { defineStore } from 'pinia'
import { ref } from 'vue'
import useLocalStorage from '../compositionFunctions/useLocalStorage'
const { updateCart } = useLocalStorage()

export const useCartStore = defineStore('cart', () => {
  const products = ref(new Map())
  const totalProducts = ref(0)

  function addProducts(product, quantity) {
    if (products.value.get(product)) { products.value.set(product, quantity + products.value.get(product)) } else {
      products.value.set(product, quantity)
    }
    totalProducts.value += quantity
    updateCart(createListOfProducts())
  }

  function removeProducts(product) {
    // kinda shady
    for (const element of products.value.keys()) {
      if (element.id === product.id) {
        products.value.delete(element)
      }
    }
    updateCart(createListOfProducts())
  }

  function createListOfProducts() {
    const data = []
    for (const key of products.value.keys()) {
      const qt = products.value.get(key)
      data.push({ ...key, qt })
    }
    return data
  }

  function getNumberOfProducts() {
    return totalProducts.value
  }

  return { products, addProducts, removeProducts, createListOfProducts, getNumberOfProducts }
})
