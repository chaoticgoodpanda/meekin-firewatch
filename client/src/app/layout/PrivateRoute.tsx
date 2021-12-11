import {Redirect, Route, RouteComponentProps, RouteProps} from "react-router-dom";
import {ComponentType, useState} from "react";
import {useStore} from "../stores/store";

interface Props extends RouteProps {
    // covers all of our use cases
    component: ComponentType<RouteComponentProps<any>> | ComponentType<any>
}

export default function PrivateRoute({ component: Component, ...rest }: Props) {
    const {userStore} = useStore();
    const {user} = userStore;
    return (
        <Route
            {...rest}
            render={props =>
                user ? (
                    <Component {...props} />
                ) : (
                    <Redirect
                        to={{
                            pathname: "/login",
                            state: { from: props.location }
                        }}
                    />
                )
            }
        />
    )
}