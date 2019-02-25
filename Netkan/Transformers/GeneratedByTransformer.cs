﻿using System;
using System.Collections.Generic;
using CKAN.NetKAN.Model;
using log4net;

namespace CKAN.NetKAN.Transformers
{
    /// <summary>
    /// An <see cref="ITransformer"/> that adds a property to indicate the program responsible for generating the
    /// metadata.
    /// </summary>
    internal sealed class GeneratedByTransformer : ITransformer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(GeneratedByTransformer));

        public string Name { get { return "generated_by"; } }

        public IEnumerable<Metadata> Transform(Metadata metadata)
        {
            var json = metadata.Json();

            Log.InfoFormat("Executing generated by transformation with {0}", metadata.Kref);
            Log.DebugFormat("Input metadata:{0}{1}", Environment.NewLine, json);

            json["x_generated_by"] = "netkan"; // TODO: We should write the specific version here too

            Log.DebugFormat("Transformed metadata:{0}{1}", Environment.NewLine, json);

            yield return new Metadata(json);
        }
    }
}
