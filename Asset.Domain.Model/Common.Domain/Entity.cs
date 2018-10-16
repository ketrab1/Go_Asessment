using System;
using System.Collections.Generic;
using System.Text;

namespace Asset.Domain.Model.Common.Domain
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; }
    }
    
}
