<template>
    <div class="login-form">
      <h2>Login</h2>
      <form @submit.prevent="handleLogin">
        <div class="form-group">
          <label for="email">Email:</label>
          <input
            type="email"
            id="email"
            v-model="email"
            required
          />
        </div>
  
        <div class="form-group">
          <label for="password">Passwort:</label>
          <input
            type="password"
            id="password"
            v-model="password"
            required
          />
        </div>
  
        <button type="submit">Anmelden</button>
      </form>
    </div>
  </template>
  
  <script setup>
  import { login } from '../api/request';
  import { ref } from 'vue';

  const email = ref('');
  const password = ref('');

  const errors = ref({
    email: '',
    password: '',
});

async function handleLogin(event) {
  event.preventDefault();
  try {
    await login(email.value, password.value);
    alert("Hat funktioniert!");
    //await router.push('/form');
  } catch (exception) {
    errors.value = exception.errors || { email: 'Login failed', password: 'Login failed' };
  }
}
  </script>
  
  <style scoped>
  .login-form {
    max-width: 300px;
    margin: 0 auto;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 2px 2px 12px rgba(0, 0, 0, 0.1);
  }
  
  .form-group {
    margin-bottom: 15px;
  }
  
  input {
    width: 100%;
    padding: 8px;
    margin-top: 5px;
    box-sizing: border-box;
  }
  
  button {
    width: 100%;
    padding: 10px;
    background-color: #007BFF;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
  }
  
  button:hover {
    background-color: #0056b3;
  }
  </style>
  