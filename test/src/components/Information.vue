<template>
    <div>        
            <div v-if="$route.params.id=='admin'">
                 <h1>liste of reclamations</h1>
            <table>
                <tbody>
                    <tr v-for="item of reclamtions " :key="item.date">
                            <td>{{item.name}}</td>
                            <td>{{item.content}}</td>
                            <td>{{item.username}}</td>
                            
                            <td><button @click="supprimerRec(item)">Delete</button></td>
                    </tr>
                </tbody>
            </table> 

            <h2>liste of users</h2>
        
            <table> 
                <th>
                    <tr>
                        <td>username:</td>
                        <td>isAdmin??</td>
                        <td>id</td>
                    </tr>
                </th>
                <tbody>
                    <tr v-for="item of users " :key="item.date">
                            <td>{{item.username}}</td>
                            <td>{{item.isAdmin}}</td>
                            <td>{{item.id}}</td>
                            <td><button @click="supprimer(item)">Delete</button></td>
                    </tr>
                </tbody>
            </table>

        </div>


        <div v-if="$route.params.id=='user'">

            <h2>liste of your recalmation</h2>
            <table>
                
                <tbody>
                    <tr v-for="item of reclamtionsUser " :key="item.date">
                            <td>{{item.name}}</td>
                            <td>{{item.date}}</td>
                            <td>{{item.id}}</td>
                            <td><button @click="supprimer(item)">Delete</button></td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td><input type="text" id="name" placeholder="donner nouveau reclamations" v-model="name"></td>
                        <td><input type="text" id="date" placeholder="donner nouveau reclamations" v-model="date"></td>
                        <td><button @click="ajouter()">Add</button></td>
                    </tr>


                </tfoot>


            </table>

        </div>
    </div>
</template>


<script setup>
import { onMounted, ref} from "vue";
import axios from "axios";

const name=ref("")
const date=ref("")
const reclamtions=ref([]);
const users=ref([])
const reclamtionsUser=ref([]);

onMounted(()=>{
    axios.get("http://localhost:5073/api/User/get").then(res=>{users.value=res.data});
    axios.get("http://localhost:5073/api/Reclamtion/getAll").then(res=>{reclamtions.value=res.data});
    axios.get("http://localhost:5073/api/Reclamtion/").then(res=>{reclamtions.value=res.data});

})


function ajouter(){
 
    var id=reclamtionsUser.length;
    reclamtionsUser.push({name:name.value,id:id+1,date:date.value})
    console.log(users);

}

function supprimerRec(item){
    console.log(item.name);
    axios.delete("http://localhost:5073/api/Reclamtion/delete/"+item.name)
    var index=reclamtions.value.findIndex(c=>c.name==item.name);
    reclamtions.value.splice(index,1);
}


function supprimer(item){
    console.log(item);
    axios.delete("http://localhost:5073/api/User/get/"+item.name);
    var index=reclamtionsUser.value.findIndex(c=>c.id==item.id);
    reclamtionsUser.value.splice(index,1);

}
</script>