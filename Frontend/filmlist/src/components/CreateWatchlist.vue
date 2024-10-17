<template>
  <div class="create-watchlist">
    <input
      type="text"
      v-model="newWatchlistTitle"
      placeholder="Watchlist Titel eingeben"
    />
    <button @click="createWatchlist">Watchlist erstellen</button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newWatchlistTitle: '', // Titel der neuen Watchlist
    };
  },
  methods: {
    // Methode zum Erstellen einer neuen Watchlist
    createWatchlist() {
      if (this.newWatchlistTitle) {
        const newWatchlist = {
          id: Date.now(), // Eindeutige ID für die Watchlist
          title: this.newWatchlistTitle, // Titel der Watchlist
          movies: [], // Leere Liste für Filme
        };
        // Event an die übergeordnete Komponente senden
        this.$emit('create', newWatchlist);
        this.newWatchlistTitle = ''; // Eingabefeld leeren
      }
    },
  },
};
</script>

<style scoped>
.create-watchlist {
  margin-top: 20px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.create-watchlist input {
  padding: 10px;
  width: 300px;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  margin-right: 10px;
  font-size: 16px;
}

.create-watchlist input:focus {
  outline: none;
  border-color: #42b983;
}

.create-watchlist button {
  padding: 10px 15px;
  background-color: #42b983;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 16px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
  transition: background-color 0.3s ease;
}

.create-watchlist button:hover {
  background-color: #369e73;
}
</style>
