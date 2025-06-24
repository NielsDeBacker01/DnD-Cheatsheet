import { Character } from "../types/Character";
import axios, { AxiosInstance } from 'axios';
import { CharacterWithSpells } from "../types/CharacterWithSpells";

export class CharacterService {
  private readonly api: AxiosInstance;

  constructor(baseUrl?: string) {
    this.api = axios.create({
      baseURL: baseUrl || `${import.meta.env.VITE_API_BASE_URL}/characters` || 'http://localhost:5000/characters',
      headers: {
        'Content-Type': 'application/json',
      },
    });
  }

  async getAllCharacters(): Promise<Character[]> {
    try {
      const response = await this.api.get<Character[]>('');
      return response.data;
    } catch (error) {
      throw new Error(`Failed to fetch characters: ${this.getErrorMessage(error)}`);
    }
  }

  async getCharacterById(id: number): Promise<Character> {
    try {
      const response = await this.api.get<Character>(`/${id}`);
      return response.data;
    } catch (error) {
      if (axios.isAxiosError(error) && error.response?.status === 404) {
        throw new Error('Character not found');
      }
      throw new Error(`Failed to fetch character: ${this.getErrorMessage(error)}`);
    }
  }

  async getAllCharactersWithSpells(): Promise<CharacterWithSpells[]> {
    try {
      const response = await this.api.get<CharacterWithSpells[]>('/spells');
      return response.data;
    } catch (error) {
      throw new Error(`Failed to fetch characters: ${this.getErrorMessage(error)}`);
    }
  }

  async getCharacterWithSpellsById(id: number): Promise<CharacterWithSpells> {
    try {
      const response = await this.api.get<CharacterWithSpells>(`/spells/${id}`);
      return response.data;
    } catch (error) {
      if (axios.isAxiosError(error) && error.response?.status === 404) {
        throw new Error('Character not found');
      }
      throw new Error(`Failed to fetch character: ${this.getErrorMessage(error)}`);
    }
  }

  async createCharacter(character: Omit<Character, 'id'>): Promise<Character> {
    try {
      const response = await this.api.post<Character>('', character);
      return response.data;
    } catch (error) {
      throw new Error(`Failed to create character: ${this.getErrorMessage(error)}`);
    }
  }

  async updateCharacter(id: number, character: Character): Promise<Character> {
    try {
      const response = await this.api.put<Character>(`/${id}`, { ...character, id });
      return response.data;
    } catch (error) {
      if (axios.isAxiosError(error)) {
        if (error.response?.status === 404) {
          throw new Error('Character not found');
        }
        if (error.response?.status === 400) {
          throw new Error('Invalid character data or ID mismatch');
        }
      }
      throw new Error(`Failed to update character: ${this.getErrorMessage(error)}`);
    }
  }

  async deleteCharacter(id: number): Promise<boolean> {
    try {
      const response = await this.api.delete(`/${id}`);
      return response.status === 204;
    } catch (error) {
      if (axios.isAxiosError(error) && error.response?.status === 404) {
        throw new Error('Character not found');
      }
      throw new Error(`Failed to delete character: ${this.getErrorMessage(error)}`);
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

//singleton instance
export const characterService = new CharacterService();