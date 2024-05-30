import { type RouteRecordRaw, createRouter, createWebHistory } from "vue-router";

const routes: RouteRecordRaw[] = [
    {
        path: '/',
        alias: '/main',
        name: 'main',
        component: () => import('@/components/Users.vue')
    },
    {
        path: '/second',
        name: 'second',
        component: () => import("@/components/Second.vue")

    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})


export default router;