﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace Swashbuckle.AspNetCore.Swagger
{
    public interface ISwaggerProvider
    {
        OpenApiDocument GetSwagger(
            string documentName,
            string serverUrl = null);
    }

    public interface IAsyncSwaggerProvider
    {
        Task<OpenApiDocument> GetSwaggerAsync(
            string documentName,
            string serverUrl = null);
    }

    public class UnknownSwaggerDocument : InvalidOperationException
    {
        public UnknownSwaggerDocument(string documentName, IEnumerable<string> knownDocuments)
            : base(string.Format("Unknown Swagger document - \"{0}\". Known Swagger documents: {1}",
                documentName,
                string.Join(",", knownDocuments?.Select(x => $"\"{x}\""))))
        {}
    }
}