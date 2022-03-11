using System.Text.RegularExpressions;

public static class ValidadorString
{
    public static bool Validar(string entrada)
    {
        bool resultado = false;
        int aberturas = 0;
        int fechamentos = 0;
        string expressao = entrada;
        string aux;
        string[] arrayabertura;
        string[] arrayfechamento;

        expressao = Regex.Replace(expressao, @"\s", "");

        arrayabertura = new string[expressao.Length];
        arrayfechamento = new string[expressao.Length];

        if (Regex.IsMatch(expressao, (@"^[a-zA-Z\(\)\[\]\{\}]+$")))
            resultado = true;
        
        if (resultado)
        {
            for (int j = 0; j < arrayabertura.Length; j++)
            {
                arrayabertura[j] = "";
                arrayfechamento[j] = "";
            }
        }

        if (resultado)
        {
            if (expressao.Contains("(") || expressao.Contains("{") || expressao.Contains("["))
            {
                if (expressao.Contains(")") || expressao.Contains("}") || expressao.Contains("]"))
                {
                    for (int i = 0; i <= expressao.Length-1; i++)
                    {
                        aux = expressao[i].ToString();
                        if ((aux == "(") || (aux == "[") || (aux == "{"))
                        {
                            arrayabertura[aberturas] = expressao[i].ToString();
                            aberturas++;
                        }
                        else if ((aux == ")") || (aux == "]") || (aux == "}"))
                        {
                            arrayfechamento[fechamentos] = expressao[i].ToString();
                            fechamentos++;
                        }
                    }
                    if (aberturas != fechamentos)
                        resultado = false;
                }
                else
                    resultado = false;
            }
            else if (expressao.Contains(")") || expressao.Contains("}") || expressao.Contains("]"))
                resultado = false;
        }

        if (resultado)
        {
            if (aberturas>0)
            {
                for (int i = 0; i < arrayabertura.Length; i++)
                {
                    if (arrayabertura[0] != "")
                    {
                        if (arrayabertura[i].ToString() == "(")
                        {
                            if (arrayfechamento[0].ToString() != ")")
                            {
                                resultado = false;
                                break;
                            }
                            else
                            {
                                for (int j = 0; j < arrayabertura.Length; j++)
                                {
                                    if (j != arrayabertura.Length-1)
                                    {
                                        arrayabertura[j] = arrayabertura[j + 1];
                                        arrayfechamento[j] = arrayfechamento[j + 1];
                                    }
                                    else
                                    {
                                        arrayabertura[j] = "";
                                        arrayfechamento[j] = "";
                                    }
                                }
                            }
                        }

                        if (arrayabertura[i].ToString() == "[")
                        {
                            if (arrayfechamento[0].ToString() != ")")
                            {
                                if (arrayfechamento[0].ToString() != "]")
                                {
                                    resultado = false;
                                    break;
                                }
                                else
                                {
                                    for (int j = 0; j < arrayabertura.Length; j++)
                                    {
                                        if (j != arrayabertura.Length - 1)
                                        {
                                            arrayabertura[j] = arrayabertura[j + 1];
                                            arrayfechamento[j] = arrayfechamento[j + 1];
                                        }
                                        else
                                        {
                                            arrayabertura[j] = "";
                                            arrayfechamento[j] = "";
                                        }
                                    }
                                }
                            }

                        }

                        if (arrayabertura[i].ToString() == "{")
                        {
                            if (arrayfechamento[0].ToString() != ")")
                            {
                                if (arrayfechamento[0].ToString() != "]")
                                {
                                    if (arrayfechamento[0].ToString() != "}")
                                    {
                                        resultado = false;
                                        break;
                                    }
                                    else
                                    {
                                        for (int j = 0; j < arrayabertura.Length; j++)
                                        {
                                            if (j != arrayabertura.Length - 1)
                                            {
                                                arrayabertura[j] = arrayabertura[j + 1];
                                                arrayfechamento[j] = arrayfechamento[j + 1];
                                            }
                                            else
                                            {
                                                arrayabertura[j] = "";
                                                arrayfechamento[j] = "";
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
        }

        return resultado;

    }
    public static void Main()
    {
        string Expressao = "";
        Console.WriteLine("Digite a Expressão: ");
        Expressao = Console.ReadLine();
        if (!string.IsNullOrEmpty(Expressao) && !string.IsNullOrWhiteSpace(Expressao))
        {
            if (Validar(Expressao))
                Console.WriteLine("Expressão Válida!");
            else
                Console.WriteLine("Expressão Inválida!");
        }
        else
            Console.WriteLine("Expressão Inválida!");
    }
}