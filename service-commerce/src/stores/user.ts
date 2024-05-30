import { ref } from "vue";
import { defineStore } from "pinia";

export const useUserStore = defineStore('user', () => {
    const user = ref<string[]>([])
    const setUser = (value: string) => {
        user.value.push(value)
    }

    return { user, setUser }
})