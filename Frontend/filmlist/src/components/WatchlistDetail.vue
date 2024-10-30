<template>
  <div>
    <h1>{{ watchlist.name }}</h1>
    <ul>
      <li v-for="movie in watchlist.movies" :key="movie.id">{{ movie.title }}</li>
    </ul>
  </div>
</template>

<script>
import { getWatchlistById } from '@/api/request'; // Assuming you have this API function

export default {
  data() {
    return {
      watchlist: {},
    };
  },
  async mounted() {
    const id = this.$route.params.id;
    await this.fetchWatchlist(id);
  },
  methods: {
    async fetchWatchlist(id) {
      try {
        const response = await getWatchlistById(id);
        this.watchlist = response; // Adjust based on the API response structure
        console.log(response);
      } catch (error) {
        console.error("Error fetching watchlist:", error);
      }
    },
  },
};
</script>
