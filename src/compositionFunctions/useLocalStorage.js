import { LocalStorage } from 'quasar'
const LOCAL_STORAGE_KEY = {
  PROFILE_PICTURE: 'ProfilePicture',
  GRID_ITEMS: 'GridItems',
  CART_ITEMS: 'CartItems',
  TOTAL_PRODUCTS: 'numberOfProducts'
}

export default function () {
  function updateCart(value) {
    try {
      LocalStorage.set(LOCAL_STORAGE_KEY.CART_ITEMS, value)
    } catch (e) {
      console.log('Could not save data on local storage')
    }
  }

  function retrieveCartData() {
    return LocalStorage.getItem(LOCAL_STORAGE_KEY.CART_ITEMS) || []
  }

  function updateTotalProducts(value) {
    try {
      LocalStorage.set(LOCAL_STORAGE_KEY.TOTAL_PRODUCTS, value)
    } catch (e) {
      console.log('Could not save data on local storage')
    }
  }

  function retrieveNumberOfProducts() {
    return LocalStorage.getItem(LOCAL_STORAGE_KEY.TOTAL_PRODUCTS) || 0
  }

  function updateGrid(value) {
    try {
      LocalStorage.set(LOCAL_STORAGE_KEY.GRID_ITEMS, value)
    } catch (e) {
      console.log('Could not save data on local storage')
    }
  }

  function updateProfilePicture(value) {
    try {
      LocalStorage.set(LOCAL_STORAGE_KEY.PROFILE_PICTURE, value)
    } catch (e) {
      console.log('Could not save data on local storage')
    }
  }

  function retrieveGridData() {
    return LocalStorage.getItem(LOCAL_STORAGE_KEY.GRID_ITEMS) || []
  }

  function retrieveProfilePicture() {
    return LocalStorage.getItem(LOCAL_STORAGE_KEY.PROFILE_PICTURE) || ''
  }

  function clearLocalStorage() {
    LocalStorage.clear()
  }

  return {
    updateGrid,
    updateProfilePicture,
    updateCart,
    updateTotalProducts,
    retrieveNumberOfProducts,
    retrieveGridData,
    retrieveProfilePicture,
    retrieveCartData,
    clearLocalStorage
  }
}
