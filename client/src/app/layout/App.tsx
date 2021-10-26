import React, {useEffect, useState} from 'react';
import {Post} from "../models/post";
import Catalog from "../../features/catalog/Catalog";
import {Root} from "../models/root";


function App() {
    // use the setPosts functions to modify the state
    // set to Post type as in models
    const [post, setRoot] = useState<Post[]>([]);
    
    // can add a side effect to component OnInit, i.e. when it loads, is destroyed, etc.
    useEffect(() => {
        // API endpoint
        fetch('https://localhost:5001/api/posts')
            .then(response => response.json())
            .then(data => setRoot(Array.from(data)))

    }, []);
    
    
  return (
    <div>
      <h1>Meekin Firewatch</h1>
        <Catalog posts={post} />

    </div>
  );
}

export default App;
