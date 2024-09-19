<script setup>
import { useRouter } from 'vue-router';  

const router = useRouter();

function login() {
  router.go('/login');
}
</script>

<template>
<button @click="login">Login</button>
</template>