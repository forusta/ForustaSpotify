import { ArtistsState } from './artists.state';
import { UserState } from './user.state';

// The top-level state object
export interface ApplicationState {
    user: UserState | undefined;    
    artists: ArtistsState | undefined;
}