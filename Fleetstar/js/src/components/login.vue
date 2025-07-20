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

<script lang="ts" setup>
    import Axios from "axios";

    var username = "";
    var password = "";

    const urlParams = new URLSearchParams(window.location.search);

    async function login() {
        const res = await Axios({
            method: "POST",
            url: "/Auth/login",
            data: {
                username: username,
                password: password
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