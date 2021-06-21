import { AppThunkAction } from '..';
import { ApiUrls } from '../../web/urls';

export enum UserActionType {
    RequestAuthUrl = 'REQUEST_AUTH_URL',
    ReceiveAuthUrl = 'RECEIVE_AUTH_URL'
}

export interface RequestAuthUrlAction {
    type: UserActionType.RequestAuthUrl
}

export interface ReceiveAuthUrlAction {
    type: UserActionType.ReceiveAuthUrl,
    url: string
}

export type UserActions = RequestAuthUrlAction | ReceiveAuthUrlAction;

export const userActionCreators = {
    requestUserAuthUrl: (): AppThunkAction<UserActions> => (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.user) {
            //fetch(`${ApiUrls.artistsSearch}Muse`)
            fetch(`${ApiUrls.spotifyAuth}`)
                .then(response => response.json() as Promise<string>)
                .then(data => {
                    dispatch({type: UserActionType.ReceiveAuthUrl, url: data})
                });

            dispatch({type: UserActionType.RequestAuthUrl});
        }
    }
}