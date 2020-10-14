using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Notas
    {
        public Notas(float _PrimerParcial, float _PrimerRecuperatorio, float _SegundoParcial, float _SegundoRecuperatorio, float _Final)
        {
            PrimerParcial = _PrimerParcial;
            PrimerRecuperatorio = _PrimerRecuperatorio;
            SegundoParcial = _SegundoParcial;
            SegundoRecuperatorio = _SegundoRecuperatorio;
            Final = _Final;
        }
        public float PrimerParcial { get; set; }
        public float PrimerRecuperatorio { get; set; }
        public float SegundoParcial { get; set; }
        public float SegundoRecuperatorio { get; set; }
        public float Final { get; set; }
    }
}
