import { Action, Reducer } from 'redux';
import { UserActions, UserActionType } from '../actions/user.actions';
import { UserState } from "../state/user.state";

const unloadedState: UserState = { spotifyAuthUrl: '' };

export const reducer: Reducer<UserState> =
    (state: UserState | undefined, incomingAction: Action): UserState => {
        if (state === undefined) {
            return unloadedState;
        }

        const action = incomingAction as UserActions;
        switch (action.type) {
            case UserActionType.RequestAuthUrl:
                return { ...state };
            case UserActionType.ReceiveAuthUrl:
                return {
                    ...state,
                    spotifyAuthUrl: action.url
                };
        }

        return state;
    }