export interface User {
    email: string;
    username: string;
    displayName: string;
    token: string;
    image?: string;
    organization: string;
}

export interface UserFormValues {
    email: string;
    password: string;
    displayName?: string;
    username?: string;
}