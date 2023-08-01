import { createRouter, createWebHistory } from 'vue-router'
import Login from '../components/Login.vue'
import home from '../components/Home.vue'
import register from '../components/Register.vue'
import NotFound from '../components/NotFound.vue'
import information from '../components/Information.vue'

const routes = [
  {
    path: '/login',
    name: 'login',
    component: Login
  }
  ,
  { 
    path: '/:NotFound(.*)*',
    component:NotFound ,
  },
  {
    path: '/register',
    name: 'register',
    component: register
  },
  {
    path: '/information/:id',
    name: 'info',
    component: information
  }
  ,
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
