import {Typography} from "@mui/material";
import {useParams} from "react-router-dom";

export default function PostDetails() {
    // takes the http URL as a string for the specific post detail
    const {id} = useParams<{id: string}>();
    
    
    return (
        <Typography variant='h2'>
            Post Details
        </Typography>
    )
}