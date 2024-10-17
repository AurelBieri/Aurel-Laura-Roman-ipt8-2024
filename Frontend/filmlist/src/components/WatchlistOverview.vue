<template>
    <div class="watchlist-overview">
      <ul>
        <li v-for="list in watchlists" :key="list.id">
          <router-link :to="'/watchlist/' + list.id">{{ list.title }}</router-link>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  export default {
    props: {
      watchlists: Array,
    },
  };
  </script>
  