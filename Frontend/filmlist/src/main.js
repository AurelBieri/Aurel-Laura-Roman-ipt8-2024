import { createApp } from 'vue'; // Vue 3 verwendet createApp
import App from './App.vue'; // Importiere die Haupt-App-Komponente
import router from './router'; // Importiere den Router

const app = createApp(App); // Erstelle eine neue Vue-App

app.use(router); // Verwende den Router in der App
app.mount('#app'); // Montiere die App im HTML-Element mit der ID 'app'
