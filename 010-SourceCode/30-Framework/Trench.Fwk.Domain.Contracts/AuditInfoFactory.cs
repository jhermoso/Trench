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
    /// Clase estática factoría para la creación de objetos
    /// valor de tipo <see cref="IAuditInfo"/>
    /// </summary>
    public static class AuditInfoFactory
    {
        #region Methods

        /// <summary>
        /// Método encargado de crear objetos valor de tipo
        /// <see cref="IAuditInfo"/>
        /// </summary>
        /// <param name="createdBy">
        /// Parámetro que indica el identificador del usuario
        /// que crea el registro.
        /// </param>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador del usuario
        /// que modifica el registro.
        /// </param>
        /// <param name="createTimestamp">
        /// Parámetro que indica la fecha de creación del registro.
        /// </param>
        /// <param name="updateTimestamp">
        /// Parámetro que indica la fecha de modificación del registro.
        /// </param>
        /// <returns>
        /// Devuelve el objeto valor <see cref="IAuditInfo"/> creado.
        /// </returns>
        public static IAuditInfo Create(
            string createdBy,
            string updatedBy,
            DateTime createTimestamp,
            DateTime? updateTimestamp)
        {
            // Creamos un objeto de tipo AuditInfo
            IAuditInfo auditInfo = new AuditInfo(
                createdBy,
                updatedBy,
                createTimestamp,
                updateTimestamp);
            // Devolvemos el resultado.
            return auditInfo;
        }

        #endregion Methods
    }
}