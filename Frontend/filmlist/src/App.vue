<template>
  <div id="app">
    <header>
      <div class="header-content">
        <router-link to="/">
        <img src="@/Assets/watchlist-logo.jpg" alt="Watchlist App Logo" class="logo"/>
      </router-link>
        <h1>Deine Watchlisten</h1>
        <nav>
          <router-link to="/">Home</router-link>
        </nav>
      </div>
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

/* Header Styling */
header {
  background-color: #1a1f71; 
  padding: 25px 20px;
  color: white;
  position: relative; 
}

/* Header-Inhalt */
.header-content {
  display: flex;
  align-items: center;
  justify-content: space-between; 
}

/* Logo Styling */
.logo {
  width: 50px;
  height: auto;
  margin-right: 15px;
}

/* Title Styling */
h1 {
  margin: 0;
  font-size: 24px;
  position: absolute;
  left: 50%; 
  transform: translateX(-50%); 
}

nav {
  display: flex; 
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
