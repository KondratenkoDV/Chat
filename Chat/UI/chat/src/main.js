import Vue from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import dateFilter from './Helpers/date.filter'
import vuetify from './plugins/vuetify'
import axios from 'axios'
import VueAxios from 'vue-axios'

Vue.use(VueAxios, axios)

Vue.config.productionTip = false

Vue.filter('date', dateFilter)

new Vue({
  router,
  vuetify,
  axios,  
  render: h => h(App)
}).$mount('#app')