﻿//---------------------------------------------------------------------
// <copyright file="OriginalNameAttribute.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//      OriginalNameAttribute class
// </summary>
//
//---------------------------------------------------------------------
namespace Microsoft.OData.Client
{
    using System;

    /// <summary>Denotes the original name of a variable defined in metadata. </summary>
    public sealed class OriginalNameAttribute : Attribute
    {
        /// <summary>The original name.</summary>
        private readonly string originalName;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.OData.Client.OriginalNameAttribute" /> class. </summary>
        /// <param name="originalName">The string that contains original name of the variable.</param>
        public OriginalNameAttribute(string originalName)
        {
            this.originalName = originalName;
        }

        /// <summary>Gets the orginal names of the variable.</summary>
        /// <returns>String value that contains the original name of the variable. </returns>
        public string OriginalName
        {
            get { return this.originalName; }
        }
    }
}