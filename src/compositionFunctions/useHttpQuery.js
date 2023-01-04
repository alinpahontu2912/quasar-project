import { Product } from 'src/models/Product'
import { User } from 'src/models/User'

import axios from 'axios'
const storeEndpoint = 'http://localhost:7023/api/products/'
const userEndpoint = ' http://localhost:7023/api/users'

function createPageNumberQuery(pageNumber, pageSize) {
  const target = new URL(storeEndpoint)
  const params = new URLSearchParams()
  params.set('pgsize', pageSize)
  params.set('page', pageNumber)
  target.search = params.toString()
  return target.href
}

function createUserCredentialsQuery(user, password) {
  const target = new URL(userEndpoint)
  const params = new URLSearchParams()
  params.set('user', user)
  params.set('pswd', password)
  target.search = params.toString()
  return target.href
}

function createDeleteIdQuery(productId) {
  const target = new URL(storeEndpoint + 'delete/')
  return target.href + productId
}

function createPriceUpdateQuery(productId, newPrice) {
  const target = new URL(storeEndpoint)
  return target.href + productId + '/' + newPrice
}

export default function () {
  async function verifyUserCredentials(user, password) {
    try {
      const response = await axios.get(createUserCredentialsQuery(user, password))
      if (response.status === 200) {
        return response.data
      }
    } catch (error) {
      return null
    }
  }

  async function addNewUser(email, fullName, phoneNumber, password, address) {
    const newUser = new User(email, fullName, phoneNumber, password, address)
    try {
      const response = await axios.post(userEndpoint + '/add/', newUser)
      return response.data
    } catch (error) {
      return null
    }
  }

  async function getNoPaginationProducts() {
    const response = await axios.get(storeEndpoint)
    const data = response.data
    const products = []
    for (let i = 0; i < data.length; i++) {
      products.push(new Product(...Object.values(data[i])))
    }
    return products
  }

  async function loadPage(index, pageSize, done, container) {
    const response = await axios.get(createPageNumberQuery(index, pageSize))
    const data = response.data
    for (let i = 0; i < data.length; i++) {
      container.push(new Product(...Object.values(data[i])))
    }
    done()
  }

  async function deleteProduct(productId) {
    const response = await axios.delete(createDeleteIdQuery(productId))
    return response.status === 200
  }

  async function updateProductPrice(productId, newPrice) {
    const response = await axios.put(createPriceUpdateQuery(productId, newPrice))
    return response.status === 200
  }

  async function addProduct(productId, name, price, description, image) {
    const newProd = new Product(productId, name, price, description, image)
    const response = await axios.post(storeEndpoint + 'add/', newProd)
    return response.status === 200
  }

  return { getNoPaginationProducts, deleteProduct, loadPage, updateProductPrice, addProduct, addNewUser, verifyUserCredentials }
}
