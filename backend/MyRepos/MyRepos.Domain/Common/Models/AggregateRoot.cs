﻿namespace MyRepos.Domain.Common.Models
{
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id)
        {
        }

#pragma warning disable CS8618
        protected AggregateRoot() { }
#pragma warning disable CS8618
    }
}
