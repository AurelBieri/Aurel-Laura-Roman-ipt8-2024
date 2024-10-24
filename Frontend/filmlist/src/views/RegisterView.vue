<template>
    <div class="register-page">
      <RegisterForm />
    </div>
  </template>
  
  <script setup>
  import RegisterForm from '../components/RegisterForm.vue';
  </script>
  
  <style scoped>
  .register-page {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    height: 100vh;
    background-color: #f5f5f5;
  }
  </style>
  