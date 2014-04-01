//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

namespace Microsoft.OData.Core.JsonLight
{
    #region Namespaces
    using System;
    using System.Diagnostics;
    #endregion Namespaces

    /// <summary>
    /// Helper methods used by the OData reader for the JsonLight format.
    /// </summary>
    internal static class ODataJsonLightValidationUtils
    {
        /// <summary>
        /// Validates that a string is either a valid absolute URI, or (if it begins with '#') it is a valid URI fragment.
        /// </summary>
        /// <param name="metadataDocumentUri">The metadata document uri.</param>
        /// <param name="propertyName">The property name to validate.</param>
        internal static void ValidateMetadataReferencePropertyName(Uri metadataDocumentUri, string propertyName)
        {
            DebugUtils.CheckNoExternalCallers();
            Debug.Assert(metadataDocumentUri != null, "metadataDocumentUri != null");
            Debug.Assert(metadataDocumentUri.IsAbsoluteUri, "metadataDocumentUri.IsAbsoluteUri");
            Debug.Assert(!String.IsNullOrEmpty(propertyName), "!string.IsNullOrEmpty(propertyName)");

            string uriStringToValidate = propertyName;

            // If it starts with a '#', validate that the rest of the string is a valid Uri fragment.
            if (propertyName[0] == JsonLightConstants.ContextUriFragmentIndicator)
            {
                // In order to use System.Uri to validate a fragement, we first prepend the metadataDocumentUri
                // so that it becomes an absolute URI which we can validate with Uri.IsWellFormedUriString.
                uriStringToValidate = UriUtilsCommon.UriToString(metadataDocumentUri) + UriUtils.EnsureEscapedFragment(propertyName);
            }

            if (!Uri.IsWellFormedUriString(uriStringToValidate, UriKind.Absolute) ||
                !ODataJsonLightUtils.IsMetadataReferenceProperty(propertyName) ||
                propertyName[propertyName.Length - 1] == JsonLightConstants.ContextUriFragmentIndicator)
            {
                throw new ODataException(Strings.ValidationUtils_InvalidMetadataReferenceProperty(propertyName));
            }

            if (IsOpenMetadataReferencePropertyName(metadataDocumentUri, propertyName))
            {
                throw new ODataException(Strings.ODataJsonLightValidationUtils_OpenMetadataReferencePropertyNotSupported(propertyName, UriUtilsCommon.UriToString(metadataDocumentUri)));
            }
        }

        /// <summary>
        /// Validates an operation is valid.
        /// </summary>
        /// <param name="metadataDocumentUri">The metadata document uri.</param>
        /// <param name="operation">The operation to validate.</param>
        internal static void ValidateOperation(Uri metadataDocumentUri, ODataOperation operation)
        {
            DebugUtils.CheckNoExternalCallers();
            Debug.Assert(operation != null, "operation != null");

            ValidationUtils.ValidateOperationMetadataNotNull(operation);
            string name = UriUtilsCommon.UriToString(operation.Metadata);

            if (metadataDocumentUri != null)
            {
                Debug.Assert(metadataDocumentUri.IsAbsoluteUri, "metadataDocumentUri.IsAbsoluteUri");
                ValidateMetadataReferencePropertyName(metadataDocumentUri, name);
                Debug.Assert(!IsOpenMetadataReferencePropertyName(metadataDocumentUri, name), "!IsOpenMetadataReferencePropertyName(metadataDocumentUri, name)");
            }
        }

        /// <summary>
        /// Determines if the specified property name is a name of an open metadata reference property.
        /// </summary>
        /// <param name="metadataDocumentUri">The metadata document uri.</param>
        /// <param name="propertyName">The property name in question.</param>
        /// <returns>true if the specified property name is a name of an open metadata reference property; false otherwise.</returns>
        internal static bool IsOpenMetadataReferencePropertyName(Uri metadataDocumentUri, string propertyName)
        {
            DebugUtils.CheckNoExternalCallers();
            Debug.Assert(metadataDocumentUri != null, "metadataDocumentUri != null");
            Debug.Assert(metadataDocumentUri.IsAbsoluteUri, "metadataDocumentUri.IsAbsoluteUri");
            Debug.Assert(!String.IsNullOrEmpty(propertyName), "!string.IsNullOrEmpty(propertyName)");

            // If a metadata reference property isn't based off of the known metadata document URI (for example, it points to a model on another server), 
            // then it must be open. It is based off the known metadata document URI if it either is a fragment (i.e., starts with a hash) or starts with the known absolute URI.
            return ODataJsonLightUtils.IsMetadataReferenceProperty(propertyName)
                && propertyName[0] != JsonLightConstants.ContextUriFragmentIndicator
                && !propertyName.StartsWith(UriUtilsCommon.UriToString(metadataDocumentUri), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Validates that the property in an operation (an action or a function) is valid.
        /// </summary>
        /// <param name="propertyValue">The value of the property.</param>
        /// <param name="propertyName">The name of the property (used for error reporting).</param>
        /// <param name="metadata">The metadata value for the operation (used for error reporting).</param>
        internal static void ValidateOperationPropertyValueIsNotNull(object propertyValue, string propertyName, string metadata)
        {
            DebugUtils.CheckNoExternalCallers();
            Debug.Assert(!String.IsNullOrEmpty(metadata), "!string.IsNullOrEmpty(metadata)");

            if (propertyValue == null)
            {
                throw new ODataException(OData.Core.Strings.ODataJsonLightValidationUtils_OperationPropertyCannotBeNull(propertyName, metadata));
            }
        }
    }
}