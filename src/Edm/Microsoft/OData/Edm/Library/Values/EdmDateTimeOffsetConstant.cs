//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

using System;
using Microsoft.OData.Edm.Expressions;
using Microsoft.OData.Edm.Values;

namespace Microsoft.OData.Edm.Library.Values
{
    /// <summary>
    /// Represents an EDM datetime with offset constant.
    /// </summary>
    public class EdmDateTimeOffsetConstant : EdmValue, IEdmDateTimeOffsetConstantExpression
    {
        private readonly DateTimeOffset value;

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmDateTimeOffsetConstant"/> class.
        /// </summary>
        /// <param name="value">DateTimeOffset value represented by this value.</param>
        public EdmDateTimeOffsetConstant(DateTimeOffset value)
            : this(null, value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmDateTimeOffsetConstant"/> class.
        /// </summary>
        /// <param name="type">Type of the DateTimeOffset.</param>
        /// <param name="value">DateTimeOffset value represented by this value.</param>
        public EdmDateTimeOffsetConstant(IEdmTemporalTypeReference type, DateTimeOffset value)
            : base(type)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the definition of this value.
        /// </summary>
        public DateTimeOffset Value
        {
            get { return this.value; }
        }

        /// <summary>
        /// Gets the kind of this expression.
        /// </summary>
        public EdmExpressionKind ExpressionKind
        {
            get { return EdmExpressionKind.DateTimeOffsetConstant; }
        }

        /// <summary>
        /// Gets the kind of this value.
        /// </summary>
        public override EdmValueKind ValueKind
        {
            get { return EdmValueKind.DateTimeOffset; }
        }
    }
}
