
/* 
 * Copyright [2023] [Javier Hermoso Blanco]
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://github.com/jhermoso/Trench/blob/main/LICENSE
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Trench.Fwk.Domain.Contracts
{
    using System;
    using System.Data;

    [Serializable]
    public abstract class EntityBase<TIdentifier> : IEntity<TIdentifier>
        where TIdentifier : IEquatable<TIdentifier>
    {
        private static int hashPrime = 31;

        public TIdentifier? Id { get; protected set; }

        public bool IsTransient()
        {
            return Id == null || Id.Equals(default(TIdentifier));
        }

        public bool Equals(IEntity<TIdentifier>? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is IEntity<TIdentifier> entity)
                return Equals(entity);

            return false;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                return Id!.GetHashCode() ^ hashPrime ^ GetType().GetHashCode();
            }
            return base.GetHashCode() ^ hashPrime ^ GetType().GetHashCode();
        }

        public static bool operator ==(EntityBase<TIdentifier>? left, EntityBase<TIdentifier>? right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(EntityBase<TIdentifier>? left, EntityBase<TIdentifier>? right)
        {
            return !(left == right);
        }
    }
}