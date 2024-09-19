<template>
    <div class="watchlist-item">
      <input type="checkbox" v-model="isWatched" @change="toggleWatched">
      <span :class="{ watched: isWatched }">{{ movie.title }}</span>
      <button @click="$emit('remove', movie)">Löschen</button>
    </div>
  </template>
  
  <script>
  export default {
    props: {
      movie: Object
    },
    data() {
      return {
        isWatched: this.movie.watched
      };
    },
    methods: {
      toggleWatched() {
        this.$emit('toggle-watched', this.movie);
      }
    }
  };
  </script>
  
  <style scoped>
  .watched {
    text-decoration: line-through;
    color: gray;
  }
  </style>
  