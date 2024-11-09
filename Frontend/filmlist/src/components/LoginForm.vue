<template>
  <div class="login-form">
    <h2>Login</h2>
    <form @submit.prevent="handleLogin">
      <div v-if="errorMessage" class="error-message">{{ errorMessage }}</div>

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

      <div class="register-link">
        <span>Kein Konto?</span>
        <router-link to="/register">Jetzt registrieren</router-link>
      </div>
    </form>
  </div>
</template>

<script setup>
import { login } from '../api/request';
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const email = ref('');
const password = ref('');
const router = useRouter();
const errorMessage = ref('');

async function handleLogin(event) {
  event.preventDefault();
  try {
    await login(email.value, password.value);
    await router.push('/');
  } catch (exception) {
    // Überprüfe, ob das Backend eine spezifische Fehlermeldung enthält
    if (exception.response && exception.response.data && exception.response.data.message) {
      errorMessage.value = exception.response.data.message;
    } else {
      errorMessage.value = 'Login failed. Please try again.';
    }
  }
}
</script>

<style scoped>
.login-form {
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

.error-message {
  color: red;
  margin-bottom: 15px;
  text-align: center;
}

.register-link {
  text-align: center;
  margin-top: 20px;
}

.register-link span {
  margin-right: 10px;
  font-size: 14px;
}

.register-link a {
  color: #007bff;
  text-decoration: none;
  font-weight: bold;
}

.register-link a:hover {
  text-decoration: underline;
}
</style>
