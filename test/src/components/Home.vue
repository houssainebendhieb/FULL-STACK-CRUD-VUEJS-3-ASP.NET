<template>
    <div>
        <label for="">Name</label>
       <input type="text" v-model="name">
       <label for="">Age</label>
        <input type="text" v-model="age">
        <button @click="submit()">Ajouter</button>
        <br>
        <h1>liste of personnes</h1>
        <table>
            <th>
                <tr>
                    <td>name</td>
                    <td>age</td>
                </tr>
            </th>
            <tbody>
                <tr v-for="item in personnes " key="item.id">

                    <td>{{item.name}}</td>
                    <td>{{item.age}}</td>
                    <td ><button @click="delete(item.id)" >Delete</button></td>
                </tr>


            </tbody>


        </table>


    </div>
  



</template>


<script setup>
import {ref,onMounted} from "vue";
import axios from "axios";
const name=ref("");
const age=ref(0);
const personnes=ref([]);
 function submit(){

    axios.post("http://localhost:5274/api/Personne/adduser",{
    "name": name.value,
    "age": age.value
        }
        ).then(res=>console.log(res)).catch(err=>console.log(err));

 }

function Delete(id){
    axios.delete(""+id).then(()=>personnes.value.splice());
}

onMounted(()=>{
    axios.get("").then((res)=>{
        console.log(personnes);
        personnes.value=res;
        console.log(personnes)
    });
})


</script>