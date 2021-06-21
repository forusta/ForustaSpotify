import React from 'react';
import { connect } from 'react-redux';
import { userActionCreators } from '../../store/actions/user.actions';
import { ApplicationState } from '../../store/state/app.state';
import { UserState } from '../../store/state/user.state';

type AuthPageProps = 
    UserState
    & typeof userActionCreators;

class AuthPage extends React.PureComponent<AuthPageProps> {

    public render() {
        this.props.requestUserAuthUrl();
        return (
            this.props.spotifyAuthUrl &&           
            <a href={this.props.spotifyAuthUrl}>
                <button>Authenticate at Spotify</button>
            </a>
        );
    }
}

export default connect(
    (state: ApplicationState) => state.user,
    userActionCreators
)(AuthPage as any)