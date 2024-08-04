


using System.Globalization;
using Trench.Fwk.Domain.Contracts;

namespace Trench.Fwk.Domain
{
    public record struct Switcher : ISwitchable
    {
        public bool IsActive { get; }

        public Switcher(){
            IsActive = true;
        }

        public ISwitchable Activate()
        {
            if (IsActive) return this;

            return newSwitch;
        }

        public ISwitchable Deactivate()
        {
            if (!IsActive) return this;
            var newSwitch = new Switcher(false, _stateChangedCallback);
            _stateChangedCallback(false);
            return newSwitch;
        }

        public bool Equals(ISwitchable? other)
        {
            return other != null && IsActive == other.IsActive;
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            // Si format es null o no está en la lista de formatos conocidos, usar formato general
            format = format?.ToUpperInvariant() ?? "G";

            // Proveedor de formato por defecto si es nulo
            formatProvider ??= CultureInfo.CurrentCulture;

            return format switch
            {
                "Y" => IsActive ? "Yes" : "No",   // Formato para "Sí/No"
                "G" => IsActive ? "Active" : "Inactive", // Formato general
                "0" => IsActive ? "0" : "1", // Formato para "0/1"
                "T" => IsActive ? "True" : "False", // Formato para "True/False

                _ => throw new FormatException($"The format of '{format}' is not supported.") // Formato no soportado
            };
        }
    }
}
