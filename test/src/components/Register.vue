<template>
    <div>
        <h1>Register</h1>
    
            <label for="">UserName</label>
            <input type="text" v-model="username">
           
            <label for="">Password</label>
            <input type="text" v-model="password">
            <button @click="Register">Login</button>




    </div>
</template>



<script setup>
import {ref} from "vue"
import router from "../router"; 
import axios from "axios";
const username=ref('');
const password=ref('');
const user={"username":username.value,"password":password.value};
const ok=ref('');

function Register(){

    axios.post("http://localhost:5073/api/User/register",{
    
        "username": username.value,
        "password": password.value
    }).then(res=>
    {
        ok.value=res.data;
        if(ok.value=="succes")
        {
            alert("succes");
            router.push({name:"login"});
        }
        else{
            alert(ok.value);
        }
    
    }).catch(error=>console.log(error));

}

</script>