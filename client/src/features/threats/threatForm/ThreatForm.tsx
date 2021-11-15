import React, {ChangeEvent, useState} from 'react';
import {
    Box,
    Button,
    Card,
    CardHeader, Chip, FormControl,
    FormControlLabel, FormLabel, InputLabel, MenuItem, OutlinedInput,
    Radio,
    RadioGroup,
    Select, SelectChangeEvent, Slider,
    TextField, Theme,
    Typography, useTheme
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
    // for the chip dropdown
    const theme = useTheme();
    const [justification, setJustification] = React.useState<string[]>([]);
    
    const initialState = selectedReport ?? {
        id: '',
        organizationId: post.account.name,     // TODO: placeholder to change later when at user identity
        userId: post.id,
        platformId: post.platformId,
        facebookGuid: post.guidId,
        country: post.account.pageAdminTopCountry,
        speaker: '',
        justifications: [],
        rabatVirality: post.statistics.actual?.shareCount,
        rabatLikelihoodHarm: undefined,
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

    const rabatJustifications = [
        'Racism',
        'ReligiousHatred',
        'Misogyny',
        'Violence',
        'SexualViolence',
        'RacePurity',
        'ReligiousPurity',
        'ComparisonToAnimals',
        'FakeNews',
        'Bribery',
        'ElectionFraud',
        'AntiInterracial',
        'FemalePurity',
        'FakeDeath',
        'CovidFraud',
        'ConsumerFraud',
        'DonationFraud',
        'AntiLGBTIQ'
    ];
    
    const handleChangeJustifications = (event: SelectChangeEvent<typeof justification>) => {
        const {
            target: { value },
        } = event;
        setJustification(
            // On autofill we get a the stringified value.
            typeof value === 'string' ? value.split(',') : value,
        );
    };

    // returns value of slider
    function valuetext(value: number) {
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
        console.log(report);
    }
    
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
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
                <TextField id="outlined-basic" value={report.summaryAnalysis} name='summaryAnalysis' label="Report title" variant="outlined" onChange={handleInputChange} />
                <Typography id="input-slider" gutterBottom>
                    Use the slider to express how dangerous the content is. <br/>
                    -100 = not dangerous at all. 100 = the most dangerous content.
                </Typography>
                <Slider
                    aria-label="Danger Score"
                    defaultValue={0}
                    getAriaValueText={valuetext}
                    value={report.rabatLikelihoodHarm}
                    valueLabelDisplay="auto"
                    step={10}
                    marks
                    min={-100}
                    max={100}
                    color='secondary'
                />
                <FormControl component="fieldset">
                    <FormLabel component="legend">Who is the speaker?</FormLabel>
                        <RadioGroup row aria-label="rabat-speaker?" value={report.speaker} name="row-buttons-radio-group" onChange={handleInputChange}>
                            <FormControlLabel value="Politician" control={<Radio />} label="Politician" color="secondary" />
                            <FormControlLabel value="Public Figure" control={<Radio />} label="Public Figure" color="secondary" />
                            <FormControlLabel value="Private Person" control={<Radio />} label="Private Person" color="secondary" />
                        </RadioGroup>
                </FormControl>
                <FormControl component="fieldset">
                    <FormLabel component="legend">Does the content target a human or group of humans?</FormLabel>
                    <RadioGroup row aria-label="rabat-speaker?" value={report.humanTarget} name="row-buttons-radio-group" onChange={handleInputChange}>
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
                        value={report.justifications}
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
            </Box>
            <Button sx={{ml: 1, mt: 1}} type='submit' onClick={() => handleInputChange} color="success" 
                    variant="contained">Submit Report</Button>
            <Button sx={{ml: 1, mt: 1}} type='submit' onClick={closeForm} color="error"
                    variant="contained">Cancel</Button>
        </>
          
    )
    
}