import {Container, Link, Typography} from "@mui/material";

export default function HomePage() {
    return (
        <Container sx={{mt: '7em'}}>
            <Typography variant='h2'>
            Home
            </Typography>
            <Typography variant='h3'>
                Go to <Link href='/catalog'>Catalog</Link>
            </Typography>
        </Container>
    )
}