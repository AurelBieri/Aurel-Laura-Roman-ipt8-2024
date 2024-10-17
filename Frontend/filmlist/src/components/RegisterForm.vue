<template>
    <div class="register-form">
      <h2>Registrieren</h2>
      <form @submit.prevent="handleRegister">
        <div class="form-group">
          <label for="username">Benutzername:</label>
          <input
            type="text"
            id="username"
            v-model="username"
            required
          />
        </div>
  
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
  
        <div class="form-group">
          <label for="confirmPassword">Passwort bestätigen:</label>
          <input
            type="password"
            id="confirmPassword"
            v-model="confirmPassword"
            required
          />
        </div>
  
        <button type="submit">Registrieren</button>
      </form>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import { useRouter } from 'vue-router';
  import { register } from '../api/request';
  
  
  const username = ref('');
  const email = ref('');
  const password = ref('');
  const confirmPassword = ref('');
  const router = useRouter();
  const errors = ref({
    username: '',
    email: '',
    password: '',
  });
  
  async function handleRegister(event) {
    event.preventDefault();
    if (password.value !== confirmPassword.value) {
      errors.value.password = 'Passwörter stimmen nicht überein';
      return;
    }
    try {
      // Registrierungs-Logik anpassen, um den Benutzernamen zu berücksichtigen
      await register(username.value, email.value, password.value);
      await router.push('/login');
    } catch (exception) {
      errors.value = exception.errors || { email: 'Registrierung fehlgeschlagen', password: 'Registrierung fehlgeschlagen' };
    }
  }
  </script>
  
  <style scoped>
  .register-form {
    max-width: 400px;
    margin: 0 auto;
    padding: 30px;
    border: 1px solid #ccc;
    border-radius: 8px;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    background-color: white;
  }
  
  h2 {
    margin-bottom: 25px;
    text-align: center;
    color: #333;
  }
  
  .form-group {
    margin-bottom: 20px;
  }
  
  label {
    font-weight: bold;
    margin-bottom: 5px;
    display: block;
  }
  
  input {
    width: 100%;
    padding: 10px;
    border: 1px solid #ddd;
    border-radius: 5px;
    box-sizing: border-box;
  }
  
  button {
    width: 100%;
    padding: 12px;
    background-color: #28a745;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    font-size: 16px;
  }
  
  button:hover {
    background-color: #218838;
  }
  </style>
  