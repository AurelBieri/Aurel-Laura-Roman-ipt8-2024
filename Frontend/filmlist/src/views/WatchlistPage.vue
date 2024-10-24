<template>
  <div class="watchlist-page">
    <!-- Normale Ansicht der Watchlist, wenn sie gefunden wurde -->
    <div v-if="watchlist">
      <h1>{{ watchlist.title }}</h1>

      <!-- Liste der Filme anzeigen -->
      <ul>
        <li v-for="(movie, index) in watchlist.movies" :key="index">
          {{ movie }}
          <button @click="removeMovie(index)">Löschen</button>
        </li>
      </ul>

      <!-- Formular zum Hinzufügen eines neuen Films -->
      <div class="add-movie">
        <input v-model="newMovieTitle" placeholder="Neuen Film hinzufügen" />
        <button @click="addMovie">Hinzufügen</button>
      </div>
    </div>

    <!-- Zeige eine Meldung, falls die Watchlist nicht gefunden wurde -->
    <div v-else>
      <p>Watchlist wird geladen oder existiert nicht.</p>
    </div>
  </div>
</template>

<script>
export default {
  props: ['id'], // Die ID der Watchlist wird als Prop übergeben
  data() {
    return {
      watchlist: null, // Die aktuelle Watchlist
      newMovieTitle: '', // Eingabefeld für neuen Film
    };
  },
  mounted() {
    // Debugging: Ausgabe der ID
    console.log('Übergebene ID:', this.id);

    // Beispiel-Watchlists
    const watchlists = [
      { id: 1, title: 'Top Filme', movies: ['Inception', 'Interstellar'] },
      { id: 2, title: 'Action Filme', movies: ['Die Hard', 'Mad Max'] },
      { id: 3, title: 'Romantische Filme', movies: ['Titanic', 'The Notebook'] },
    ];

    // Finde die aktuelle Watchlist basierend auf der ID
    this.watchlist = watchlists.find((wl) => wl.id == this.id);

    if (this.watchlist) {
      console.log('Gefundene Watchlist:', this.watchlist);
    } else {
      console.error(`Watchlist mit ID ${this.id} wurde nicht gefunden.`);
    }
  },
  methods: {
    // Methode zum Hinzufügen eines neuen Films
    addMovie() {
      if (this.newMovieTitle) {
        this.watchlist.movies.push(this.newMovieTitle);
        this.newMovieTitle = '';
      }
    },

    // Methode zum Löschen eines Films
    removeMovie(index) {
      this.watchlist.movies.splice(index, 1);
    },
  },
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

  margin: 10px 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

button {
  background-color: red;
  color: white;
  border: none;
  padding: 5px 10px;
  border-radius: 5px;
  cursor: pointer;
}

button:hover {
  background-color: darkred;
}

a {
  text-decoration: none;
  color: #42b983;
}

a:hover {
  text-decoration: underline;

input {
  padding: 10px;
  width: 300px;
  margin-right: 10px;
}

button {
  padding: 10px;
  background-color: #42b983;
  color: white;
  border: none;
  cursor: pointer;
  border-radius: 5px;

}

button:hover {
  background-color: #369e73;
}
</style>
