using System;

namespace Enumeraciones
{
    public enum Cargos : int
    {
        TitularCatedra = 0,
        AyudanteCatedra = 1
    }

    public enum Materias : int
    {
        Matematica = 0,
        Ingles = 1,
        Algebra = 2
    }

    public enum Facultades : int
    {
        Ingenieria = 0,
        CienciasExactas = 1,
        Agronomia = 2
    }

    public enum Opciones : int
    {
        ModoAutomatico = 1,
        ModoManual = 2,
        Salir = 3
    }
}
