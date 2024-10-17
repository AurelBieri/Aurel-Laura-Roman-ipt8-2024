<template>
    <div class="login-register">
      <h2>Login/Register</h2>
      <form @submit.prevent="submitForm">
        <input type="email" v-model="email" placeholder="E-Mail" required />
        <input type="password" v-model="password" placeholder="Passwort" required />
        <button type="submit">Anmelden</button>
      </form>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        email: '',
        password: '',
      };
    },
    methods: {
      submitForm() {
        // Hier kommt die Login-Logik später hin
        alert(`E-Mail: ${this.email}, Passwort: ${this.password}`);
      },
    },
  };
  </script>
  