<template>
    <div class="watchlist-detail">
      <ul>
        <li v-for="movie in movies" :key="movie.title">
          <label>
            <input type="checkbox" v-model="movie.watched" /> {{ movie.title }}
          </label>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  export default {
    props: {
      movies: Array,
    },
  };
  </script>
  