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
            <li v-for="(movie, index) in watchlist.movies.slice(0, 5)" :key="index">
              {{ movie.title }}
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
        { id: 1, title: 'Top Filme 2023', movies: [{ title: 'Film 1' }, { title: 'Film 2' }, { title: 'Film 3' }, { title: 'Film 4' }, { title: 'Film 5' }, { title: 'Film 6' }] },
        { id: 2, title: 'Meine Lieblingsserien', movies: [{ title: 'Serie 1' }, { title: 'Serie 2' }, { title: 'Serie 3' }] },
        { id: 3, title: 'Dokumentationen', movies: [{ title: 'Doku 1' }, { title: 'Doku 2' }, { title: 'Doku 3' }, { title: 'Doku 4' }, { title: 'Doku 5' }, { title: 'Doku 6' }] },
        { id: 4, title: 'Zukünftige Filme', movies: [{ title: 'Film 7' }, { title: 'Film 8' }] },
        { id: 5, title: 'Top Horrorfilme', movies: [{ title: 'Horror 1' }, { title: 'Horror 2' }, { title: 'Horror 3' }, { title: 'Horror 4' }, { title: 'Horror 5' }, { title: 'Horror 6' }] }
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
  grid-template-columns: repeat(4, 1fr); 
  gap: 20px;
}

@media screen and (max-width: 800px) {
  .grid {
    grid-template-columns: repeat(2, 1fr); 
  }
}

@media screen and (max-width: 500px) {
  .grid {
    grid-template-columns: 1fr; 
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
