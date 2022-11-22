<template>
  <q-expansion-item switch-toggle-side dense-toggle :label="labelName" :header-inset-level="1" :content-inset-level="1">
    <q-card>
      <q-card-section>
        {{ content }}
      </q-card-section>
    </q-card>
  </q-expansion-item>
</template>

<script setup>

const props = defineProps({
  content: String,
  labelName: String
})

</script>
