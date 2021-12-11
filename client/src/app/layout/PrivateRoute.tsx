import {Redirect, Route, RouteComponentProps, RouteProps} from "react-router-dom";
import {ComponentType, useState} from "react";

interface Props extends RouteProps {
    // covers all of our use cases
    component: ComponentType<RouteComponentProps<any>> | ComponentType<any>
}

export default function PrivateRoute({ component: Component, ...rest }: Props) {
    
    return (
        <h1>Hello</h1>
        
        // <Route
        //     {...rest}
        //     render={props =>
        //         fakeAuth.isAuthenticated ? (
        //             <Component {...props} />
        //         ) : (
        //             <Redirect
        //                 to={{
        //                     pathname: "/login",
        //                     state: { from: props.location }
        //                 }}
        //             />
        //         )
        //     }
        // />
    )
}