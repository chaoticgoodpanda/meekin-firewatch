import React from 'react';
import {useDispatch, useSelector} from "react-redux";
import {decrement, increment} from "./testReducer";
import {Button} from "@mui/material";

export default function Sandbox() {
    const dispatch = useDispatch();
    // @ts-ignore
    const data = useSelector(state => state.data);
    
    return (
        <>
            <h1>Testing 123</h1>
            <h3>The data is: {data} </h3>
            <Button onClick={() => dispatch(increment(20))} color='success'>Increment</Button>
            <Button onClick={() => dispatch(decrement(10))} color='secondary'>Decrement</Button>
        </>
    )
}