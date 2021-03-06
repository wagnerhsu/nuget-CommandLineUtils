// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace McMaster.Extensions.CommandLineUtils
{
    /// <summary>
    /// The option used to determine if version text should be displayed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public sealed class VersionOptionAttribute : OptionAttributeBase
    {
        /// <summary>
        /// Initializes a new <see cref="VersionOptionAttribute"/> with the template <c>--version</c>.
        /// </summary>
        /// <param name="version">The version</param>
        public VersionOptionAttribute(string version)
            : this(Strings.DefaultVersionTemplate, version)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="VersionOptionAttribute"/>.
        /// </summary>
        /// <param name="template">The string template. <seealso cref="CommandOption.Template"/>.</param>
        /// <param name="version">The version</param>
        public VersionOptionAttribute(string template, string version)
        {
            Version = version;
            Template = template;
            Description = Strings.DefaultVersionOptionDescription;
        }

        /// <summary>
        /// The version information to be shown. <see cref="CommandLineApplication.ShortVersionGetter"/>.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The option template. This is parsed into the short and long name.
        /// </summary>
        public new string Template { get; set; }

        internal CommandOption Configure(CommandLineApplication app)
        {
            var opt = app.VersionOption(Template, Version);
            Configure(opt);
            return opt;
        }
    }
}
