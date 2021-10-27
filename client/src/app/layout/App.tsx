import React, {useEffect, useState} from 'react';
import {Post} from "../models/post";
import Catalog from "../../features/catalog/Catalog";
import {Container, CssBaseline, Typography} from "@mui/material";
import {Medium} from "../models/medium";
import Header from "./Header";


function App() {
    // use the setPosts functions to modify the state
    // set to Post type as in models
    const [post, setPosts] = useState<Post[]>([]);
    // const [media, setMedia] = useState<Medium[]>([]);
    
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
        <CssBaseline />
        <Header />
        <Container>
            <Catalog posts={post} />
        </Container>
        

    </>
  );
}

export default App;
