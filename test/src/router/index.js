import { createRouter, createWebHistory } from 'vue-router'
import home from '../components/Home.vue'


const routes = [
  
  {
    path: '/',
    name: 'home',
    component: home
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
