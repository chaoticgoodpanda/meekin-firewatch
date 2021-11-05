import React, {useEffect, useState} from 'react';
import {Box, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, Typography} from "@mui/material";
import axios from "axios";
import LoadingComponent from "../../app/layout/LoadingComponent";

const googleTranslateApiKey = "AIzaSyCHUCmpR7cT_yDFHC98CZJy2LTms-IwDlM";


// in case user wants to select different languages in the future
const languageOptions = [
    {
        label: 'English',
        value: 'en'
    },
    {
        label: 'Sinhala',
        value: 'si'
    },
    {
        label: 'Burmese',
        value: 'my'
    },
    {
        label: 'Hindi',
        value: 'hi'
    }
]


// const [language, setLanguage] = useState(languageOptions[0]);

// @ts-ignore
const GoogleTranslate = ({language, text}) => {
    const [translated, setTranslated] = useState('');
    
    // translate incoming text into English
    useEffect(() => {
        // wrapper helper function to make axios POST call async
        const doTranslation = async () => {
            const {data} = await axios.post('https://translation.googleapis.com/language/translate/v2',
                {}, {
                    params: {
                        q: text,
                        target: 'en',
                        key: googleTranslateApiKey
                    }
                });
            setTranslated(data.data.translations[0].translatedText);
        };
        doTranslation();
    }, [language, text]);
    
    
    return (
        <Typography variant="body2" color="text.secondary">
            {translated}
        </Typography>
    )
};

export default GoogleTranslate;