<template>
    <div>
        <h1>login</h1>
            <label for="">UserName</label>
            <input type="text" v-model="username">
            <label for="">Password</label>
            <input type="text" v-model="password">
            <button @click="Login">Login</button>
            <br>
            <button @click="add">+1</button>
            <h1>count = {{count}}</h1>
            <br>
            <h1>{{oddOrEven}}</h1>
            <br>
            <input type="text" v-model="name">
            <h1>{{fullname}}</h1>
    </div>
</template>



<script setup>
import {computed, ref, watch} from "vue"
import router from "../router"; 
import axios from "axios"
const count=ref(0);
const name=ref("");
const fullname=ref("");
const add=(()=>{
    count.value++;
})

const Name=watch((name=>{
    if(name.value.empty)
        return ""
    return name.value+" bendhieb"
}))


const oddOrEven=computed(()=>{
    if(count.value%2===0)
        return "pair";
    else    
        return "impair";
})


const username=ref('');
const password=ref('');
 const ok=ref('hkjhjh');
 const user={username:username,password:password};
 






 function Login(){

    
        axios.post("http://localhost:5073/api/User/login",{
    "username": username.value,
    "password": password.value
    }).then(res=>
    {
        ok.value=res.data;  console.log(ok.value);
        if(ok.value==="admin" ||ok.value==="user" ){
                alert("succes");
                router.push({name:"info",params:{id:ok.value}});
                
        }
        else
                alert("wrong password")
            
    }).catch(err=>console.log(err));
 
}

</script>