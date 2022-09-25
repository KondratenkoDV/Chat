<template>
  <v-app>
    <v-app-bar color="deep-purple accent-4" dense dark app>
      <v-toolbar-title>Chat</v-toolbar-title>      
        <AddNewComment />
      <template v-if="$vuetify.breakpoint.mdAndUp">
              <v-spacer></v-spacer>

      <v-spacer></v-spacer>
      <v-select
                v-model="sortBy"
                flat
                solo-inverted
                hide-details
                :items="keys"
                prepend-inner-icon="mdi-magnify"
                label="Sort by"
                class="ps-16"
              ></v-select>
      <v-btn-toggle v-model="sortDesc" mandatory>
        <v-btn depressed color="deep-purple accent-4" :value="false">
          <v-icon>mdi-arrow-up</v-icon>
        </v-btn>
        <v-btn depressed color="deep-purple accent-4" :value="true">
          <v-icon>mdi-arrow-down</v-icon>
        </v-btn>
      </v-btn-toggle>
      </template>  
    </v-app-bar>
    <v-content>
      <v-container>
        {{message}}

        <div>
          {{parentComments}}
        </div>

        
        
      </v-container>
      
    </v-content>

  </v-app>
</template>


<script>
import {variables} from "./api";
import AddNewComment from "./components/AddNewComment.vue";
export default {
  components: {
    AddNewComment
  },
  data(){
    return {
      sortDesc: false,
      sortBy: 'name',
      parentComments: [],
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
  method: function(){
    this.getParentComments();
  },
  created(){
    this.getParentComments();
  }
}
</script>
