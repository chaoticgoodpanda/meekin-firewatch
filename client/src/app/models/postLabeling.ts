import { RabatCountry } from "./rabatCountry";
import { RabatIntent } from "./rabatIntent";
import { RabatJustifications } from "./rabatJustifications";
import { RabatOffensive } from "./rabatOffensive";
import { RabatSpeaker } from "./rabatSpeaker";

export interface PostLabeling {
  id: string;
  organizationId: string;
  userId: string;
  platformId: string;
  facebookGuid: string;
  country: string;
  speaker: string;
  speechContent: string;
  translatedSpeechContent: string;
  justifications: string[];
  intent?: RabatIntent | null;
  rabatLikelihoodHarm: number;
  language: string;
  humanTarget: boolean;
  facebookDecision: string;
  createdDate: string;
  decisionDate: string;
  analysisReport: string;
  summaryAnalysis: string;
  analysisDate: string;
  originalPostUrl: string;
}
