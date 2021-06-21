import { AppThunkAction } from '..';
import { Artist } from '../../models/artist';
import { ApiUrls } from '../../web/urls';

export enum ArtistActionType {
    RequestArtistsData = 'REQUEST_ARTISTS_DATA',
    ReceiveArtistsData = 'RECEIVE_ARTISTS_DATA'
}

export interface RequestArtistsDataAction {
    type: ArtistActionType.RequestArtistsData,
    name: string
}

export interface ReceiveArtistsDataAction {
    type: ArtistActionType.ReceiveArtistsData,
    artists: Artist[]
}

export type ArtistsActions = RequestArtistsDataAction | ReceiveArtistsDataAction;

export const artistActionCreators = {
    requestArtists: (name: string): AppThunkAction<ArtistsActions> => (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.artists && name) {
            fetch(`${ApiUrls.artistsSearch}${name}`)
                .then(response => response.json() as Promise<Artist[]>)
                .then(data => {
                    dispatch({type: ArtistActionType.ReceiveArtistsData, artists: data})
                });

            dispatch({ type: ArtistActionType.RequestArtistsData, name: name });
        }
    }
}