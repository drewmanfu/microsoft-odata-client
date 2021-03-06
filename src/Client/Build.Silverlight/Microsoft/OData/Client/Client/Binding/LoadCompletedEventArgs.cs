//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

#if ASTORIA_LIGHT || PORTABLELIB
namespace Microsoft.OData.Client
{
    #region Namespaces.
    using System;
    using System.ComponentModel;
    #endregion Namespaces.

    /// <summary>Used as the <see cref="T:System.EventArgs" /> class for the <see cref="E:Microsoft.OData.Service.Client.DataServiceCollection`1.LoadCompleted" /> event.Supported only by the WCF Data Services 5.0 client for Silverlight.</summary>
    public sealed class LoadCompletedEventArgs : AsyncCompletedEventArgs
    {
        /// <summary>The <see cref="QueryOperationResponse"/> which represents
        /// the response for the Load operation.</summary>
        /// <remarks>This field is non-null only when the Load operation was successfull.
        /// Otherwise it's null.</remarks>
        private QueryOperationResponse queryOperationResponse;

        /// <summary>Constructor</summary>
        /// <param name="queryOperationResponse">The response for the Load operation. null when the operation didn't succeed.</param>
        /// <param name="error"><see cref="Exception"/> which represents the error if the Load operation failed. null if the operation
        /// didn't fail.</param>
        /// <remarks>This constructor doesn't allow creation of canceled event args.</remarks>
        internal LoadCompletedEventArgs(QueryOperationResponse queryOperationResponse, Exception error)
            : this(queryOperationResponse, error, false)
        {
        }

        /// <summary>Constructor</summary>
        /// <param name="queryOperationResponse">The response for the Load operation. null when the operation didn't succeed.</param>
        /// <param name="error"><see cref="Exception"/> which represents the error if the Load operation failed. null if the operation
        /// didn't fail.</param>
        /// <param name="cancelled">True, if the LoadAsync operation was cancelled, False otherwise.</param>
        /// <remarks>This constructor doesn't allow creation of canceled event args.</remarks>
        internal LoadCompletedEventArgs(
            QueryOperationResponse queryOperationResponse,
            Exception error,
            bool cancelled)
            : base(error, cancelled, null)
        {
            this.queryOperationResponse = queryOperationResponse;
        }

        /// <summary>Gets the response to an asynchronous load operation.Supported only by the WCF Data Services 5.0 client for Silverlight.</summary>
        /// <returns>A <see cref="T:Microsoft.OData.Service.Client.QueryOperationResponse" /> that represents the response to a load operation.</returns>
        /// <remarks>Accessing this property will throw exception if the Load operation failed
        /// or it was canceled.</remarks>
        public QueryOperationResponse QueryOperationResponse
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return this.queryOperationResponse;
            }
        }
    }
}
#endif
