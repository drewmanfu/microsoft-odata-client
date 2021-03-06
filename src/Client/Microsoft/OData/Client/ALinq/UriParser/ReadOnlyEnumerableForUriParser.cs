//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

#if ASTORIA_CLIENT
namespace Microsoft.OData.Client.ALinq.UriParser
#else
namespace Microsoft.OData.Core.UriParser
#endif
{
    #region Namespaces
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    #endregion Namespaces

    /// <summary>
    /// Implementation of IEnumerable which is based on another IEnumerable
    /// but only exposes readonly access to that collection. This class doesn't implement
    /// any other public interfaces or public API unlike most other IEnumerable implementations
    /// which also implement other public interfaces.
    /// </summary>
    /// <typeparam name="T">The type of the items in the read-only enumerable.</typeparam>
    internal sealed class ReadOnlyEnumerableForUriParser<T> : IEnumerable<T>
    {
        /// <summary>
        /// The IEnumerable to wrap.
        /// </summary>
        private IEnumerable<T> sourceEnumerable;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceEnumerable">The enumerable to wrap.</param>
        internal ReadOnlyEnumerableForUriParser(IEnumerable<T> sourceEnumerable)
        {
            Debug.Assert(sourceEnumerable != null, "sourceEnumerable != null");

            this.sourceEnumerable = sourceEnumerable;
        }

        /// <summary>
        /// Returns the enumerator to iterate through the items.
        /// </summary>
        /// <returns>The enumerator object to use.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.sourceEnumerable.GetEnumerator();
        }

        /// <summary>
        /// Returns the (non-generic) enumerator to iterate through the items.
        /// </summary>
        /// <returns>The enumerator object to use.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.sourceEnumerable.GetEnumerator();
        }
    }
}
