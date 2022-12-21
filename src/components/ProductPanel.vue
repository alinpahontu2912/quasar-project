<template>
  <q-table class="my-sticky-virtscroll-table" style="height: 80vh;" virtual-scroll v-model:pagination="pagination"
    :rows-per-page-options="[0]" :virtual-scroll-sticky-size-start="48" row-key="id" title="Products" :rows="rows"
    :columns="columns" selection="multiple" :loading="loading">
    <template v-slot:loading>
      <q-inner-loading showing color="primary" />
    </template>
    <template v-slot:top-right>
      <q-btn icon="add" @click="openNewProductForm" />
    </template>
    <template v-slot:header-selection>
      <q-btn flat icon="refresh" label="Refresh" @click="refresh" />
    </template>
    <template v-slot:body-selection="scope">
      <q-btn flat icon="delete" @click="openDeletePopup(scope.row.id)">
        <q-tooltip>
          Delete Product
        </q-tooltip>
      </q-btn>
      <q-btn flat icon="edit" @click="openPricePopup(scope.row.id, scope.row.price)">
        <q-tooltip>
          Update Price
        </q-tooltip>
      </q-btn>
    </template>
    <template v-slot:body-cell-price="props">
      <q-td>
        {{ props.row.price }}
        <q-popup-edit v-model="props.row.price" auto-save v-slot="scope">
          <q-input type="number" v-model.number="scope.value" dense autofocus />
        </q-popup-edit>
      </q-td>
    </template>
  </q-table>
  <q-dialog v-model="firstDeletePopUp">
    <q-card>
      <q-card-section class="row items-center q-pb-none">
        <div class="text-h6">Are you sure you want to delete the product?</div>
        <q-space></q-space>
        <q-btn icon="close" flat round dense v-close-popup></q-btn>
      </q-card-section>
      <q-card-section class="row justify-around">
        <q-btn color="primary" label="YES" v-close-popup @click="deleteFromDB(selectedProdId)" />
        <q-btn color="primary" label="NO" v-close-popup />
      </q-card-section>
    </q-card>
  </q-dialog>
  <q-dialog v-model="secondDialog" transition-show="scale" transition-hide="scale">
    <q-card class="bg-teal text-white" style="width: 300px; height: 60px;">
      <q-card-section v-close-popup class="row items-center justify-center">
        {{ deleteResult }}
      </q-card-section>
    </q-card>
  </q-dialog>
  <q-dialog v-model="pricePopUp" transition-show="scale" transition-hide="scale">
    <q-card class="bg-teal text-white" style="width: 300px; height: 60px;">
      <q-card-section v-close-popup class="row items-center justify-center">
        {{ updateResult }}
      </q-card-section>
    </q-card>
  </q-dialog>
  <NewProductFormVue />
</template>

<script setup>
import { ref, inject } from 'vue'
import NewProductFormVue from './NewProductForm.vue'
import { EVENT_KEYS } from '../utils/eventKeys.js'
import useHttpQuery from 'src/compositionFunctions/useHttpQuery'
const { getNoPaginationProducts, deleteProduct, updateProductPrice } = useHttpQuery()
const pagination = ref({ pagination: { rowsPerPage: 0 } })
const selectedProdId = ref(-1)
const firstDeletePopUp = ref(false)
const deleteResult = ref('')
const updateResult = ref('')
const secondDialog = ref(false)
const pricePopUp = ref(false)
const loading = ref(false)
const bus = inject('bus')
const columns = [{
  name: 'id',
  required: true,
  label: 'Id Produs',
  align: 'center',
  field: row => row.id,
  format: val => `${val}`,
  sortable: true
},
{
  name: 'name',
  label: 'Nume Produs',
  align: 'center',
  field: row => row.name,
  format: val => `${val}`,
  sortable: true
},
{
  name: 'price',
  label: 'Pret Produs',
  align: 'center',
  field: row => row.price,
  format: val => `${val}`,
  sortable: true
},
{
  name: 'description',
  label: 'Descriere Produs',
  align: 'center',
  field: row => row.description.slice(0, 50),
  format: val => `${val}`
},
{
  name: 'image',
  label: 'Imagine Produs',
  align: 'center',
  field: row => row.image,
  format: val => `${val}`
}
]

const rows = ref([])

refresh()

async function refresh() {
  rows.value.length = 0
  loading.value = true
  rows.value = await getNoPaginationProducts()
  loading.value = false
}

function openDeletePopup(productId) {
  firstDeletePopUp.value = !firstDeletePopUp.value
  selectedProdId.value = productId
}

async function openPricePopup(productId, newPrice) {
  loading.value = true
  const result = await updateProductPrice(productId, newPrice)
  updateResult.value = result ? 'Price updated' : 'Error'
  pricePopUp.value = !pricePopUp.value
  loading.value = false
}

async function deleteFromDB(productId) {
  loading.value = true
  const result = await deleteProduct(productId)
  secondDialog.value = !secondDialog.value
  deleteResult.value = result ? 'Product removed' : 'Removal issue'
  await refresh()
  loading.value = false
}

function openNewProductForm() {
  bus.emit(EVENT_KEYS.NEW_PRODUCT, rows.value[rows.value.length - 1].id)
}

</script>
<style lang="sass">
.my-sticky-virtscroll-table
  height: 410px
  .q-table__top,
  .q-table__bottom,
  thead tr:first-child th
    background-color: #fff

  thead tr th
    position: sticky
    z-index: 1
  thead tr:last-child th
    top: 48px
  thead tr:first-child th
    top: 0
</style>
