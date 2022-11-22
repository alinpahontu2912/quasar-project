import { LocalStorage } from 'quasar'
const LOCAL_STORAGE_KEY = {
  PROFILE_PICTURE: 'ProfilePicture',
  GRID_ITEMS: 'GridItems'
}

export default function () {
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
    retrieveGridData,
    retrieveProfilePicture,
    clearLocalStorage
  }
}
