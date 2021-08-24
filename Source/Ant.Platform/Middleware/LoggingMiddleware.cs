﻿using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Svc.Platform.Middleware
{
    public class LoggingMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            
            await _next.Invoke(context);

            if (context.Request.Method == "OPTIONS") return;
            
            var level = LogLevel.Information;
            if (399 < context.Response.StatusCode) level = LogLevel.Warning;
            if (499 <  context.Response.StatusCode) level = LogLevel.Error;

            var template = "HTTP {Path} responded {StatusCode} in {ElapsedMilliseconds} ms";
            _logger.Log(level, template, context.Request.Path, context.Response.StatusCode, sw.ElapsedMilliseconds);
        }
    }
}