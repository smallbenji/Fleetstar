import Vue from "vue";

import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { faCheck, faPerson, faUser, faUsers, faCheckCircle, faInfoCircle, faExclamationTriangle, faExclamationCircle, faArrowUp, faAngleRight, faAngleLeft, faAngleDown, faEye, faEyeSlash, faCaretDown, faCaretUp, faUpload } from "@fortawesome/free-solid-svg-icons";

library.add(faCheck, faPerson, faUser, faUsers, faCheckCircle, faInfoCircle, faExclamationTriangle, faExclamationCircle,
    faArrowUp, faAngleRight, faAngleLeft, faAngleDown,
    faEye, faEyeSlash, faCaretDown, faCaretUp, faUpload);
Vue.component("vue-fontawesome", FontAwesomeIcon);

import Buefy from "buefy";
import 'buefy/dist/buefy.css'



Vue.use(Buefy, {
    defaultIconComponent: 'vue-fontawesome',
    defaultIconPack: 'fas'
});

import Login from "./components/login.vue";
import Admin from "./views/admin.vue";
Vue.component("login", Login);
Vue.component("admin", Admin);

(window as any).app = new Vue({
    el: '#app'
})