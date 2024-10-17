<template>
    <div class="create-watchlist">
      <input type="text" v-model="newWatchlistTitle" placeholder="Watchlist Titel" />
      <button @click="createWatchlist">Erstellen</button>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        newWatchlistTitle: '',
      };
    },
    methods: {
      createWatchlist() {
        if (this.newWatchlistTitle) {
          this.$emit('create', { title: this.newWatchlistTitle, movies: [] });
          this.newWatchlistTitle = '';
        }
      },
    },
  };
  </script>
  