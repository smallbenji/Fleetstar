<template>
    <div class="users-management">
        <b-table :data="users" :narrowed="true" :striped="true" class="table">
            <b-table-column
                field="id"
                label="ID"
                v-slot="props"    
            >
                {{ props.row.id }}
            </b-table-column>
            <b-table-column
                field="userName"
                label="Username"
                v-slot="props"    
            >
                {{ props.row.userName }}
            </b-table-column>
            <b-table-column
                field="fullName"
                label="Full Name"
                v-slot="props"    
            >
                {{ props.row.fullName }}
            </b-table-column>
        </b-table>
    </div>
</template>
<script lang="ts">
import { UsersModule } from "@/store/Modules/UsersModule";
import { Component, Vue } from "vue-property-decorator";

@Component({
    name: "UsersManagement"
})
export default class UsersManagement extends Vue {
    
    get users() {
        return UsersModule.USERS ?? [];
    }

    async created() {
        await UsersModule.GET_USERS();

        console.log(this.users);
    }
}
</script>
<style lang="scss">
.users-management {
    display: flex;
    margin:auto;

    .table {
        width: 100%;
    }
}
</style>