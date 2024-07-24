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
    /// Interfaz para representar objetos auditables.
    /// </summary>
    
    [Serializable]
    public abstract class Auditable :IAuditable
    {
        #region Fields

        /// <summary>
        /// Variable encargada de almacenar la información
        /// de auditoría.
        /// </summary>
        /// <remarks>
        /// Para ello se utilizará el objeto valor <see cref="IAuditInfo"/>.
        /// </remarks>
        private IAuditInfo auditInfo;

        #endregion Fields

        #region Constructors

        ///// <summary>
        //// TODO: incorporar en la creación la inserción del auditinfo de creación.
        ///// Inicializa una nueva instancia de la clase <see cref="T:AuditableEntityBase"/>.
        ///// </summary>
        ///// <param name="id">
        ///// Parámetro que indica el identificador único de la entidad.
        ///// </param>
        //protected AuditableEntity(TIdentifier id)
        //{
        //    this.Id = id;
        //    this.IsActive = true;
        //}

        #endregion Constructors

        #region Properties

        ///// <summary>
        ///// Devuelve el tipo actual de la entidad, con independencia
        ///// del nivel en el que nos encontremos en la jerarquía de clases.
        ///// </summary>
        ///// <remarks>
        ///// El tipo real será utilizado como criterio principal
        ///// durante la igualdad y comparación entre entidades.
        ///// </remarks>
        ///// <value>
        ///// El tipo real (tipo <see cref="T:System.Type"/> hoja) de la
        ///// entidad.
        ///// </value>
        //public virtual System.Type ActualType
        //{
        //    get
        //    {
        //        return typeof(AuditableEntity<TEntity, TIdentifier>);
        //    }
        //}

        /// <summary>
        /// Propiedad que obtiene la información de auditoría.
        /// </summary>
        /// <value>
        /// Valor utilizado para obtener la información de auditoría.
        /// </value>
        public virtual IAuditInfo AuditInfo
        {
            get
            {
                return this.auditInfo;
            }
            protected set
            {
                this.auditInfo = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Método para auditar la eliminación de la entidad.
        /// </summary>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador único del usuario
        /// que modifica la entidad.
        /// </param>
        public virtual void AuditDelete(string updatedBy)
        {
            this.AuditUpdate(updatedBy);
        }

        /// <summary>
        /// Método para auditar la creación de la entidad.
        /// </summary>
        /// <param name="createdBy">
        /// Parámetro que indica el identificador único del usuario
        /// que modifica la entidad.
        /// </param>
        public virtual void AuditInsert(string createdBy)
        {
            // Creamos el objeto-valor AuditInfo.
            IAuditInfo auditInfoObject = AuditInfoFactory.Create(
                                             createdBy,
                                             null,
                                             System.DateTime.UtcNow,
                                             null);
            // Establecemos los datos de auditoría.
            this.AuditInfo = auditInfoObject;
        }

        /// <summary>
        /// Método para auditar la modificación de la entidad.
        /// </summary>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador único del usuario
        /// que modifica la entidad.
        /// </param>
        public virtual void AuditUpdate(string updatedBy)
        {

            IAuditInfo auditInfoObject = AuditInfoFactory.Create(
                                             System.Convert.ToString(this.AuditInfo.CreatedBy),
                                             updatedBy,
                                             this.auditInfo.CreatedTimestamp,
                                             System.DateTime.UtcNow);

            this.AuditInfo = auditInfoObject;
        }

        #endregion Methods
    }
}
