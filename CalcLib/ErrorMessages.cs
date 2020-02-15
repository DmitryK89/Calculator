using System;
using System.Collections.Generic;
using System.Text;

namespace CalcLib
{
    public class ErrorMessages
    {
        public static readonly string mathOp_absent = "Математеческие операторы не найдены";
        public static readonly string mathOp_extra = "Обнаружен лишний математический оператор";
        public static readonly string mathOp_missed = "Пропущен математический оператор";

        public static readonly string double_conversion = "Одно из чисел введено неверно";
        public static readonly string digits_empty = "Числа не найдены";

        public static readonly string parentheses = "Количество открывающихся/закрывающихся скобок не совпадает";


        public static readonly string division_to_zero = "Деление на ноль недопустимо";
        public static readonly string empty_input = "Строка пустая";
    }
}
