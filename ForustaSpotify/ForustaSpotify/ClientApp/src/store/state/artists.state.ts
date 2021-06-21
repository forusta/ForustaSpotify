import { Artist } from '../../models/artist';

export interface ArtistsState {
    artists: Artist[];
    isLoading: boolean;
}