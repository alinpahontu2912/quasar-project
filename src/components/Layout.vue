<template>
  <div id="q-app">
    <div class="q-pa-md">
      <q-layout view="hHh Lpr lff" style="height: 100vh" class="shadow-2 rounded-borders">
        <Header />
        <Drawer />
        <q-page-container>
          <q-page padding>
            <HomePage />
          </q-page>
        </q-page-container>
      </q-layout>
    </div>
  </div>
</template>

<script setup>

import Drawer from './Drawer.vue'
import Header from './Header.vue'
import HomePage from './HomePage.vue'
</script>
