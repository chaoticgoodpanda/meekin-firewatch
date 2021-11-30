import {Message} from "@mui/icons-material";
import {Alert} from "@mui/lab";
import {Box, Card, CardContent, Stack} from "@mui/material";


interface Props {
    errors: string[] | null;
}

export default function ValidationErrors({errors}: Props) {
    return (
        <Box>
            {errors && (
                <Stack sx={{ width: '100%' }} spacing={2}>
                    {errors.map((err: any, i) => (
                        <Alert severity='error' key={i}>{err}</Alert>
                    ))}
                </Stack>
            )}
        </Box>
    )
}