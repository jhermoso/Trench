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
    /// TODO: update comments
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    [Serializable]
    public abstract class Disabled : IDisabled

    {
        #region Fields

        /// <summary>
        /// Variable privada de propiedad para indicar
        /// si la entidad está activa ó habilitada.
        /// </summary>
        private bool isActive;

        #endregion Fields

        #region Constructors


        /// <summary>
        /// 
        /// </summary>
        protected Disabled()
        {
            this.IsActive = true;
        }

        #endregion Constructors

        #region Properties




        /// <summary>
        /// Propiedad pública que indica
        /// si la entidad está activa.
        /// </summary>
        public virtual bool IsActive
        {
            get
            {
                return this.isActive;
            }
            protected set
            {
                this.isActive = value;
            }
        }



        #endregion Properties

        #region Methods

        /// <summary>
        /// Método encargado del borrado lógico de la entidad.
        /// </summary>
        public virtual void Disable()
        {
            if (this.IsActive)
            {
                this.IsActive = false;
            }
        }

        /// <summary>
        /// Método encargada del activar ó habilitar una entidad.
        /// </summary>
        public virtual void Enable()
        {
            if (!this.IsActive)
            {
                this.IsActive = true;
            }
        }

        #endregion Methods
    }
}
