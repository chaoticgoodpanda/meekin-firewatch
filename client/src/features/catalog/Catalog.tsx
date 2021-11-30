
import PostList from "./PostList";
import {useEffect} from "react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import {useStore} from "../../app/stores/store";
import {observer} from "mobx-react-lite";



export default observer(function Catalog() {
    const {reportStore} = useStore();
    const {loadPosts, postRegistry} = reportStore;

    // can add a side effect to component OnInit, i.e. when it loads, is destroyed, etc.
    useEffect( () => {
        if (postRegistry.size <= 1) loadPosts();
    }, [postRegistry.size, loadPosts]);
    
    
    
    
    if (reportStore.loadingInitial) return <LoadingComponent message='Loading posts...' />;
    return (
        <>
            <PostList
            />
        </>

)
})