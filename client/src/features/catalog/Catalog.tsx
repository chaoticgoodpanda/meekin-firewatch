
import {Root} from "../../app/models/root";
import {Post} from "../../app/models/post";

interface Props {
    posts: Post[];
}

export default function Catalog({posts}: Props) {
    return (
        <>
            <ul>
                {posts.map((post) => (
                    <li key={post.id}>{post.message} - {post.postUrl}</li>
                ))}
            </ul>
            <button >Add Post</button>
        </>

)
}