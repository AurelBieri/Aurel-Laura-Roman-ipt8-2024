<script setup>
import { useRouter } from 'vue-router';  

const router = useRouter();

function login() {
  router.push('/login');
}
</script>

<template>
<button @click="login">Login</button>
</template>