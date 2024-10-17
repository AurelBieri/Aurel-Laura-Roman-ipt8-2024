import Vue from 'vue';
import App from './App.vue';
import router from './router'; // Importiere den Router

Vue.config.productionTip = false;

new Vue({
  router, // Binde den Router an die Vue-Instanz
  render: h => h(App), // Rendere die Hauptkomponente
}).$mount('#app');
