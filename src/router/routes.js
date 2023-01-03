
const routes = [
  {
    path: '/',
    component: () => import('layouts/BlankLayout.vue'),
    children: [
      { path: '', component: () => import('pages/AuthForm.vue') }
    ]
  },
  {
    path: '/store/',
    component: () => import('layouts/Layout.vue'),
    children: [
      { path: 'home', component: () => import('pages/HomePage.vue') },
      { path: 'hello', component: () => import('pages/HelloWorld.vue') },
      { path: 'products', component: () => import('pages/ProductsPage.vue') },
      { path: 'control', component: () => import('pages/AdminProdPanel.vue') }
    ]
  },
  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
