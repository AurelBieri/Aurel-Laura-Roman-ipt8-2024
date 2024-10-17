<template>
    <div class="comment-section">
      <h3>Kommentare</h3>
      <ul>
        <li v-for="comment in comments" :key="comment.user">{{ comment.user }}: {{ comment.text }}</li>
      </ul>
      <input v-model="newComment" placeholder="Kommentar schreiben" />
      <button @click="addComment">Kommentieren</button>
    </div>
  </template>
  
  <script>
  export default {
    props: {
      comments: Array,
    },
    data() {
      return {
        newComment: '',
      };
    },
    methods: {
      addComment() {
        if (this.newComment) {
          this.$emit('addComment', { user: 'CurrentUser', text: this.newComment });
          this.newComment = '';
        }
      },
    },
  };
  </script>
  