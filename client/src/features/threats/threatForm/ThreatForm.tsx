import React, {ChangeEvent, useEffect, useState} from 'react';
import {
    Box,
    Button, 
    Chip, FormControl,
    FormControlLabel, FormLabel, InputLabel, MenuItem, OutlinedInput,
    Radio,
    RadioGroup,
    Select, SelectChangeEvent, Slider,
    TextField, Theme,
    Typography, useTheme
} from "@mui/material";
import {PostLabeling} from "../../../app/models/postLabeling";
import {Post} from "../../../app/models/post";
import {LoadingButton} from "@mui/lab";
import {useStore} from "../../../app/stores/store";
import {observer} from "mobx-react-lite";
import {Link, useHistory, useParams} from "react-router-dom";
import LoadingComponent from "../../../app/layout/LoadingComponent";

interface Props {
    post: Post;
    deleteReport: (id: string) => void;
}



export default observer (function ThreatForm({post, deleteReport}: Props) {
    const history = useHistory();
    const {reportStore} = useStore();
    const {selectedReport, createReport, updateReport, loading, loadReport, loadingInitial, closeReportForm} = reportStore;
    // const {id} = useParams<{id: string}>();
    
    // for the chip dropdown
    const theme = useTheme();
    const [justification, setJustification] = React.useState<string[]>([]);


    
    const initialState = selectedReport ?? {
        id: '',
        organizationId: post.account.name,     // TODO: placeholder to change later when at user identity
        userId: '',
        platformId: post.platformId,
        facebookGuid: post.guidId,
        country: post.account.pageAdminTopCountry,
        speaker: '',
        justifications: [],
        //@ts-ignore
        rabatLikelihoodHarm: 0,
        language: post.languageCode,
        speechContent: post.message,
        humanTarget: false,
        facebookDecision: '',
        createdDate: customJSONstringify(post.date),
        decisionDate: '',
        analysisReport: '',
        summaryAnalysis: '',
        analysisDate: customJSONstringify(new Date()),
        originalPostUrl: post.postUrl
    }
    
    // useEffect(() => {
    //     if (id) loadReport(id).then(report => setReport(report!))
    // }, [id, loadReport]);

    const [report, setReport] = useState(initialState);
    const [radioValue, setRadioValue] = React.useState('');
    const [humanRadio, setHumanRadio] = React.useState(false);
    
    
    // conversion of strings to booleans for radio values
    var str2bool = (value: any) => {
        if (value && typeof value === "string") {
            if (value.toLowerCase() === "true") return true;
            if (value.toLowerCase() === "false") return false;
        }
        return value;
    }


    const handleRadioChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setRadioValue(report.speaker = (event.target as HTMLInputElement).value);
    };

    const handleHumanRadioChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setHumanRadio(report.humanTarget = str2bool(event.target.value));
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

    const rabatJustifications = [
        'Racism',
        'Religious Hatred',
        'Misogyny',
        'Violence',
        'Sexual Violence',
        'Nudity',
        'Race Purity',
        'Religious Purity',
        'Comparison To Animals',
        'Fake News',
        'Bribery',
        'Election Fraud',
        'Anti-Interracial',
        'Female Purity',
        'Fake Death',
        'Covid Fraud',
        'Consumer Fraud',
        'Donation Fraud',
        'Anti-LGBTIQ',
        'Trafficking'
    ];
    
    const handleChangeJustifications = (event: SelectChangeEvent<typeof justification>) => {
        const {
            target: { value },
        } = event;
        setJustification(
            // On autofill we get a the stringified value.
            report.justifications = typeof value === 'string' ? value.split(',') : value,
        );
    };

    // stringify date to proper .NET Date format
    function customJSONstringify(obj: any) {
        return JSON.stringify(obj).replace(/\/Date/g, "\\\/Date").replace(/\)\//g, "\)\\\/")
    }

    // returns value of slider
    function valuetext(value: number) {
        report.rabatLikelihoodHarm = value;
        return `${value}`;
    }

    function getStyles(name: string, justification: readonly string[], theme: Theme) {
        return {
            fontWeight:
                justification.indexOf(name) === -1
                    ? theme.typography.fontWeightRegular
                    : theme.typography.fontWeightMedium,
        };
    }
    
    function handleSubmit() {
        // console.log(report);
        report.id ? updateReport(report) : createReport(report);
    }
    
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const {name, value} = event.target;
        setReport({...report, [name]: value});
    }
    
    async function submitRefreshPage() {
        handleSubmit();
        window.setTimeout(function(){window.location.reload()},1000);
    }
    

    
    
    // if (loadingInitial) return <LoadingComponent message="Loading report..." />
    
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
            <FormControl onSubmit={handleSubmit}>
                <TextField id="outlined-basic" value={report.summaryAnalysis} name='summaryAnalysis' label="Report title" variant="outlined" onChange={handleInputChange} />
                <Typography id="input-slider" gutterBottom>
                    Use the slider to express how dangerous the content is. <br/>
                    -100 = not dangerous at all. 100 = the most dangerous content.
                </Typography>
                <Slider
                    aria-label="Danger Score"
                    defaultValue={0}
                    getAriaValueText={valuetext}
                    valueLabelDisplay="auto"
                    step={10}
                    marks
                    min={-100}
                    max={100}
                    color='secondary'
                />
                <FormControl component="fieldset">
                    <FormLabel component="legend">Who is the speaker?</FormLabel>
                        <RadioGroup row aria-label="rabat-speaker?" value={radioValue} name="row-buttons-radio-group" onChange={handleRadioChange}>
                            <FormControlLabel value="Politician" control={<Radio />} label="Politician" color="secondary" />
                            <FormControlLabel value="Public Figure" control={<Radio />} label="Public Figure" color="secondary" />
                            <FormControlLabel value="Private Person" control={<Radio />} label="Private Person" color="secondary" />
                        </RadioGroup>
                </FormControl>
                <FormControl component="fieldset">
                    <FormLabel component="legend">Does the content target a human or group of humans?</FormLabel>
                    <RadioGroup row aria-label="rabat-speaker?" value={humanRadio} name="row-buttons-radio-group" onChange={handleHumanRadioChange}>
                        <FormControlLabel value="true" control={<Radio />} label="Yes" color="secondary" />
                        <FormControlLabel value="false" control={<Radio />} label="No" color="secondary" />
                    </RadioGroup>
                </FormControl>
                <FormControl component="fieldset">
                    <InputLabel id="demo-multiple-chip-label">Violations in content</InputLabel>
                    <Select
                        labelId="demo-multiple-chip-label"
                        id="demo-multiple-chip"
                        multiple
                        value={justification}
                        onChange={handleChangeJustifications}
                        input={<OutlinedInput id="select-multiple-chip" label="Chip" />}
                        renderValue={(selected) => (
                            <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 0.5 }}>
                                {selected.map((value) => (
                                    <Chip key={value} label={value} />
                                ))}
                            </Box>
                        )}
                        MenuProps={MenuProps}
                    >
                        {rabatJustifications.map((rJustifications) => (
                            <MenuItem
                                key={rJustifications}
                                value={rJustifications}
                                style={getStyles(rJustifications, justification, theme)}
                            >
                                {rJustifications}
                            </MenuItem>
                        ))}
                    </Select>
                </FormControl>
                <TextField id="filled-multiline-flexible" name='analysisReport' value={report.analysisReport} label="Analysis" variant="filled"
                           multiline rows={5} onChange={handleInputChange}
                />
            </FormControl>
            </Box>
            <LoadingButton sx={{ml: 1, mt: 1}} type='submit' onClick={submitRefreshPage} color="success"
                    variant="outlined" loading={loading}>Submit Report</LoadingButton>
            <Button component={Link} to={'/catalog'}  sx={{ml: 1, mt: 1}} type='submit' color="error"
                    variant="outlined">Cancel</Button>
        </>
          
    )
    
})