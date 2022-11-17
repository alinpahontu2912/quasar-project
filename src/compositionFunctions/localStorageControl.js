import { LocalStorage } from 'quasar'

const LOCAL_STORAGE_KEY = {
  GRID_ITEMS: 'GridItems',
  PHOTO: 'photo'
}

export function addToLocalStorage (key, value) {
  try {
    LocalStorage.set(key, value)
  } catch (e) {
    console.log('Could not save data on local storage')
  }
}

export function retrieveGridData () {
  return LocalStorage.getItem(LOCAL_STORAGE_KEY.GRID_ITEMS) || []
}

export function retrieveProfilePicture () {
  return LocalStorage.getItem(LOCAL_STORAGE_KEY.PHOTO)
}

export function getLastIndex () {
  return LocalStorage.getLength()
}

export function clearLocalStorage () {
  LocalStorage.clear()
}
