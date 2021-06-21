using Autofac;
using ForustaSpotify.BL.Clients;
using ForustaSpotify.BL.Clients.Interfaces;
using ForustaSpotify.BL.Clients.SpotifyRequest;
using ForustaSpotify.BL.Repositories;
using ForustaSpotify.BL.Repositories.Interfaces;
using ForustaSpotify.BL.Services;
using ForustaSpotify.BL.Services.Interfaces;

namespace ForustaSpotify.BL
{
    public class BLAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // repositories
            builder.RegisterType<Repository>()
                .As<IRepository>()
                .InstancePerLifetimeScope();


            // services
            builder.RegisterType<ArtistReadService>()
                .As<IArtistReadService>()
                .InstancePerLifetimeScope();


            // clients
            builder.RegisterType<SpotifyAuthClient>()
                .As<ISpotifyAuthClient>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SpotifyRequestClient>()
                .As<ISpotifyRequestClient>()
                .InstancePerLifetimeScope();
        }
    }
}
