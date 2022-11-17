import { LocalStorage } from 'quasar'

export default function () {
  const LOCAL_STORAGE_KEY = {
    GRID_ITEMS: 'GridItems',
    PROFILE_PICTURE: 'ProfilePicture'
  }

  function addToLocalStorage (key, value) {
    try {
      LocalStorage.set(key, value)
    } catch (e) {
      console.log('Could not save data on local storage')
    }
  }

  function retrieveGridData () {
    return LocalStorage.getItem(LOCAL_STORAGE_KEY.GRID_ITEMS) || []
  }

  function retrieveProfilePicture () {
    return LocalStorage.getItem(LOCAL_STORAGE_KEY.PROFILE_PICTURE) || ''
  }

  function clearLocalStorage () {
    LocalStorage.clear()
  }

  return {
    LOCAL_STORAGE_KEY,
    addToLocalStorage,
    retrieveGridData,
    retrieveProfilePicture,
    clearLocalStorage
  }
}
