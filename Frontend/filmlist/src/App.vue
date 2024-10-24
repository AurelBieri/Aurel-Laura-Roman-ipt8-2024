<template>
    <div id="app">
      <header>
        <h1>Meine Watchlist App</h1>
        <nav>
          <router-link to="/">Home</router-link>
          <router-link to="/watchlist/1">Watchlist</router-link>
        </nav>
      </header>
      <main>
        <router-view />
      </main>
    </div>
  </template>
  
  <script>
  export default {
    name: 'App',
  };
  </script>
  
  <style scoped>
  #app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    text-align: center;
    margin-top: 20px;
  }
  
  header {
    background-color: #42b983;
    padding: 10px;
    color: white;
  }
  
  nav a {
    margin: 0 15px;
    color: white;
    text-decoration: none;
  }
  
  nav a.router-link-exact-active {
    font-weight: bold;
  }
  
  main {
    padding: 20px;
  }
  </style>
  