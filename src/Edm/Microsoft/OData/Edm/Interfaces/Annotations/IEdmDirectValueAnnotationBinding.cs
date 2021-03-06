//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

namespace Microsoft.OData.Edm.Annotations
{
    /// <summary>
    /// Represents the combination of an EDM annotation with an immediate value and the element to which it is attached.
    /// </summary>
    public interface IEdmDirectValueAnnotationBinding
    {
        /// <summary>
        /// Gets the element to which the annotation is attached
        /// </summary>
        IEdmElement Element { get; }

        /// <summary>
        /// Gets the namespace URI of the annotation.
        /// </summary>
        string NamespaceUri { get; }

        /// <summary>
        /// Gets the local name of this annotation.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the value of this annotation.
        /// </summary>
        object Value { get; }
    }
}
