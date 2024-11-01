<template>
  <div class="homepage">
    <h1>Schau dir deine Watchlisten an</h1>

    <!-- Watchlist-Erstellungsformular -->
    <div class="create-watchlist">
      <input
        type="text"
        v-model="newWatchlistTitle"
        placeholder="Watchlist-Titel eingeben"
      />
      <button @click="createWatchlist">Watchlist erstellen</button>
    </div>

    <!-- Liste der Watchlists anzeigen -->
    <div class="watchlist-section">
      <div class="grid">
        <div class="column" v-for="watchlist in watchlists" :key="watchlist.id">
          <router-link 
            :to="{ name: 'Watchlist', params: { id: watchlist.id }}"
            class="watchlist-link">
            <div class="watchlist-card">
              <h3 class="watchlist-title">{{ watchlist.name }}</h3>
              <ul class="watchlist-list">
                <li class="list">Filme:</li>
                <li class="mov" v-for="(movie, index) in watchlist.movies.slice(0, 3)" :key="index">
                  {{ movie.title }}
                </li>
              </ul>
            </div>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { makefilmlist, getallfilmlist } from '@/api/request';
export const STORAGE_KEY = "session_token";

export default {
  data() {
    return {
      watchlists: [], 
      newWatchlistTitle: '', 
    };
  },
  async mounted() {
    await this.fetchWatchlists();
  },
  methods: {
    async fetchWatchlists() {
      try {
        const userId = parseInt(localStorage.getItem('USERID'), 10);
        const response = await getallfilmlist(userId);
        console.log("Fetched watchlists:", response); // Log the response for debugging

        this.watchlists = response.$values.map(watchlist => ({
          id: watchlist.id,
          name: watchlist.name,
          createdAt: watchlist.createdAt,
          updatedAt: watchlist.updatedAt,
          movies: watchlist.movies.$values || [],
        }));
      } catch (error) {
        console.error("Error fetching watchlists:", error);
      }
    },

    async createWatchlist() {
      if (this.newWatchlistTitle) {
        const userId = parseInt(localStorage.getItem('USERID'), 10);
        const newWatchlist = {
          userId: userId,
          name: this.newWatchlistTitle,
          movies: [],
        };

        try {
          const createdWatchlist = await makefilmlist(newWatchlist);
          console.log("Created watchlist:", createdWatchlist); 
          this.newWatchlistTitle = ''; 
          await this.fetchWatchlists();
        } catch (error) {
          console.error("Error creating watchlist:", error);
        }
      }
    },
  },
};
</script>

<style scoped>
.homepage {
  text-align: center;
  background-color: #f0f4f8; /* Light background color for contrast */
  padding: 20px;
  border-radius: 10px;
}

.logo {
  width: 150px;
  margin-bottom: 20px;
}

.grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(250px, 1fr)); /* Responsive grid */
  gap: 20px;
  margin: 20px;
}

.column {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.watchlist-card {
  background-color: #e3f2fd; /* Light blue background */
  padding: 20px;
  border: 1px solid #bbdefb; /* Soft blue border */
  border-radius: 8px;
  transition: transform 0.2s, box-shadow 0.2s;
  width: 100%;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.15);
}

.watchlist-card:hover {
  transform: scale(1.03);
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2); /* Stronger shadow on hover */
}

.watchlist-title {
  font-size: 1.5em;
  margin-bottom: 10px;
  color: #1e88e5; /* Darker blue for title */
}

.list {
  font-weight: 600;
  margin-bottom: 5px;
  color: #424242; /* Dark grey for text */
}

.mov {
  font-size: small;
  margin: 5px 0;
  color: #616161; /* Slightly lighter grey for movie titles */
}

.create-watchlist {
  margin: 20px 0;
}

input {
  padding: 10px;
  width: 300px;
  margin-right: 10px;
  border: 1px solid #bbdefb; /* Light blue border */
  border-radius: 5px;
  font-size: 16px;
}

button {
  padding: 10px 20px;
  background-color: #2196f3; /* Button blue color */
  color: white;
  border: none;
  cursor: pointer;
  border-radius: 5px;
  font-size: 16px;
  transition: background-color 0.2s;
}

button:hover {
  background-color: #1976d2; /* Darker blue on hover */
}

.watchlist-list {
  list-style: none;
  padding: 0;
}

.watchlist-list li {
  margin: 5px 0;
}

.watchlist-link {
  display: block; 
  text-decoration: none; 
  color: #333; 
  width: 100%; 
  height: 100%; 
  padding: 20px; 
  box-sizing: border-box; 
}

.router-link-active {
  font-weight: bold;
}
</style>
