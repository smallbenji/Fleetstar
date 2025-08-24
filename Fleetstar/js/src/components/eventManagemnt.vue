<template>
    <div class="event-management">
        <form @submit.prevent="createEvent" class="create-event-form">
            <input v-model="newEvent.name" placeholder="Name" required />
            <input v-model="newEvent.description" placeholder="Description" required />
            <input v-model="newEvent.fromDate" type="date" required />
            <input v-model="newEvent.toDate" type="date" required />
            <button type="submit">Create Event</button>
        </form>
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Description</th>
                    <th>From Date</th>
                    <th>To Date</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="data in events" :key="data.id">
                    <td>{{ data.id }}</td>
                    <td>{{ data.name }}</td>
                    <td>{{ data.description }}</td>
                    <td>{{ data.fromDate }}</td>
                    <td>{{ data.toDate }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<script lang="ts">
import { EventsModule } from "@/store/Modules/EventModule";
import { Arrangement } from "@/types/EventTypings";
import { Component, Vue } from "vue-property-decorator";

@Component({
    name: "EventManagement"
})
export default class EventManagement extends Vue {
    newEvent: Arrangement = {
        name: "",
        description: "",
        fromDate: null,
        toDate: null,
        id: null,
        image: "",
        forWho: "",
        extrafields: []
    };

    get events() {
        return EventsModule.EVENTS ?? [];
    }

    async created() {
        await EventsModule.GET_EVENTS();
    }

    async createEvent() {
        await EventsModule.CREATE_EVENT(this.newEvent);
        await EventsModule.GET_EVENTS();
        this.newEvent = { name: "", description: "", fromDate: null, toDate: null, id: "", image: "", forWho: "", extrafields: [] };
    }
}
</script>
<style lang="scss">
.event-management {
    display: flex;
    flex-direction: column;
    margin:auto;

    .create-event-form {
        margin-bottom: 20px;
        display: flex;
        gap: 10px;
    }

    table {
        width: 100%;
    }
}
</style>