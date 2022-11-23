<template>
  <div id="q-app">
    <div class="q-pa-md">
      <q-layout view="hHh Lpr lff" style="height: 100vh" class="shadow-2 rounded-borders">
        <q-header elevated class="bg-black">
          <div class="row no-wrap items-center q-mt-md q-pa-sm">
            <q-btn flat @click="toggleDrawer" round dense icon="menu"></q-btn>
            <q-space />
            <ProfilePicture />
          </div>
        </q-header>
        <q-drawer bordered v-model="drawer" :width="300" :breakpoint="600" show-if-above>
          <q-scroll-area class="fit">
            <q-list padding class="menu-list">
              <q-item>
                <div class="col-6">
                  <q-img src="https://cdn.quasar.dev/img/parallax2.jpg" no-native-menu :ratio="4 / 3">
                    <div class="absolute-bottom-right text-subtitle2">
                      Logo Test
                    </div>
                  </q-img>
                </div>
              </q-item>
            </q-list>
          </q-scroll-area>
        </q-drawer>
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

import { ref } from 'vue'
import HomePage from './HomeView.vue'
import ProfilePicture from './ProfilePicture.vue'
const drawer = ref(true)

function toggleDrawer() {
  drawer.value = !drawer.value
}

</script>
