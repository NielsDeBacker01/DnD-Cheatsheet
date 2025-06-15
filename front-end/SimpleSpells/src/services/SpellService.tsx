import { Spell } from "../types/Spell";
import axios, { AxiosInstance } from 'axios';

export class SpellService {
  private readonly api: AxiosInstance;

  constructor(baseUrl?: string) {
    this.api = axios.create({
      baseURL: baseUrl || `${process.env.REACT_APP_API_BASE_URL}/spells` || 'http://localhost:5000/spells',
      headers: {
        'Content-Type': 'application/json',
      },
    });
  }

  async getAllSpells(): Promise<Spell[]> {
    try {
      const response = await this.api.get<Spell[]>('');
      return response.data;
    } catch (error) {
      throw new Error(`Failed to fetch characters: ${this.getErrorMessage(error)}`);
    }
  }

  async getSpellById(id: number): Promise<Spell> {
    try {
      const response = await this.api.get<Spell>(`/${id}`);
      return response.data;
    } catch (error) {
      if (axios.isAxiosError(error) && error.response?.status === 404) {
        throw new Error('Character not found');
      }
      throw new Error(`Failed to fetch character: ${this.getErrorMessage(error)}`);
    }
  }

  //handles axios specific error messages or default messages
  private getErrorMessage(error: unknown): string {
    if (axios.isAxiosError(error)) {
      return error.response?.data?.message || error.message;
    }
    return error instanceof Error ? error.message : 'Unknown error';
  }
}