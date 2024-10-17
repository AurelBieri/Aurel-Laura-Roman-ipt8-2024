<template>
  <div class="homepage">
    <h1>Willkommen zu deinen Watchlists</h1>
    <div class="watchlist-section">
      <ul>
        <li v-for="watchlist in publicWatchlists" :key="watchlist.id">
          <router-link :to="{ name: 'Watchlist', params: { id: watchlist.id }}">
            {{ watchlist.title }}
          </router-link>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: 'HomePage',
  data() {
    return {
      publicWatchlists: JSON.parse(localStorage.getItem('watchlists')) || [
        { id: 1, title: 'Top Filme 2023', movies: [] },
        { id: 2, title: 'Meine Lieblingsserien', movies: [] },
      ],
    };
  }
};
</script>

<style scoped>
.homepage {
  padding: 20px;
}

h1 {
  color: #42b983;
  text-align: center;
}

ul {
  list-style: none;
  padding: 0;
}

li {
  padding: 10px;
  border-bottom: 1px solid #ccc;
}

a {
  text-decoration: none;
  color: #42b983;
}

a:hover {
  text-decoration: underline;
}
</style>
