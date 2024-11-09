<template>
  <div class="watchlist-page">
    <div v-if="watchlist">
      <h1>{{ watchlist.title }}</h1>

      <div class="add-movie">
        <input v-model="newMovieTitle" placeholder="Add a new movie" />
        <button @click="addMovie">Add</button>
      </div>

      <div class="movie-section">
        <h2>To Watch</h2>
        <ul>
          <li v-if="sortedMovies.filter(m => !m.isWatched).length === 0">No movies to watch.</li>
          <li v-for="(movie, index) in sortedMovies.filter(m => !m.isWatched)" :key="movie.id">
            {{ movie.title }}
            <div class="actions">
              <button @click="markAsWatched(index)">Mark as Watched</button>
              <button @click="removeMovie(index, false)">Delete</button>
            </div>
          </li>
        </ul>
      </div>

      <div class="watched-section">
        <h2>Watched</h2>
        <ul>
          <li v-if="sortedMovies.filter(m => m.isWatched).length === 0">No watched movies.</li>
          <li v-for="(movie, index) in sortedMovies.filter(m => m.isWatched)" :key="movie.id" class="watched">
            {{ movie.title }}
            <div class="actions">
              <button @click="removeMovie(index, true)">Delete</button>
            </div>
          </li>
        </ul>
      </div>

      <button class="delete-watchlist" @click="deleteWatchlist">Delete Watchlist</button>
    </div>

    <div v-else>
      <p>Loading watchlist or not found.</p>
    </div>
  </div>
</template>



<script>
import { getfilmlistbyid, addMovieToWatchlist, markMovieAsWatched, markMovieAsUnwatched, deleteMovieFromWatchlist, deleteWatchlistById } from '@/api/request';
import { useRouter } from 'vue-router';

export default {
  props: ['id'],
  data() {
    return {
      watchlist: null,
      newMovieTitle: '',
    };
  },
  computed: {
    sortedMovies() {
      return [...this.watchlist.movies].sort((a, b) => {
        if (a.isWatched === b.isWatched) return 0;
        return a.isWatched ? 1 : -1;
      });
    }
  },
  async mounted() {
    this.router = useRouter();
    await this.fetchWatchlist();
  },
  methods: {
    async deleteWatchlist() {
      try {
        await deleteWatchlistById(this.watchlist.id);
        this.$emit('watchlistDeleted'); 
        this.router.push('/'); 
      } catch (error) {
        console.error("Error deleting watchlist:", error);
      }
    },
    async markAsWatched(index) {
      const movie = this.watchlist.movies[index];
      try {
        await markMovieAsWatched(this.watchlist.id, movie.id);
        movie.isWatched = true;
        this.watchlist.movies.splice(index, 1);
        this.watchlist.movies.push(movie); 
      } catch (error) {
        console.error("Error marking movie as watched:", error);
      }
    },
    async markAsUnwatched(index) {
      const movie = this.watchlist.movies[index];
      try {
        await markMovieAsUnwatched(this.watchlist.id, movie.id);
        movie.isWatched = false;
        this.watchlist.movies.splice(index, 1);
        this.watchlist.movies.push(movie); 
      } catch (error) {
        console.error("Error marking movie as unwatched:", error);
      }
    },
    async removeMovie(index, isWatched) {
  const movieList = isWatched
    ? this.watchlist.movies.filter(m => m.isWatched)
    : this.watchlist.movies.filter(m => !m.isWatched);

  const movie = movieList[index]; 

  if (movie) {
    const originalIndex = this.watchlist.movies.findIndex(m => m.id === movie.id);

    if (originalIndex !== -1) {
      try {
        await deleteMovieFromWatchlist(this.watchlist.id, movie.id);
        this.watchlist.movies.splice(originalIndex, 1); 
      } catch (error) {
        console.error("Error deleting movie:", error);
      }
    }
  }
    },
    async fetchWatchlist() {
      try {
        const response = await getfilmlistbyid(this.id);
        this.watchlist = {
          id: response.id,
          title: response.name,
          movies: response.movies.$values.map(movie => ({
            id: movie.id,
            title: movie.title,
            isWatched: movie.isWatched,
          })),
        };
      } catch (error) {
        console.error('Error fetching watchlist:', error);
      }
    },
    async addMovie() {
      if (this.newMovieTitle) {
        try {
          const newMovie = { title: this.newMovieTitle, isWatched: false };
          const addedMovie = await addMovieToWatchlist(this.id, newMovie);
          this.watchlist.movies.push(addedMovie);
          this.newMovieTitle = '';
        } catch (error) {
          console.error('Error adding movie:', error);
        }
      }
    },
  },
};
</script>

<style scoped>
.watchlist-page {
  padding: 20px;
  max-width: 600px;
  margin: auto;
  font-family: Arial, sans-serif;
}

h1 {
  color: #1e3a8a; /* Dark blue */
  text-align: center;
}

.movie-section, .watched-section {
  margin-top: 20px;
}

h2 {
  color: #1e3a8a; /* Dark blue */
  border-bottom: 2px solid #1e3a8a;
  padding-bottom: 5px;
}

ul {
  list-style: none;
  padding: 0;
}

li {
  padding: 15px;
  background-color: #e0f2fe; /* Light blue background */
  border-radius: 8px;
  margin-bottom: 10px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  transition: background-color 0.3s;
}

li.watched {
  background-color: #dbeafe; /* Lighter blue for watched movies */
  text-decoration: none; /* Remove strikethrough */
}

.actions {
  display: flex;
  gap: 10px;
}

button {
  padding: 8px 12px;
  background-color: #1e3a8a; /* Dark blue button */
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

button:hover {
  background-color: #2563eb; /* Brighter blue on hover */
}

.add-movie {
  margin-top: 20px;
  display: flex;
  justify-content: center;
}

input {
  padding: 10px;
  border: 1px solid #1e3a8a;
  border-radius: 5px;
  margin-right: 10px;
}

.delete-watchlist {
  position: fixed; /* Fix the button position */
  bottom: 20px; /* Space from the bottom */
  right: 20px; /* Space from the right */
  padding: 10px;
  background-color: #b91c1c; /* Red button for deletion */
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.delete-watchlist:hover {
  background-color: #c53030; /* Darker red on hover */
}

</style>