import { createApp } from 'vue';
import App from './App.vue';
import router from './router'; // Router importieren

const app = createApp(App);
app.use(router); // Router benutzen
app.mount('#app'); // Die App mounten
