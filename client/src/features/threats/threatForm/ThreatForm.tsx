import React, {ChangeEvent, useState} from 'react';
import {
    Box,
    Button,
    Card,
    CardHeader, FormControl,
    FormControlLabel, FormLabel, MenuItem,
    Radio,
    RadioGroup,
    Select,
    TextField, Theme,
    Typography
} from "@mui/material";
import {Segment} from "@mui/icons-material";
import {history} from "../../../index";
import {PostLabeling} from "../../../app/models/postLabeling";
import {RabatCountry} from "../../../app/models/rabatCountry";
import {RabatSpeaker} from "../../../app/models/rabatSpeaker";
import {RabatOffensive} from "../../../app/models/rabatOffensive";
import {RabatJustifications} from "../../../app/models/rabatJustifications";
import {RabatIntent} from "../../../app/models/rabatIntent";
import {Post} from "../../../app/models/post";

interface Props {
    report: PostLabeling | undefined;
    closeForm: () => void;
    post: Post;
}



export default function ThreatForm({report: selectedReport, closeForm, post}: Props) {
    const [justification, setJustification] = React.useState<string[]>([]);
    // const [post, setPost] = useState<Post>();
    
    const initialState = selectedReport ?? {
        id: '',
        organizationId: post.account.name,     // TODO: placeholder to change later when at user identity
        userId: post.id,
        platformId: post.platformId,
        facebookGuid: post.guidId,
        country: post.account.pageAdminTopCountry,
        speaker: '',
        isDangerous: '',
        justifications: '',
        rabatVirality: post.statistics.actual?.shareCount,
        rabatLikelihoodHarm: '',
        language: post.languageCode,
        speechContent: post.message,
        humanTarget: false,
        facebookDecision: '',
        createdDate: post.date,
        decisionDate: '',
        analysisReport: '',
        summaryAnalysis: '',
        analysisDate: new Date().getUTCDate()
    }
    
    const [report, setReport] = useState(initialState);
    const [radioValue, setRadioValue] = React.useState('');

    const handleRadioChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setRadioValue((event.target as HTMLInputElement).value);
        
    };

    // for dropdowns
    const ITEM_HEIGHT = 48;
    const ITEM_PADDING_TOP = 8;
    const MenuProps = {
        PaperProps: {
            style: {
                maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
                width: 250,
            },
        },
    };

    const rabatJustifiications = [
        'Dehumanization',
        'GuiltAttribution',
        'ThreatConstruction',
        'DestructionAlternatives',
        'VirtueTalk',
        'FutureBias'
    ];

    function getStyles(name: string, personName: readonly string[], theme: Theme) {
        return {
            fontWeight:
                personName.indexOf(name) === -1
                    ? theme.typography.fontWeightRegular
                    : theme.typography.fontWeightMedium,
        };
    }
    
    function handleSubmit() {
        console.log(report);
    }
    
    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const {name, value} = event.target;
        setReport({...report, [name]: value});
    }
    
    return (
        <>
            <Box
                component="form"
                sx={{
                    '& > :not(style)': { m: 1, width: '60ch' },
                }}
                noValidate
                autoComplete="on"
            >
                <TextField id="outlined-basic" value={report.summaryAnalysis} name='summaryAnalysis' label="Report title" variant="outlined" />
                <FormControl component="fieldset">
                    <FormLabel component="legend">Is the post dangerous?</FormLabel>
                        <RadioGroup row aria-label="is-dangerous" value={report.isDangerous} name="row-buttons-radio-group">
                            <FormControlLabel value="true" onClick={() => handleRadioChange} control={<Radio />} label="Yes" />
                            <FormControlLabel value="false" onClick={() => handleRadioChange} control={<Radio />} label="No" />
                        </RadioGroup>
                </FormControl>
                <FormControl component="fieldset">
                    <FormLabel component="legend">Who is the speaker?</FormLabel>
                        <RadioGroup row aria-label="rabat-speaker?" value={report.speaker} name="row-buttons-radio-group">
                            <FormControlLabel value="Politician" control={<Radio />} label="Politician" color="secondary" />
                            <FormControlLabel value="Public Figure" control={<Radio />} label="Public Figure" color="secondary" />
                            <FormControlLabel value="Private Person" control={<Radio />} label="Private Person" color="secondary" />
                        </RadioGroup>
                </FormControl>
                <TextField id="filled-multiline-flexible" name='analysisReport' value={report.analysisReport} label="Analysis" variant="filled"
                           multiline rows={5}
                />
            </Box>
            <Button sx={{ml: 1, mt: 1}} type='submit' onClick={() => handleInputChange} color="success" 
                    variant="contained">Submit Report</Button>
            <Button sx={{ml: 1, mt: 1}} type='submit' onClick={closeForm} color="error"
                    variant="contained">Cancel</Button>
        </>
          
    )
    
}