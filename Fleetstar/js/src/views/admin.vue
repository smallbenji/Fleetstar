<template>
    <div class="admin-panel">
        <div class="sidebar">
                <b-menu-list>
                    <b-menu-item
                    v-for="item in items"
                    :key="item.id"
                    :label="item.Title"
                    :active="selected === item.id"
                    @click="selectItem(item.id)"
                    icon="users"
                    >
                    
                </b-menu-item>
            </b-menu-list>
        </div>
        <div class="content-frame">
            <UsersManagement v-if="selected === 'users'"></UsersManagement>
            <EventManagement v-if="selected === 'event'"></EventManagement>
        </div>
    </div>
</template>
<script lang="ts">
import EventManagement from "@/components/eventManagemnt.vue";
import UsersManagement from "@/components/usersManagement.vue";
import { Component, Vue } from "vue-property-decorator";

@Component({
    name: "AdminPanel",
    components: {
        UsersManagement,
        EventManagement
    }
})
export default class AdminPanel extends Vue {
    private selected = "";

    selectItem(str: string) {
        this.selected = str;
    }

    private items = [
        {
            Title: "Users",
            id: "users"
        },
        {
            Title: "Events",
            id: "event"
        }
    ]
}
</script>
<style lang="scss">
.admin-panel {
    display: flex;
    min-height: 100%;
}

.sidebar {
    min-height: 100%;
    background-color: #fafafa;
    width: 8rem;
    border: 1px solid hsla(0, 0%, 4%, 0.1);
    // box-shadow: 1px 0px 0 hsla(0, 0%, 4%, .1), inset 1px 0px 0 hsla(0, 0%, 4%, .1);
}

.content-frame {
    flex: 1;
}
</style>