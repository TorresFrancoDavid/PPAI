using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class DetalleMuestraSismica
    {
        public double Valor { get; set; }
        public TipoDeDato TipoDeDato { get; set; }
        public DetalleMuestraSismica(double valor, TipoDeDato tipoDato)
        {
            Valor = valor;
            TipoDeDato = tipoDato;
        }

        public string GetDatos()
        {
            string valor = Valor.ToString();
            string denominacion = TipoDeDato.Denominacion;
            string valorDenominacion = valor + denominacion;
            return (valorDenominacion);
        }

    }
}
