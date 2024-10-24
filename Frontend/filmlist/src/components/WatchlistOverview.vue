<template>
  <div class="watchlist-overview">
    <ul>
      <li v-for="watchlist in watchlists" :key="watchlist.id">
        <router-link :to="{ name: 'Watchlist', params: { id: watchlist.id }}">
          {{ watchlist.title }}
        </router-link>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'WatchlistOverview',
  props: {
    watchlists: Array,
  },
};
</script>

<style scoped>
.watchlist-overview ul {
  list-style: none;
  padding: 0;
}

.watchlist-overview li {
  padding: 10px;
  border-bottom: 1px solid #ccc;
  font-size: 18px;
}

.watchlist-overview a {
  text-decoration: none;
  color: #42b983;
}

.watchlist-overview a:hover {
  text-decoration: underline;
}
</style>
