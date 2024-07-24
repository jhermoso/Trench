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
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase pública que representa la información de auditoría.
    /// </summary>
    /// <remarks>
    /// Objeto-valor para los datos de auditoría.
    /// </remarks>
    public class AuditInfo : IAuditInfo
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:AuditInfo"/>.
        /// </summary>
        /// <remarks>
        /// Constructor vacio requerido por nHibernate.
        /// </remarks>
        internal AuditInfo()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:AuditInfo"/>.
        /// </summary>
        /// <param name="createdBy">
        /// Parámetro que indica el identificador del usuario
        /// que crea el registro.
        /// </param>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador del usuario
        /// que modifica el registro.
        /// </param>
        /// <param name="createdTimestamp">
        /// Parámetro que indica la fecha de creación del registro.
        /// </param>
        /// <param name="updatedTimestamp">
        /// Parámetro que indica la fecha de modificación del registro.
        /// </param>
        internal AuditInfo(
            string createdBy,
            string updatedBy,
            DateTime createdTimestamp,
            DateTime? updatedTimestamp)
        {
            // Inicializamos las propiedades de la clase.
            this.CreatedBy = createdBy;
            this.UpdatedBy = updatedBy;
            this.CreatedTimestamp = createdTimestamp;
            this.UpdatedTimestamp = updatedTimestamp;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad que obtiene el identificador único
        /// del usuario que crea el registro.
        /// </summary>
        /// <value>
        /// Valor que se utilizada para obtener  el identificador
        /// único del usuario que crea el registro.
        /// </value>
        [Required]
        public virtual string CreatedBy
        {
            get;
            protected set;
        }

        /// <summary>
        /// Propiedad que obtiene la fecha de
        /// creación del registro.
        /// </summary>
        /// <value>
        /// Valor que se utilizada para obtener la
        /// fecha de creación del registro.
        /// </value>
        [Required]
        [DataType(DataType.DateTime)]
        public virtual DateTime CreatedTimestamp
        {
            get;
            protected set;
        }

        /// <summary>
        /// Propiedad que obtiene el identificador único
        /// del usuario que modifica el registro.
        /// </summary>
        /// <value>
        /// Valor que se utilizada para obtener el identificador
        /// único del usuario que modifica el registro.
        /// </value>
        public virtual string UpdatedBy
        {
            get;
            protected set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece la fecha de
        /// modificación del registro.
        /// </summary>
        /// <value>
        /// Valor que se utilizada para obtener o establecer la
        /// fecha de modificación del registro.
        /// </value>
        [DataType(DataType.DateTime)]
        public virtual DateTime? UpdatedTimestamp
        {
            get;
            protected set;
        }

        #endregion Properties
    }
}