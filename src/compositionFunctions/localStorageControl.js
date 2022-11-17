import { LocalStorage } from 'quasar'

export function addToLocalStorage (key, value) {
  try {
    LocalStorage.set(key, value)
  } catch (e) {
    console.log('Could not save data on local storage')
  }
}

export function retrieveGridData () {
  const tableKeys = LocalStorage.getAllKeys().filter(key => key !== 'photo')
  const tableData = []
  if (tableKeys.length > 0) {
    tableKeys.forEach(key => tableData.push(LocalStorage.getItem(key)))
  }
  return tableData
}

export function retrieveProfilePicture () {
  return LocalStorage.getItem('photo')
}

export function getLastIndex () {
  return LocalStorage.getLength()
}

export function clearLocalStorage () {
  LocalStorage.clear()
}
