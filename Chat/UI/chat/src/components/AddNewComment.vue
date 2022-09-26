<template>
    <v-row justify="center">
        <v-dialog 
            v-model="dialog" 
            persistent 
            max-width="600px">
                <template v-slot:activator="{ on, attrs }">
                    <v-btn icon v-bind="attrs" v-on="on">
                        <v-icon>mdi-pencil</v-icon>
                    </v-btn>
                </template>
            <v-card>
                <v-card-title>
                    <span class="text-h5">Add new comment</span>
                </v-card-title>
                <v-card-text>
                    <v-container>
                        <v-row>
                            <v-col cols="12" sm="6" md="4">
                                <v-text-field 
                                    :rules="userNameRules" 
                                    label="User Name*" 
                                    required>
                                </v-text-field>
                            </v-col>
                            <v-col cols="12">
                                <v-text-field 
                                    :rules="emailRules" 
                                    label="Email*" 
                                    required>
                                </v-text-field>
                            </v-col>

                            <v-col cols="12">
                                <v-textarea 
                                    :rules="textRules" 
                                    label="Your comments*" 
                                    required>
                                </v-textarea>
                            </v-col>

                            <v-col cols="12">
                                <vue-recaptcha 
                                    :rules="[v => !!v || 'You must agree to continue!']" 
                                    :loadRecaptchaScript="true" 
                                    @verify="validate" 
                                    @error="error" 
                                    sitekey="6LfsPCwiAAAAAEbKWQ1CBY7XuKBtyRe8EIN3OBd-">
                                </vue-recaptcha>
                            </v-col>
                        </v-row>
                        </v-container>
                        <small>*indicates required field</small>
                    </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn 
                        color="blue darken-1" 
                        text 
                        @click="dialog = false">
                            Close
                    </v-btn>
                    <v-btn 
                        :disabled="!valid"
                        color="blue darken-1" 
                        text 
                        @click="postComment(),
                        dialog = false">
                            Save
                    </v-btn>
                </v-card-actions>
            </v-card> 
        </v-dialog>
    </v-row>   
</template>

<script>
import { VueRecaptcha } from 'vue-recaptcha';
import {variables} from '../api';
export default {
    components: { VueRecaptcha },
    data() {
        return {
            createComment: {
                UserName: '',
                Email: '',
                Text: '',
                HomePage: this.$route,
                Ip: '',

            },
            dialog: false,
            valid: true,
            userName: '',
            userNameRules: [
                v => !!v || 'Name is required',
                v => (v && v.length >= 2 && v.length <=50) 
                || 'The user name must contain more than 2 and less than 50 characters',
            ],
            email: '',
            emailRules: [
                v => !!v || 'E-mail is required',
                v => /.+@.+\..+/.test(v) 
                || 'E-mail must be valid',
            ],
            text: '',
            textRules: [
                v => !!v || 'Text is required',
                v => (v && v.length >= 2) 
                || 'The text must contain more than 2 characters',
            ],
        }
    },
    methods: {
        postComment() {
            this.yourIp();
            
            this.axios.post(variables.API_URL + "Comment",{
                CreateComment: this.createComment
            })
            .then((response) => {
                this.getParentComments()
                alert(response.data);
            });
        },
        yourIp(){
            fetch('https://api.ipify.org?format=json')
            .then(x => x.json())
            .then(({ ip }) => {
                this.Ip = ip;
            });
        },
        validate() {
            console.log('Verified')
        },
        error() {
            console.log('Error')
        },
    }
}
</script>