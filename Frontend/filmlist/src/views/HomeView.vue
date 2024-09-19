<template>
    <div>
      <h1>Willkommen zur Watchlist-App!</h1>
      <p>Mit dieser App kannst du deine Lieblingsfilme und Serien verwalten.</p>
      <router-link to="/watchlist" class="cta-button">Zu meiner Watchlist</router-link>
    </div>
  </template>
  
  <script>
  export default {
    name: 'HomeView',
  };
  </script>
  
  <style scoped>
  .cta-button {
    background-color: #42b983;
    color: white;
    padding: 10px 20px;
    text-decoration: none;
    border-radius: 5px;
  }
  </style>
  