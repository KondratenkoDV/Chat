<template>
  <v-app>
    <AppToolBar/>
    <v-content>
      <v-container>
        <div>
          <CommentView/>
        </div>        
      </v-container>
      
    </v-content>

  </v-app>
</template>


<script>
import CommentView from "./components/CommentView.vue";
import AppToolBar from "./components/ToolBar.vue";
export default {
  components: {
    CommentView,
    AppToolBar
  },  
}
</script>