using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polish
{
    /*Добавленно:
     * считывает все вещественные числа
     * обрабатывает скобки
     * считает отрицательные числа
     * выводит польскую запись и ответ 
     * */
    class Algoritms
    {
         Stack<double> num = new Stack<double>(); // стек цифр
         Stack<string> con = new Stack<string>(); // стек знаков операции
        string pol = ""; // польская запись
        string alg; 
       
        /// <param name="alg">входная строка</param>
         public Algoritms(string alg)
        {
            this.alg = alg;
             if (alg=="" || alg ==" ")
                 throw new Exception(" Введите выражение ");
            
        }
       
        /// <summary>
        /// Алгоритм вычисления
        /// </summary>
        /// <returns></returns>
        public string Algoritm()
         {
             
             alg += " "; // Добавление пробела в конец
             int b;
           //  bool f3 = true;
             
             for (int i = 0; i <= alg.Length; ) 
             {
                 string num2 = ""; bool f2 = true; string num3 = "";
                 //if (alg[0] == '-' && f3 == true)
                 //{
                 //    num.Push(0);
                 //    f3 = false;
                 //}

                 if (alg[i] == '(' && alg[i + 1] == '-' && char.IsNumber(alg[i+2]) && alg[i+3]==')')
                 {
                     num3 = "-" + alg[i + 2];
                     i = i + 4;
                     pol +="("+num3+") ";
                     num.Push(Convert.ToDouble(num3));

                }
                 if (char.IsNumber(alg[i]) && alg[i + 1] == '(')
                 {
                     throw new Exception("Ошибка при вводе,проверьте вводимые значения...");
                 }
                 else if ( alg[i] == ')'&& char.IsNumber(alg[i+1]) )
                     {
                         throw new Exception("Ошибка при вводе,проверьте вводимые значения...");
                     }

                 while (char.IsNumber(alg[i]))
                 {
                     if (alg[i + 1] == ',' && f2 == true )
                     {
                         if (char.IsNumber(alg[i + 2]))
                         {
                             num2 += alg[i].ToString() + ",";
                             i = i + 2;
                             f2 = false;
                         }
                         else throw new Exception("Ошибка при вводе,проверьте вводимые значения...");
                     }
                     else
                         if (char.IsNumber(alg[i]))
                         {
                             num2 += alg[i].ToString();
                             i++;
                         }
                         //    else if (!char.IsNumber(alg[i+1]))
                         //{
                         //    pol += num2;
                         //    num.Push(Convert.ToDouble(num2));
                         //    i++;
                         //}
                         else throw new Exception("Ошибка при вводе,проверьте вводимые значения...");
                     // i++;
                     if (!char.IsNumber(alg[i]) && alg[i] != ',')
                     {
                         pol += num2 + " ";
                         num.Push(Convert.ToDouble(num2));
                     }
                 }
                 if (alg[i]==' ' && i!=alg.Length-1) // проверка на пробелы
                 {
                     i++;
                 }
                     if(alg[i]==','&&f2==false)
                         throw new Exception("Ошибка при вводе,проверьте вводимые значения...");
               //else if (char.IsNumber(alg[i])) // добавление 1-го значного числа
                     
               //  {
                     
               //      num.Push(Char.GetNumericValue(alg[i]));
               //      pol += num.Peek();
               //      i++;
               //  }
                     else if (alg[i]=='(' && alg[i+1]==')')
                     {
                         throw new Exception("Ошибка при вводе,проверьте вводимые значения...");
                     }
                     else if (alg[i] == ')' && alg[i + 1] == '(')
                     {
                         throw new Exception("Ошибка при вводе,проверьте вводимые значения...");
                     }
                     else
                         if (alg[i] == ')' && char.IsNumber(alg[i+1]))
                         {
                             throw new Exception("Ошибка при вводе,проверьте вводимые значения...");
                         }

                     
                 else if (alg[i] == '+' || alg[i] == '-' || alg[i] == '*' || alg[i] == '/' || alg[i] == '(' || alg[i] == ')' || alg[i] == ' ') // проверка на знаки
                 {
                     string obser= " (+-*/)";

                     int[,] mas = new int[,]  {{-1,1,1,1,1,1,-2},
                                               {-2,1,1,1,1,1,3},
                                               {4,1,2,2,1,1,4},
                                               {4,1,2,2,1,1,4},
                                               {4,1,4,4,2,2,4},
                                               {4,1,4,4,2,2,4}};
                    int a= obser.IndexOf(alg[i]);
                     if (con.Count==0)
                          b = 0;
                     else
                     b = obser.IndexOf(con.Peek());

                    switch (mas[b, a])
                    {
                        case -2:
                            throw new Exception("Ошибка при вводе,проверьте вводимые значения..."); 
                          
                        case -1:
                            if (num.Count == 1)
                          return num.Pop().ToString();
                            else
                                throw new Exception("Ошибка при вводе,проверьте вводимые значения..."); 
                        case 1:
                            con.Push(alg[i].ToString());
                            i++;
                            break;
                        case 2:
                            if (num.Count >= 2)
                            {
                                switch (con.Peek())
                                {
                                    case "+":
                                        pol += con.Pop();
                                        num.Push(num.Pop() + num.Pop());
                                        con.Push(alg[i].ToString());
                                        i++;
                                        break;
                                    case "-":
                                        pol += con.Pop();
                                        double op1 = num.Pop();
                                        num.Push(num.Pop() - op1);
                                        con.Push(alg[i].ToString());
                                        i++;
                                        break;
                                    case "*":
                                        pol += con.Pop();
                                        num.Push(num.Pop() * num.Pop());
                                        con.Push(alg[i].ToString());
                                        i++;
                                        break;
                                    case "/":
                                        pol += con.Pop();
                                        double op = num.Pop();
                                        num.Push(num.Pop() / op);
                                        con.Push(alg[i].ToString());
                                        i++;
                                        break;
                                        

                                }
                            }
                            else
                                throw new Exception("Ошибка при вводе,проверьте вводимые значения..."); 

                            break;
                        case 3:
                            if (con.Peek() != ")")
                            {
                                con.Pop();
                                i++;
                            }
                            else
                            { throw new Exception("Ошибка при вводе,проверьте вводимые значения..."); }
                            break;
                           
                        case 4:
                            if (num.Count>=2)
                            {
                                switch (con.Peek())
                                {
                                    case "+":
                                        pol += con.Pop();
                                        num.Push(num.Pop() + num.Pop());
                                        break;
                                    case "-":
                                        pol += con.Pop();
                                        double op1 = num.Pop();
                                        num.Push(num.Pop() - op1);
                                        break;
                                    case "*":
                                        pol += con.Pop();
                                        num.Push(num.Pop() * num.Pop());
                                        break;
                                    case "/":
                                        pol += con.Pop();
                                        
                                        double op = num.Pop();
                                        if(op!=0)
                                        num.Push(num.Pop() / op);
                                        else
                                            throw new Exception("Ошибка при вводе,проверьте вводимые значения..."); 

                                        break;
                                }
                                
                            }
                            else throw new Exception("Ошибка при вводе,проверьте вводимые значения..."); 
                            break;
                        default: throw new Exception("Ошибка при вводе,проверьте вводимые значения..."); 
                            
                    }
                 }
                 else if (char.IsLetter(alg[i])) //проверка на буквы..
                 {
                     throw new Exception("Ошибка при вводе,проверьте вводимые значения..."); 

                 }
                     else
                     {
                         throw new Exception("Ошибка при вводе,проверьте вводимые значения..."); 

                     }
             }

             return "";
         }
        public string Polski() // вывод польской записи
        {
            return pol;
        }

    }
}
