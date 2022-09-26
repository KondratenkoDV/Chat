<template>
    <div app>
      <div 
        v-for="com in parentComments.entities" 
        :key="com.Id">
          <thead>
            <tr>              
              <th>
                <v-avatar color="indigo">
                  <v-icon dark>
                    mdi-account-circle
                  </v-icon>
                </v-avatar>
              </th>
              <th>
                {{com.selectedUserName}}
              </th>
              <th>
                {{com.selectedDateAdded | date('date')}} at {{com.selectedDateAdded | date('time')}}
              </th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>{{com.selectedText}}</td>
            </tr>
          </tbody>
      </div>
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
table, img {border: none;}
thead, th {
    padding-left: 50px;
    padding-right: 50px;
    background-color: #BBDEFB;
    flex-basis: 25%;
}
</style>