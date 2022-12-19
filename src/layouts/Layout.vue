<template>
  <div id="q-app">
    <div class="q-pa-md">
      <q-layout view="hHh Lpr lff">
        <Header />
        <Drawer />
        <q-page-container style="height: 80vh;">
          <q-page padding>
            <router-view />
          </q-page>
        </q-page-container>
      </q-layout>
    </div>
  </div>
</template>

<script setup>

import Drawer from '../components/Drawer.vue'
import Header from '../components/Header.vue'
</script>
