<template>
  <div
    class="bg-gray-300 border-gray-500 shadow-gray-500 shadow-lg w-full grid grid-cols-2"
  >
    <div class="col-span-2 md:col-span-1">
      <div class="flex justify-end">
        <a
          class="bg-green-500 text-gray-50 font-bold mr-5 p-3 rounded-lg cursor-pointer"
          @click="newUser"
          >Nuevo</a
        >
      </div>
      <table>
        <tr>
          <th>Name</th>
          <th>Username</th>
          <th>Email</th>
          <th>Website</th>
          <th>Actions</th>
        </tr>
        <tr
          v-for="user in users"
          :key="user.id"
          class="text-gray-900 pb-4 px-2"
        >
          <td class="p-2">{{ user.name }}</td>
          <td class="p-2">{{ user.username }}</td>
          <td class="p-2">{{ user.email }}</td>
          <td class="p-2">{{ user.website }}</td>
          <td class="p-2">
            <div class="flex">
              <a
                class="bg-blue-500 text-gray-50 font-bold mr-5 p-3 rounded-lg cursor-pointer"
                @click="setUser(user)"
                >Editar</a
              >
              <a
                class="bg-red-600 text-gray-50 font-bold p-3 rounded-lg cursor-pointer"
                @click="deleteUser(user.id)"
                >Eliminar</a
              >
            </div>
          </td>
        </tr>
      </table>
      <tr></tr>
    </div>
    <div class="col-span-2 md:col-span-1">
      <div class="h-screen flex flex-col justify-center">
        <div class="w-3/4 mx-auto">
          <h3 class="text-xl font-bold mb-4">Agregar usuario</h3>
        </div>
        <form class="w-3/4 flex flex-col gap-4 mx-auto">
          <div class="flex flex-col">
            <label class="block">Name</label>
            <input type="text" v-model="user.name" />
          </div>
          <div class="flex flex-col">
            <label class="block">Username</label>
            <input type="text" v-model="user.username" />
          </div>
          <div class="flex flex-col">
            <label class="block">Email</label>
            <input type="text" v-model="user.email" />
          </div>
          <div class="flex flex-col">
            <label class="block">Phone</label>
            <input type="text" v-model="user.phone" />
          </div>
          <div class="flex flex-col">
            <label class="block">Website</label>
            <input type="text" v-model="user.website" />
          </div>
          <div class="mt-3">
            <a
              v-show="!isEditing"
              class="bg-blue-500 text-gray-50 font-bold mr-5 p-3 rounded-lg cursor-pointer"
              @click="save()"
              >Agregar</a
            >
            <a
              v-show="isEditing"
              class="bg-blue-500 text-gray-50 font-bold mr-5 p-3 rounded-lg cursor-pointer"
              @click="updateUser()"
              >Modificar</a
            >
          </div>
        </form>
      </div>
    </div>
  </div>
</template>


<script lang="ts">
import { defineComponent, onMounted, ref } from "vue";
import axios from "axios";
import type UserInterface from "@/services/UserInterface";

export default defineComponent({
  name: "Main",
  setup() {
    const isEditing = ref(false);
    const users = ref<UserInterface[]>([]);
    const api = ref<string>("https://localhost:7088/User");
    const user = ref<UserInterface>({
      username: "",
      email: "",
      id: 0,
      phone: "",
      website: "",
      name: "",
    });

    const setUser = (userSelected: UserInterface) => {
      user.value = userSelected;
      isEditing.value = true;
    };

    const save = async () => {
      const response = await axios.post(`${api.value}/user`, user.value);
      const data = await response.data;
      console.log(data);

      user.value = {
        username: "",
        email: "",
        id: 0,
        phone: "",
        website: "",
        name: "",
      };
    };

    const deleteUser = async (id: number) => {
      const response = await axios.delete(`${api.value}/user/${id}`);
      const data = await response.data;
      console.log(data);
    };

    const updateUser = async () => {
      const response = await axios.put(`${api.value}/user/${user.value.id}`);
      const data = await response.data;
      console.log(data);
    };

    const getUsers = async () => {
      const response = await axios.get(`${api.value}/users`);
      const data = await response.data;
      users.value = data;
    };

    const newUser = () => {
      isEditing.value = false;
      user.value = {
        username: "",
        email: "",
        id: 0,
        phone: "",
        website: "",
        name: "",
      };
    };

    const init = async () => {
      await getUsers();
      const response = await axios.get(
        "https://jsonplaceholder.typicode.com/users"
      );
      const data = await response.data;
      data.forEach((x: UserInterface) => {
        users.value.push(x);
      });
    };

    onMounted(async () => {
      await init();
    });

    return {
      users,
      user,
      setUser,
      save,
      deleteUser,
      newUser,
      isEditing,
      updateUser,
    };
  },
});
</script>