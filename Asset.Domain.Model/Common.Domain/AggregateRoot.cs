using System;
using System.Collections.Generic;
using System.Text;

namespace Asset.Domain.Model.Common.Domain
{
    public abstract class AggregateRoot<TAggregateRoot> : Entity, IAggregateRoot<TAggregateRoot>
        where TAggregateRoot : AggregateRoot<TAggregateRoot>
    { }
}
