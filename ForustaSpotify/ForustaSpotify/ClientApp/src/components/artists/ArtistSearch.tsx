import React from "react";
import { ArtistsState } from "../../store/state/artists.state";
import { artistActionCreators } from '../../store/actions/artists.actions';
import { RouteComponentProps } from "react-router";
import { ApplicationState } from "../../store/state/app.state";
import { connect } from "react-redux";
import ArtistList from "./ArtistList";

type ArtistProps = 
    ArtistsState
    & typeof artistActionCreators
    & RouteComponentProps<{ name: string }>;

class ArtistSearch extends React.PureComponent<ArtistProps> {
    render() {
        return (
            <React.Fragment>
                <input id="artistSearch" 
                    type="text" 
                    className="form-control"
                    onKeyDown={(event) => this.searchOnEnter(event)} />              
                <ArtistList />
            </React.Fragment>
        )
    }


    searchOnEnter(event: any) {
        if (event.key === "Enter" && event.currentTarget.value) {;
            this.props.requestArtists(event.currentTarget.value);
        }
    }

    private ensureDataFetched() {
        this.props.requestArtists(this.props.match.params.name);
    }
}

export default connect(
    (state: ApplicationState) => state.artists,
    artistActionCreators
)(ArtistSearch as any);