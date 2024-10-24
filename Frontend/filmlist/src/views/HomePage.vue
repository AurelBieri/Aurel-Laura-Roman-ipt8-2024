<template>
  <div class="homepage">
    <h1>Willkommen zu deinen Watchlists</h1>
    <div class="watchlist-section">
      <div class="grid">
        <div class="column" v-for="watchlist in publicWatchlists" :key="watchlist.id">
          <ul>
            <li>
              <router-link :to="{ name: 'Watchlist', params: { id: watchlist.id }}">
                {{ watchlist.title }}
              </router-link>
            </li>
          </ul>
        </div>
      </div>
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
        { id: 3, title: 'Dokumentationen', movies: [] },
        { id: 4, title: 'Zukünftige Filme', movies: [] },
        { id: 5, title: 'Top Horrorfilme', movies: [] }, // More lists for testing
        { id: 6, title: 'Comedy-Filme', movies: [] }
      ],
    };
  }
};
</script>

<style scoped>
.homepage {
  padding: 20px;
}

.grid {
  display: grid;
  grid-template-columns: repeat(4, 1fr); /* 4 columns per row */
  gap: 20px;
}

/* Ensure columns stack when screen width is below 800px */
@media screen and (max-width: 800px) {
  .grid {
    grid-template-columns: repeat(2, 1fr); /* 2 columns per row on smaller screens */
  }
}

@media screen and (max-width: 500px) {
  .grid {
    grid-template-columns: 1fr; /* 1 column per row on very small screens */
  }
}

.column {
  background-color: #f9f9f9;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 8px;
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
