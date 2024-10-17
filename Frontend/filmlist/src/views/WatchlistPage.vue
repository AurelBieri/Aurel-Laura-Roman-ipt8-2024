<template>
  <div class="watchlist-page">
    <h1>{{ watchlist.title }}</h1>

    <ul>
      <li v-for="movie in watchlist.movies" :key="movie.title">
        {{ movie.title }}
      </li>
    </ul>

    <!-- Formular zum Hinzufügen eines neuen Films -->
    <div class="add-movie">
      <input v-model="newMovieTitle" placeholder="Neuen Film hinzufügen" />
      <button @click="addMovie">Hinzufügen</button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'WatchlistPage', // Ändere den Namen in einen mehrteiligen Namen
  props: ['id'],
  data() {
    return {
      watchlist: null,
      newMovieTitle: '',
    };
  },
  mounted() {
    const watchlists = JSON.parse(localStorage.getItem('watchlists')) || [];
    this.watchlist = watchlists.find((wl) => wl.id == this.id);
  },
  methods: {
    addMovie() {
      if (this.newMovieTitle) {
        this.watchlist.movies.push({ title: this.newMovieTitle });

        const watchlists = JSON.parse(localStorage.getItem('watchlists')) || [];
        const index = watchlists.findIndex((wl) => wl.id == this.id);
        if (index !== -1) {
          watchlists[index] = this.watchlist;
          localStorage.setItem('watchlists', JSON.stringify(watchlists));
        }

        this.newMovieTitle = '';
      }
    },
  },
};
</script>

<style scoped>
.watchlist-page {
  padding: 20px;
}

ul {
  list-style: none;
  padding: 0;
}

li {
  margin: 10px 0;
}

.add-movie {
  margin-top: 20px;
}

input {
  padding: 10px;
  width: 300px;
}

button {
  padding: 10px;
  background-color: #42b983;
  color: white;
  border: none;
  cursor: pointer;
  border-radius: 5px;
}
</style>
