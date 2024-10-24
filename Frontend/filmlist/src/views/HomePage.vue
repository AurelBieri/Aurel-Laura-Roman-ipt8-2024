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
       <!-- Liste der Watchlists anzeigen -->
        <div class="watchlist-section">
      <div class="grid">
        <div class="column" v-for="watchlist in watchlists" :key="watchlist.id">
          <ul class="watchlist-list">
                  <!-- Verlinke zu den Watchlist-Details -->
            <li>
              <router-link 
              :to="{ name: 'Watchlist', params: { id: watchlist.id }}"
              class="watchlist-link"
              exact
              >
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
  </div>
</template>

<script>
export default {
  data() {
    return {
      // Beispiel-Watchlists
      watchlists: [
        { id: 1, title: 'Top Filme', movies: ['Inception', 'Interstellar'] },
        { id: 2, title: 'Action Filme', movies: ['Die Hard', 'Mad Max'] },
        { id: 3, title: 'Romantische Filme', movies: ['Titanic', 'The Notebook'] },
      ],
      newWatchlistTitle: '', // Eingabefeld für die neue Watchlist
    };
  },
  methods: {
    // Methode zum Erstellen einer neuen Watchlist
    createWatchlist() {
      if (this.newWatchlistTitle.trim()) {
        // Erstelle eine neue Watchlist mit einer eindeutigen ID und leeren Filmen
        const newWatchlist = {
          id: Date.now(), // Verwende die aktuelle Zeit als eindeutige ID
          title: this.newWatchlistTitle.trim(),
          movies: [], // Leere Liste für neue Watchlists
        };

        // Füge die neue Watchlist zur Liste hinzu
        this.watchlists.push(newWatchlist);

        // Setze das Eingabefeld zurück
        this.newWatchlistTitle = '';
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
  grid-template-columns: repeat(4, 1fr); /* 4 columns per row */
  gap: 20px;
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
  text-decoration: none;
  color: #333;
}

.watchlist-link:hover {
  text-decoration: underline;
}

/* Aktiver Link wird fett */
.router-link-active {
  font-weight: bold;
}
</style>
