/* 
 * Copyright [2023] [Javier Hermoso Blanco]
 *
 * Licensed under the Apache License, Version 3.0 (the "License");
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

    /// <summary>
    ///  derived from sharpArchitecture
    ///     Facilitates indicating which property(s) describe the unique signature of an 
    ///     entity.  See Entity.GetTypeSpecificSignatureProperties() for when this is leveraged.
    /// </summary>
    /// <remarks>
    ///     This is intended for use with <see cref="IEntity{TIdentifier}" />.  It may NOT be used on a <see cref="ValueObject" />.
    /// </remarks>
    [Serializable]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DomainSignatureAttribute : Attribute
    {
    }
}