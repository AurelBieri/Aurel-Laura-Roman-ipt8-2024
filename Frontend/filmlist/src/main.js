import Vue from 'vue';
import App from './App.vue';
import router from './router'; // Den Router korrekt importieren

Vue.config.productionTip = false;

new Vue({
  router,  // Den Router in der Vue-Instanz registrieren
  render: h => h(App)
}).$mount('#app');
