using System;

namespace ErgCentral.Data.Base
{
    internal interface IHasCreatedLastModified
    {
        #region Public Properties

        DateTime Created { get; set; }

        DateTime? LastModified { get; set; }

        #endregion Public Properties
    }
}