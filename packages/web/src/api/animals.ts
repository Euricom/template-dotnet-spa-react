import { type components } from './schema';

type AnimalDTO = components['schemas']['Animal'];

export const getAnimals = async () => {
  const response = await fetch('/api/animals');
  return response.json() as Promise<AnimalDTO[]>;
};
