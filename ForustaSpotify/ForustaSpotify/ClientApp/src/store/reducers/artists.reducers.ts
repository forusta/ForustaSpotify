import { Action, Reducer } from 'redux';
import { ArtistsActions, ArtistActionType } from '../actions/artists.actions';
import { ArtistsState } from '../state/artists.state';

const unloadedState: ArtistsState = { artists: [], isLoading: false };

export const reducer: Reducer<ArtistsState> = 
    (state: ArtistsState | undefined, incomingAction: Action): ArtistsState => {
        if (state === undefined) {
            return unloadedState;
        }

        const action = incomingAction as ArtistsActions;
        switch (action.type) {
            case ArtistActionType.RequestArtistsData:
                return {
                    ...state,
                    isLoading: true
                };
            case ArtistActionType.ReceiveArtistsData:
                return {
                    ...state,
                    artists: action.artists,
                    isLoading: false
                };
        }

        return state;
    }