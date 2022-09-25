<template>
    <div app>
        <tr v-for="com in parentComments.entities" :key="com.Id">
            <td></td>
        </tr>
    </div>
</template>

<script>
import {variables} from "../api";

export default {
    data(){
    return {
        parentComments: {
            entities: [],
            paginationMetadata: {
                
            }
        },
    }
  },
  methods: {
    getParentComments() {
      this.axios.get(variables.API_URL + "Comment")
      .then((response)=>{
        this.parentComments=response.data;
      });
    }
  },
  created(){
    this.getParentComments();
  }
}
</script>

<style scoped>
p {
    text-align: justify;
    text-indent: 30px;
    font-family: Serif;
    font-size: 14px;
    }
h1, h2, h3 {
    color: blue; /* тоже самое, что и #0000FF */
}
table, img {border: none;}
li a {text-decoration: none;}
div, th, td {
    padding-left: 10px;
    padding-right: 10px;
    background-color: yellow;
}
a {color: black; font-weight: bold;}
p a, li a {font-weight: normal; text-decoration: none;}
p a:hover, li a:hover {
    color: #00FF00; text-decoration: underline;
    }
    
</style>