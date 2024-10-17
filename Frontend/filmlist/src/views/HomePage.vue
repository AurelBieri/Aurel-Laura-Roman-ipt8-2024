<template>
    <div class="homepage">
      <h1>Willkommen zur Watchlist App</h1>
      <LoginRegister />
      <div class="watchlist-section">
        <h2>Öffentliche Watchlisten</h2>
        <WatchlistOverview :watchlists="publicWatchlists" />
      </div>
      <CreateWatchlist @create="addNewWatchlist" />
    </div>
  </template>
  
  <script>
  import LoginRegister from '@/components/LoginRegister.vue';
  import WatchlistOverview from '@/components/WatchlistOverview.vue';
  import CreateWatchlist from '@/components/CreateWatchlist.vue';
  
  export default {
    name: 'HomePage',
    components: {
      LoginRegister,
      WatchlistOverview,
      CreateWatchlist,
    },
    data() {
      return {
        publicWatchlists: [
          { id: 1, title: 'Top Filme 2023', movies: [] },
          { id: 2, title: 'Meine Lieblingsserien', movies: [] },
        ],
      };
    },
    methods: {
      addNewWatchlist(newWatchlist) {
        this.publicWatchlists.push(newWatchlist);
      },
    },
  };
  </script>
  
  <style scoped>
  /* Füge dein Styling hier hinzu */
  </style>
  