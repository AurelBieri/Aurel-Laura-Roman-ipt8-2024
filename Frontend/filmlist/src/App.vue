<template>
    <div id="app">
      <nav>
        <router-link to="/">Home</router-link>
        <router-link to="/watchlist">Watchlist</router-link>
      </nav>
      
      <!-- Hier werden die Inhalte der Views basierend auf der Route angezeigt -->
      <router-view></router-view>
    </div>
  </template>
  
  <script>
  export default {
    name: 'App',
  };
  </script>
  
  <style>
  nav {
    display: flex;
    gap: 10px;
  }
  </style>
  