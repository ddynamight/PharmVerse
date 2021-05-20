using MediatR;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Common
{
     public abstract class Entity
     {
          int? _requestedHashCode;
          Guid _Id;
          public virtual Guid Id
          {
               get
               {
                    return _Id;
               }
               protected set
               {
                    _Id = value;
               }
          }

          public byte[] RowVersion { get; set; }

          private List<INotification> _domainEvents;
          public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

          public void AddDomainEvent(INotification eventItem)
          {
               _domainEvents ??= new List<INotification>();
               _domainEvents.Add(eventItem);
          }

          public void RemoveDomainEvent(INotification eventItem)
          {
               _domainEvents?.Remove(eventItem);
          }

          public void ClearDomainEvents()
          {
               _domainEvents?.Clear();
          }

          public bool IsTransient()
          {
               return this.Id == default(Guid);
          }

          public override bool Equals(object obj)
          {
               if (obj == null || !(obj is Entity))
                    return false;

               if (Object.ReferenceEquals(this, obj))
                    return true;

               if (this.GetType() != obj.GetType())
                    return false;

               Entity item = (Entity)obj;

               if (item.IsTransient() || this.IsTransient())
                    return false;
               else
                    return item.Id == this.Id;
          }

          public override int GetHashCode()
          {
               if (!IsTransient())
               {
                    if (!_requestedHashCode.HasValue)
                         _requestedHashCode = this.Id.GetHashCode() ^ 31;

                    return _requestedHashCode.Value;
               }
               else
                    return base.GetHashCode();

          }
          public static bool operator ==(Entity left, Entity right)
          {
               if (Object.Equals(left, null))
                    return (Object.Equals(right, null)) ? true : false;
               else
                    return left.Equals(right);
          }

          public static bool operator !=(Entity left, Entity right)
          {
               return !(left == right);
          }
     }
}
