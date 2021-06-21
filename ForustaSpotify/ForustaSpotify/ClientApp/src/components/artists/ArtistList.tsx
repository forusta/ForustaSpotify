import React from 'react';
import { connect } from 'react-redux';
import { Artist } from '../../models/artist';
import { ApplicationState } from '../../store/state/app.state';
import { ArtistsState } from '../../store/state/artists.state';

type ArtistListProps = ArtistsState;

class ArtistList extends React.PureComponent<ArtistListProps> {

    render() {
        const isAnyArtists = this.props.artists;
        return (
            isAnyArtists &&
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Genres</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.artists.map((artist: Artist) =>
                        <tr key={artist.id}>
                            <td>{artist.name}</td>
                            <td>{artist.genres.join(', ')}</td>
                        </tr>
                    )}
                </tbody>
            </table>            
        )
    }

}

export default connect(
    (state: ApplicationState) => state.artists,
)(ArtistList as any);