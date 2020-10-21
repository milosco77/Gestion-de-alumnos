using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;

namespace Entidades
{
    [ComplexType]
    public class Notas
    {
        public Notas(){}
        public Notas(float pPrimerParcial, float pPrimerRecuperatorio, float pSegundoParcial, float pSegundoRecuperatorio, float pFinal)
        {
            PrimerParcial = pPrimerParcial;
            PrimerRecuperatorio = pPrimerRecuperatorio;
            SegundoParcial = pSegundoParcial;
            SegundoRecuperatorio = pSegundoRecuperatorio;
            Final = pFinal;
        }
        [Key]
        public int idNotas { get; set; }
        [MinLength(1), MaxLength(2)]
        public float PrimerParcial { get; set; }
        [MinLength(1), MaxLength(2)]
        public float PrimerRecuperatorio { get; set; }
        [MinLength(1), MaxLength(2)]
        public float SegundoParcial { get; set; }
        [MinLength(1), MaxLength(2)]
        public float SegundoRecuperatorio { get; set; }
        [MinLength(1), MaxLength(2)]
        public float Final { get; set; }
    }
}
