<template>
  <div class="homepage">
    <h1>Willkommen zu meiner Watchlist App</h1>

    <!-- Logo anzeigen -->
    <img src="@/Assets/watchlist.png" alt="Watchlist App Logo" class="logo"/>

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
          <ul class="watchlist-list">
            <!-- Verlinke zu den Watchlist-Details -->
            <li class="list">
                {{ watchlist.name }}
            </li>
            <li class="mov" v-for="(movie, index) in watchlist.movies.slice(0, 3)" :key="index">
              {{ movie.title }}
            </li>
          </ul>
        </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { makefilmlist, getallfilmlist } from '@/api/request';

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
    const response = await getallfilmlist();
    console.log("Fetched watchlists:", response); // Log the response for debugging

    // Assuming response.$values is where the actual data is
    this.watchlists = response.$values.map(watchlist => ({
      id: watchlist.id,
      name: watchlist.name,
      createdAt: watchlist.createdAt,
      updatedAt: watchlist.updatedAt,
      movies: watchlist.movies.$values || [], // Extract movies array
    }));
  } catch (error) {
    console.error("Error fetching watchlists:", error);
  }
}
,

    async createWatchlist() {
      if (this.newWatchlistTitle.trim()) {
        const newWatchlist = {
          title: this.newWatchlistTitle.trim(),
          movies: [], // Initialize with an empty list of movies
        };

        try {
          const response = await makefilmlist(newWatchlist);
          if (response.ok) {
            const createdWatchlist = await response.json();
            this.watchlists.push(createdWatchlist); // Add to watchlists
            this.newWatchlistTitle = ''; // Clear input
          } else {
            console.error("Failed to create watchlist.");
          }
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
}

.logo {
  width: 150px;
  margin-bottom: 20px;
}

.grid {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 20px;
}

.column {
  background-color: #f9f9f9;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 8px;
}

.list {
  text-align: center;
  font-size:large;
  font-weight: 600;
}

.mov {
  text-align: center;
  font-size:small;
}

h1 {
  color: #42b983;
  text-align: center;
}

.create-watchlist {
  margin: 20px 0;
}

input {
  padding: 10px;
  width: 300px;
  margin-right: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 16px;
}

button {
  padding: 10px 20px;
  background-color: #42b983;
  color: white;
  border: none;
  cursor: pointer;
  border-radius: 5px;
  font-size: 16px;
}

button:hover {
  background-color: #369e73;
}

.watchlist-list {
  list-style: none;
  padding: 0;
}

.watchlist-list li {
  margin: 10px 0;
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

.watchlist-link:hover {
  background-color: #f0f0f0; 
}


.router-link-active {
  font-weight: bold;
}
</style>
