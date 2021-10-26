import {Expected} from "./expected";
import {Actual} from "./actual";

export interface Statistics {
    id: number;
    actual?: Actual;
    expected?: Expected;
}