import React, {useEffect, useState} from 'react';
import {Post} from "../models/post";


function App() {
    // use the setPosts functions to modify the state
    // set to Post type as in models
    const [posts, setPosts] = useState<Post[]>([]);
    
    // can add a side effect to component OnInit, i.e. when it loads, is destroyed, etc.
    useEffect(() => {
        // API endpoint
        fetch('https://localhost:5001/api/posts')
            .then(response => response.json())
            .then(data => Array.from(data))
    }, []);
    
    function addPost() {
        setPosts(prevState => [...prevState, {
            id: '239847',
            title: 'Bill Clinton',
            primaryId: prevState.length + 1,
            platformId: '239389',
            platform: 'Facebook',
            date: '2020-12-30',
            updated: '2021-01-23',
            caption: 'Bill is in trouble!',
            type: 'Post',
            expandedLinks: [],
            description: 'old president in trouble',
            message: 'It was reported today new allegations against President Bill Clinton',
            postUrl: 'https://www.facebook.com',
            link: 'http://google.com',
            subscriberCount: 933482,
            score: 9383,
            media: [],
            statistics: {id: 39348, actual: {id: 3283, likeCount: 3, shareCount: 3, commentCount: 3, angryCount: 5, careCount: 2,
                wowCount: 23, hahaCount: 233, loveCount: 203, sadCount: 39, thankfulCount: 1}, expected: {id: 3283, likeCount: 3, shareCount: 3, commentCount: 3, angryCount: 5, careCount: 2,
                    wowCount: 23, hahaCount: 233, loveCount: 203, sadCount: 39, thankfulCount: 1}},
            account: {    id: 23838,
                name: 'NBC',
                handle: 'nbcnews',
                profileImage: 'http://facebook.com/imag_83383',
                subscriberCount: 239048904,
                url: 'http://www.facebook.com/nbcnews/2393203',
                platform: 'Facebook',
                platformId: '29323902390',
                accountType: 'page',
                pageAdminTopCountry: 'us',
                pageDescription: 'NBC News is a news source',
                pageCreatedDate: '2006-03-04',
                pageCategory: 'news',
                verified: true },
            languageCode: 'en',
            legacyId: 9023903,
            videoLengthMS: 343
        }])
    }
    
  return (
    <div className='app'>
      <h1>Meekin Firewatch</h1>
      <ul>
          {posts.map((post, index) => (
              <li key={index}>{post.title} - {post.platform}</li>
          ))}
      </ul>
      <button onClick={addPost}>Add Post</button>  
    </div>
  );
}

export default App;
