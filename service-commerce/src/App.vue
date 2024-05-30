<template>
  <div class="w-full h-screen bg-gray-50 flex flex-col gap-6 justify-center items-center">
    <router-view />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "App",
});
</script>