﻿using Hangfire;
using MediatR;
using Ant.Platform.Configurations;

namespace Ant.Platform.Hangfire
{
    public static class HangfireMediatorExtensions
    {
        public static void Enqueue(this IMediator mediator, IRequest request)
        {
            var backgroundJobClient = new BackgroundJobClient();
            backgroundJobClient.Enqueue<MediatorHangfireBridge>(x => x.Send(request));
        }
    }
}