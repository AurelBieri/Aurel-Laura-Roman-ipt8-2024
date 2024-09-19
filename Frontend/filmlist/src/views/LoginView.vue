<template>
    <div class="login-page">
      <LoginForm />
    </div>
  </template>
  
  <script>
  import LoginForm from '../components/LoginForm.vue'; 
  
  export default {
    components: {
      LoginForm, 
    },
  };
  </script>
  
  <style scoped>
  .login-page {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    height: 100vh;
    background-color: #f5f5f5;
  }
  
  h1 {
    margin-bottom: 20px;
  }
  </style>