<template>
    <div class="login-card">
        <div class="card">
            <div class="card-content">
                <section>
                    <h2 class="title is-2 is-centered">Log in</h2>
                    <b-field label="Username">
                        <b-input v-model="username" max-length="30"></b-input>
                    </b-field>
                    <b-field label="Password">
                        <b-input v-model="password" type="password"></b-input>
                    </b-field>
                    <b-button @click="login" type="is-success">Log in</b-button>
                </section>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from "vue-property-decorator";
    import Axios from "axios";

    @Component({
        name: "Login"
    })
    export default class Login extends Vue {
        private username: string = "";
        private password: string = "";

        async login() {
            const urlParams = new URLSearchParams(window.location.search);
            const res = await Axios({
                method: "POST",
                url: "/Auth/login",
                data: {
                    username: this.username,
                    password: this.password
                }
            });

            if (res.status = 200) {
                if (urlParams.get('ReturnUrl'))
                {
                    window.location.search = urlParams.get("RetunUrl") ?? ""
                }
                else {
                    window.location.search = "/"
                }
            }
        }
    }

</script>

<style lang="scss">
.login-card {
    max-width: 480px;
    min-width: 480px;

    h2 {
        text-align: center;
    }
}
</style>