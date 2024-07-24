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
    /// Interfaz que representa el objeto-valor
    /// de tipo auditoría de datos.
    /// </summary>

    public interface IAuditInfo : IValueObject
    {
        #region Properties

        /// <summary>
        /// Propiedad que obtiene el identificador único
        /// del usuario que crea el registro.
        /// </summary>

        string CreatedBy
        {
            get;
        }

        /// <summary>
        /// Propiedad que indica la fecha de creación del registro.
        /// </summary>

        DateTime CreatedTimestamp
        {
            get;
        }

        /// <summary>
        /// Propiedad que obtiene el identificador único
        /// del usuario que modifica el registro.
        /// </summary>
        string UpdatedBy
        {
            get;
        }

        /// <summary>
        /// Propiedad que indica la fecha de modificación del registro.
        /// </summary>
        DateTime? UpdatedTimestamp
        {
            get;
        }

        #endregion Properties
    }
}