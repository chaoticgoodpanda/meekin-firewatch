import {ExpandedLink} from "./expandedLink";
import {Medium} from "./medium";
import {Statistics} from "./statistics";
import {Account} from "./account";

export interface Post {
    primaryId: number;
    platformId: string;
    platform: string;
    date: string;
    updated: string;
    type: string;
    title: string;
    caption: string;
    description: string;
    message: string;
    expandedLinks?: ExpandedLink[];
    link: string;
    postUrl: string;
    subscriberCount: number;
    score: number;
    media?: Medium[];
    statistics: Statistics;
    account: Account;
    languageCode: string;
    legacyId?: number;
    id: string;
    videoLengthMS?: number;
}