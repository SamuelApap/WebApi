﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using System.Diagnostics.Contracts;
using Microsoft.OData.Core;
using Microsoft.OData.Edm;

namespace Microsoft.AspNetCore.OData
{
    /// <summary>
    /// Represents an <see cref="IEdmDeltaDeletedEntityObject"/> with no backing CLR <see cref="Type"/>.
    /// Used to hold the Deleted Entry object in the Delta Feed Payload.
    /// </summary>
    [NonValidatingParameterBinding]
    public class EdmDeltaDeletedEntityObject : EdmEntityObject, IEdmDeltaDeletedEntityObject
    {
        private string _id;
        private DeltaDeletedEntryReason _reason;
        private EdmDeltaType _edmType;

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmDeltaDeletedEntityObject"/> class.
        /// </summary>
        /// <param name="entityType">The <see cref="IEdmEntityType"/> of this DeltaDeletedEntityObject.</param>
        public EdmDeltaDeletedEntityObject(IEdmEntityType entityType, AssembliesResolver assembliesResolver)
            : this(entityType, assembliesResolver, isNullable: false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmDeltaDeletedEntityObject"/> class.
        /// </summary>
        /// <param name="entityTypeReference">The <see cref="IEdmEntityTypeReference"/> of this DeltaDeletedEntityObject.</param>
        public EdmDeltaDeletedEntityObject(IEdmEntityTypeReference entityTypeReference, AssembliesResolver assembliesResolver)
            : this(entityTypeReference.EntityDefinition(), assembliesResolver, entityTypeReference.IsNullable)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmDeltaDeletedEntityObject"/> class.
        /// </summary>
        /// <param name="entityType">The <see cref="IEdmEntityType"/> of this DeltaDeletedEntityObject.</param>
        /// <param name="isNullable">true if this object can be nullable; otherwise, false.</param>
        public EdmDeltaDeletedEntityObject(IEdmEntityType entityType, AssembliesResolver assembliesResolver, bool isNullable)
            : base(entityType, assembliesResolver, isNullable)
        {
            _edmType = new EdmDeltaType(entityType, EdmDeltaEntityKind.DeletedEntry);
        }

        /// <inheritdoc />
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <inheritdoc />
        public DeltaDeletedEntryReason Reason
        {
            get
            {
                return _reason;
            }
            set
            {
                _reason = (DeltaDeletedEntryReason)value;
            }
        }

        /// <inheritdoc />
        public EdmDeltaEntityKind DeltaKind
        {
            get
            {
                Contract.Assert(_edmType != null);
                return _edmType.DeltaKind;
            }
        }
    }
}
