using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Notas
    {
        public Notas(float pPrimerParcial, float pPrimerRecuperatorio, float pSegundoParcial, float pSegundoRecuperatorio, float pFinal)
        {
            PrimerParcial = pPrimerParcial;
            PrimerRecuperatorio = pPrimerRecuperatorio;
            SegundoParcial = pSegundoParcial;
            SegundoRecuperatorio = pSegundoRecuperatorio;
            Final = pFinal;
        }
        public float PrimerParcial { get; set; }
        public float PrimerRecuperatorio { get; set; }
        public float SegundoParcial { get; set; }
        public float SegundoRecuperatorio { get; set; }
        public float Final { get; set; }
    }
}
