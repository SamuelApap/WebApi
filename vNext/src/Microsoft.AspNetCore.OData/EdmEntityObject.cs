﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using Microsoft.OData.Edm;

namespace Microsoft.AspNetCore.OData
{
    /// <summary>
    /// Represents an <see cref="IEdmEntityObject"/> with no backing CLR <see cref="Type"/>.
    /// </summary>
    [NonValidatingParameterBinding]
    public class EdmEntityObject : EdmStructuredObject, IEdmEntityObject
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="EdmStructuredObject"/> class.
		/// </summary>
		/// <param name="edmType">The <see cref="IEdmEntityType"/> of this object.</param>
		/// <param name="assembliesResolver">The assemblies resolve to use for type resolution</param>
		public EdmEntityObject(IEdmEntityType edmType, AssembliesResolver assembliesResolver)
            : this(edmType, assembliesResolver, isNullable: false)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="EdmStructuredObject"/> class.
		/// </summary>
		/// <param name="edmType">The <see cref="IEdmEntityTypeReference"/> of this object.</param>
		/// <param name="assembliesResolver">The assemblies resolve to use for type resolution</param>
		public EdmEntityObject(IEdmEntityTypeReference edmType, AssembliesResolver assembliesResolver)
            : this(edmType.EntityDefinition(), assembliesResolver, edmType.IsNullable)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="EdmStructuredObject"/> class.
		/// </summary>
		/// <param name="edmType">The <see cref="IEdmEntityType"/> of this object.</param>
		/// <param name="assembliesResolver">The assemblies resolve to use for type resolution</param>
		/// <param name="isNullable">true if this object can be nullable; otherwise, false.</param>
		public EdmEntityObject(IEdmEntityType edmType, AssembliesResolver assembliesResolver, bool isNullable)
            : base(edmType, assembliesResolver, isNullable)
        {
        }
    }
}
