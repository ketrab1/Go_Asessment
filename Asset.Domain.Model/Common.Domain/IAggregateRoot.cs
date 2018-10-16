using System;
using System.Collections.Generic;
using System.Text;

namespace Asset.Domain.Model.Common.Domain
{
    public interface IAggregateRoot<TEntity> : IEntity where TEntity : IEntity
    {
    }
}
