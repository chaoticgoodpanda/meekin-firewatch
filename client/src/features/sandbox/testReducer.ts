export const INCREMENT_COUNTER = 'INCREMENT_COUNTER';
export const DECREMENT_COUNTER = 'DECREMENT_COUNTER';

export function increment(amount: number) {
    return {
        type: INCREMENT_COUNTER,
        payload: amount
    }
}

export function decrement(amount: number) {
    return {
        type: DECREMENT_COUNTER,
        payload: amount
    }
}

const initialState = {
    data: 42
}

export default function testReducer(state = initialState, action: { type: any; payload: number; }) {
    switch (action.type) {
        case INCREMENT_COUNTER:
            return {
                ...state,
                data: state.data + action.payload
            };
        case DECREMENT_COUNTER:
            return {
                ...state,
                data: state.data - action.payload
            };
        default:
            return state;
    }
} 