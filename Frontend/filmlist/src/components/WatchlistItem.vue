<template>
    <li class="watchlist-item">
      <div>
        <input type="checkbox" v-model="isWatched" @change="toggleWatched">
        <span :class="{ watched: isWatched }">{{ movie.title }}</span>
      </div>
      <button @click="$emit('remove', movie)">Löschen</button>
    </li>
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
  
  .watchlist-item {
    display: flex;
    justify-content: space-between;
    margin-bottom: 10px;
  }
  </style>
  