import axios, { AxiosResponse } from "axios";

export default class UserService {
    public async getAll(): Promise<User[]> {
        try {
            const response: AxiosResponse<User[]> = await axios({
                url: "/auth/getall",
                method: "GET"
            });

            return response.data;
        } catch {
            return null;
        }
    }
}