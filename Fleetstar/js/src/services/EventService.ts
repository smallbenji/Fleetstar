import { Arrangement } from "@/types/EventTypings";
import axios, { AxiosResponse } from "axios";

export default class EventService {
    public async getEvents(): Promise<Arrangement[]> {
        try {
            const response: AxiosResponse<Arrangement[]> = await axios({
                url: "/api/events",
                method: "GET"
            });

            return response.data;
        } catch {
            return null;
        }
    }

    public async createEvent(event: Arrangement): Promise<void> {
        await axios.post("/api/events", event);
    }
}