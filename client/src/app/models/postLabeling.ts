import { RabatCountry } from "./rabatCountry";
import { RabatIntent } from "./rabatIntent";
import { RabatJustifications } from "./rabatJustifications";
import { RabatOffensive } from "./rabatOffensive";
import { RabatSpeaker } from "./rabatSpeaker";

export interface PostLabeling {
  id: string;
  organizationId: number | null;
  userId: number | null;
  postId: number | null;
  platformId: string;
  facebookGuid: string;
  country: RabatCountry;
  speaker: RabatSpeaker;
  offensive: RabatOffensive;
  isDangerous: boolean | null;
  justifications: RabatJustifications | null;
  rabatVirality: number;
  intent: RabatIntent | null;
  rabatLikelihoodHarm: number;
  language: string;
  offensiveContent: boolean;
  humanTarget: boolean;
  facebookDecision: string;
  createdDate: string | null;
  decisionDate: string | null;
  accessTime: string | null;
  analysisReport: string;
  summaryAnalysis: string;
  analysisDate: string | null;
}
