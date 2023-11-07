﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Cynosura.Web.Infrastructure;

namespace Cynosura.Studio.Web.Routes
{
    public class EnumModule : IConfigurationModule<IEndpointRouteBuilder>
    {
        public void Configure(IEndpointRouteBuilder configuration)
        {
            configuration.MapGrpcService<Services.EnumService>();
        }
    }
}
