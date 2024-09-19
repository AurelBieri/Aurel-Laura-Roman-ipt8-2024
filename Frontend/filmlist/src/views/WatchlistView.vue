<template>
  <div class="watchlist">
    <h1>Meine Watchlist</h1>

    <!-- Formular zum Hinzufügen neuer Filme -->
    <form @submit.prevent="addMovie">
      <input v-model="newMovieTitle" placeholder="Neuen Film hinzufügen" required>
      <button type="submit">Hinzufügen</button>
    </form>

    <!-- Watchlist mit Filmen -->
    <div v-if="movies.length">
      <h2>Filme:</h2>
      <ul>
        <watchlist-item
          v-for="(movie, index) in movies"
          :key="index"
          :movie="movie"
          @toggle-watched="toggleWatched"
          @remove="removeMovie"
        />
      </ul>
    </div>

    <p v-else>Deine Watchlist ist leer.</p>
  </div>
</template>

<script>
import WatchlistItem from '@/components/WatchlistItem.vue';

export default {
  name: 'WatchlistView',
  components: {
    WatchlistItem
  },
  data() {
    return {
      newMovieTitle: '',
      movies: [
        { title: 'Inception', watched: false },
        { title: 'The Matrix', watched: true }
      ]
    };
  },
  methods: {
    addMovie() {
      if (this.newMovieTitle.trim() !== '') {
        const newMovie = {
          title: this.newMovieTitle,
          watched: false
        };
        this.movies.push(newMovie);
        this.newMovieTitle = '';
      }
    },
    toggleWatched(movie) {
      movie.watched = !movie.watched;
    },
    removeMovie(movie) {
      this.movies = this.movies.filter(m => m !== movie);
    }
  }
};
</script>

<style scoped>
.watchlist {
  padding: 20px;
  background-color: #f9f9f9;
  border-radius: 10px;
}

form {
  margin-bottom: 20px;
}

input {
  padding: 10px;
  margin-right: 10px;
}

button {
  padding: 10px;
}

ul {
  list-style-type: none;
  padding-left: 0;
}

li {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

button {
  background-color: #ff4d4f;
  color: white;
  border: none;
  padding: 5px 10px;
  border-radius: 3px;
}
</style>
