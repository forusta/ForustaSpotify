namespace ForustaSpotify.Engine
open ForustaSpotify.Data.Models.Artist

module Filter =
    let getArtistsWithGenres (artists: ArtistModel list) = 
        artists 
        |> List.filter (fun artist -> artist.Genres |> List.ofSeq |> List.isEmpty |> not)
