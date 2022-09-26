export default (await import('vue')).defineComponent({
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
v => (v && v.length >= 2 && v.length <= 50)
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
};
},
methods: {
postComment() {
this.axios.post(variables.API_URL + "Comment", {
CreateComment: this.createComment
})
.then((response) => {
this.yourIp();
alert(response.data);
});
},
yourIp() {
fetch('https://api.ipify.org?format=json')
.then(x => x.json())
.then(({ ip }) => {
this.Ip = ip;
});
},
validate() {
console.log('Verified');
},
error() {
console.log('Error');
},
}
});
function __VLS_template() {
// @ts-ignore
[dialog, userNameRules, emailRules, textRules, validate, error, valid, postComment];
return {};
}
