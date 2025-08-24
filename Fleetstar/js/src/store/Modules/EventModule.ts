import { Action, Mutation, getModule, Module, VuexModule } from "vuex-module-decorators";
import store from "..";
import UserService from "@/services/UserService";
import EventService from "@/services/EventService";
import { Arrangement } from "@/types/EventTypings";

@Module({
    store,
    dynamic: true,
    name: "EventsModule",
    namespaced: true,
})
class EventsClass extends VuexModule {
    private eventService = new EventService();

    private Events: Arrangement[] = null;

    get EVENTS(): Arrangement[] {
        return this.Events;
    }

    @Action({ commit: "SET_EVENTS"})
    public async GET_EVENTS() {
        return await this.eventService.getEvents();
    }

    @Mutation
    private SET_EVENTS(payload: Arrangement[]) {
        this.Events = payload;
    }

    @Action
    public async CREATE_EVENT(event: Arrangement) {
        await this.eventService.createEvent(event);
    }
}

export const EventsModule = getModule(EventsClass);