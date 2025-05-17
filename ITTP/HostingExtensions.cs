namespace ITTP
{
    public static class HostingExtensions
    {
        public static IApplicationBuilder MapOnPublicPort(
        this IApplicationBuilder app,
        Action<IApplicationBuilder> builder)
        {
            return app.MapWhen(ctx => ctx.Connection.LocalPort == 8080, builder);
        }
    }
}
