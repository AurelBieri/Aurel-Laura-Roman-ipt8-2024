<template>
  <div class="watchlist">
    <h2>{{ watchlist.title }}</h2>
    <WatchlistDetail :movies="watchlist.movies" />
    <AddMovieForm @addMovie="addMovie" />
    <CommentSection :comments="watchlist.comments" />
  </div>
</template>

<script>
import WatchlistDetail from '@/components/WatchlistDetail.vue';
import AddMovieForm from '@/components/AddMovieForm.vue';
import CommentSection from '@/components/CommentSection.vue';

export default {
  name: 'WatchlistPage', 
  components: {
    WatchlistDetail,
    AddMovieForm,
    CommentSection,
  },
  data() {
    return {
      watchlist: {
        title: 'Meine Lieblingsfilme',
        movies: [
          { title: 'Inception', watched: false },
          { title: 'Matrix', watched: true },
        ],
        comments: [
          { user: 'Alice', text: 'Toller Film!' },
          { user: 'Bob', text: 'Habe ihn auch gesehen!' },
        ],
      },
    };
  },
  methods: {
    addMovie(movie) {
      this.watchlist.movies.push(movie);
    },
  },
};
</script>

<style scoped>
/* Füge dein Styling hier hinzu */
</style>
