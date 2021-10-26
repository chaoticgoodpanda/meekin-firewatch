import React, {useEffect, useState} from 'react';


function App() {
    // use the setPosts functions to modify the state
    const [posts, setPosts] = useState([
        {name: 'post1', price: 100.00},
        {name: 'post2', price: 200.00}
    ]);
    
    // can add a side effect to component OnInit, i.e. when it loads, is destroyed, etc.
    useEffect(() => {
        // API endpoint
        fetch('http://localhost:5000/api/posts')
            .then(response => response.json())
            .then(data => setPosts(data))
    })
    
    function addPost() {
        setPosts(prevState => [...prevState, {name: 'post' + (prevState.length+1), price: (prevState.length * 100 + 100)}])
    }
  return (
    <div className='app'>
      <h1>Meekin Firewatch</h1>
      <ul>
          {posts.map((post, index) => (
              <li key={index}>{post.name} - {post.price}</li>
          ))}
      </ul>
      <button onClick={addPost}>Add Post</button>  
    </div>
  );
}

export default App;
