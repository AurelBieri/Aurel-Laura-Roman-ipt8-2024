import { createApp } from 'vue'; // Vue 3 verwendet createApp
import App from './App.vue';
import router from './router'; // Importiere den Router

// Erstelle die App
const app = createApp(App);

// Verwende den Router
app.use(router);

// Montiere die App in das HTML-Element mit der ID "app"
app.mount('#app');
