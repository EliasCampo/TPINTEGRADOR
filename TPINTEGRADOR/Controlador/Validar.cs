﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TPIntegrador.Controlador
{
    internal class Validar
    {

        private static int CalcularDigitoCuit(string cuit)
        {
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            char[] nums = cuit.ToCharArray();
            int total = 0;

            for (int i = 0; i < mult.Length; i++)
            {
                total += int.Parse(nums[i].ToString()) * mult[i];
            }

            var resto = total % 11;
            return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
        }

        public static bool ValidaCuit(string cuit)
        {
            if (cuit == null)
            {
                return false;
            }
            //Quito los guiones, el cuit resultante debe tener 11 caracteres.
            cuit = cuit.Replace("-", string.Empty);
            if (cuit.Length != 11)
            {
                return false;
            }
            else
            {
                int calculado = CalcularDigitoCuit(cuit);
				int digito = int.Parse(cuit.Substring(10));
				return calculado == digito;
				
            }
        }

        public static void mOk(string mensaje)
        {
            MessageBox.Show(mensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void mError(string mensaje)
        {
            MessageBox.Show(mensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool mConsulta(string mensaje)
        {
            if (MessageBox.Show(mensaje, "CONSULTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void mAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static Boolean validarCorreo(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            try
            {
                if (Regex.IsMatch(email, expresion))
                {
                    if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show("Email invalido. Ingrese un mail valido");
                return false;
            }
            
        }

        public static Boolean validarFecha(String fecha)  // FUNCIONANDO validar fecha para empleado y observaciones del empleado
        {
            if (fecha == null)
            {
                return false;
            }
            else
            {
                String expresion;
                expresion = @"\b(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})\b";
                if (Regex.IsMatch(fecha, expresion))
                {
                    if (Regex.Replace(fecha, expresion, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }

        public static int validarFuncion(string funcion) 
        {
            switch (funcion)
            {
                case "Señor":
                    return 2;
                case "Semi Señor":
                    return 3;
                case "Junior":
                    return 4;
                default:
                    return 0;
            }
        }

        public static string validarFuncionObtenida(int funcion)  // se utiliza para mostrar el combobox la funcion que tiene un empleado
        {
            switch (funcion)
            {
                case 2:
                    return "Señor";
                case 3: 
                    return "Semi Señor";
                case 4:
                    return "Junior";
                default:
                    return "";
            }
        }
    }
}

