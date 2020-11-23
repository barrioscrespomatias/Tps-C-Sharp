using System;
using Entidades;

public delegate void DelegadoDeColono(Colono c1);
public delegate bool DelegadoColono(Colono c1);
public delegate Colonia DelegadoDeLaColonia();
public delegate int DelegadoCuentaDni(Colono c1);
public delegate void DelegadoCargaProfesor(Profesor p1);

public delegate void DelegadoDelHilo();
