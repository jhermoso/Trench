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
    /// <summary>
    /// Interfaz para representar las entidades del negocio auditables.
    /// </summary>
    /// <typeparam name="TIdentifier">
    /// Representación del tipo del identificador de la entidad.
    /// </typeparam>
    
    public interface IAuditable
    {
        #region Properties

        /// <summary>
        /// Propiedad que obtiene la información de auditoría.
        /// </summary>
        /// <value>
        /// Valor utilizado para obtener la información de auditoría.
        /// </value>
        IAuditInfo AuditInfo
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Método para auditar la eliminación de una entidad existente.
        /// </summary>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador único del usuario
        /// que elimina la entidad.
        /// </param>
        void AuditDelete(string updatedBy);

        /// <summary>
        /// Método para auditar la creación de una nueva entidad.
        /// </summary>
        /// <param name="createdBy">
        /// Parámetro que indica el identificador único del usuario
        /// que crea la nueva entidad.
        /// </param>
        void AuditInsert(string createdBy);

        /// <summary>
        /// Método para auditar la modificación de una entidad existente.
        /// </summary>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador único del usuario
        /// que modifica la entidad.
        /// </param>
        void AuditUpdate(string updatedBy);

        #endregion Methods
    }
}