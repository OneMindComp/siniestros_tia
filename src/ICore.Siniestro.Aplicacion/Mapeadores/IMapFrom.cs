using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICore.Siniestro.Aplicacion.Mapeadores
{
    /// <summary>
    /// Configuracion automaper para entidades genericas T.
    /// </summary>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Mapeo de entidades genericas T que implementen la interfaz.
        /// </summary>
        /// <param name="profile">Perfil de mapeo utilizado para crear el mapeo.</param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
