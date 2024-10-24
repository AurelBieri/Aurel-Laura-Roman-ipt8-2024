<template>
    <div class="add-movie">
      <input v-model="newMovieTitle" placeholder="Neuen Film hinzufügen" />
      <button @click="addMovie">Hinzufügen</button>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        newMovieTitle: '',
      };
    },
    methods: {
      addMovie() {
        if (this.newMovieTitle) {
          this.$emit('addMovie', { title: this.newMovieTitle, watched: false });
          this.newMovieTitle = '';
        }
      },
    },
  };
  </script>
  