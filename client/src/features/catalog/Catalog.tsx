import {Post} from "../../app/models/post";
import PostList from "./PostList";
import {useEffect, useState} from "react";
import {Medium} from "../../app/models/medium";
import axios from "axios";

// interface Props {
//     posts: Post[];
// }


export default function Catalog() {
    // use the setPosts functions to modify the state
    // set to Post type as in models
    const [posts, setPosts] = useState<Post[]>([]);
    const [postImages, setPostImages] = useState<Post[]>([]);
    const [loading, setLoading] = useState(true);

    // can add a side effect to component OnInit, i.e. when it loads, is destroyed, etc.
    useEffect(() => {
        // API endpoint
        fetch('https://localhost:5001/api/posts')
            .then(response => response.json())
            .then(data => {
                    setPosts(Array.from(data))
                }
            )

    }, []);
    

    return (
        <>
            <PostList posts={posts}/>
        </>

)
}