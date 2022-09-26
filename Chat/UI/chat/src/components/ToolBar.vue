<template>
<div app>
    <v-app-bar 
      color="deep-purple accent-4" 
      dense 
      dark 
      app>
        <div></div>
        <v-toolbar-title>
          Chat
        </v-toolbar-title>      
        <AddNewComment />
        <template>
          <v-spacer></v-spacer>
          <v-select
                  flat
                  solo-inverted
                  hide-details
                  prepend-inner-icon="mdi-magnify"
                  label="Sort by"
                  class="ps-16">
          </v-select>
          <v-btn-toggle  mandatory>
            <v-btn 
              depressed 
              color="deep-purple accent-4" 
              :value="false">
                <v-icon>mdi-arrow-up</v-icon>
            </v-btn>
            <v-btn 
              depressed 
              color="deep-purple accent-4" 
              :value="true">
                <v-icon>mdi-arrow-down</v-icon>
            </v-btn>
          </v-btn-toggle>
        </template>  
    </v-app-bar>
</div>
</template>


<script>
import AddNewComment from "./AddNewComment.vue";
export default {
  components: {
    AddNewComment
  }, 
}
</script>