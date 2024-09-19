<template>
    <div id="app">
      <nav>
        <!-- Navigationslinks zur Home- und Watchlist-Seite -->
        <router-link to="/">Home</router-link>
        <router-link to="/watchlist">Watchlist</router-link>
      </nav>
      
      <!-- Zeigt die jeweilige View je nach Route an -->
      <router-view></router-view>
    </div>
  </template>
  
  <script>
  export default {
    name: 'App'
  };
  </script>
  
  <style>
  nav {
    display: flex;
    gap: 10px;
    padding: 10px;
    background-color: #f0f0f0;
  }
  
  nav a {
    text-decoration: none;
    color: #007bff;
  }
  
  nav a.router-link-exact-active {
    font-weight: bold;
    color: #0056b3;
  }
  </style>
  