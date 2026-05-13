using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG72
{
    public class Fynkcya
    {
        /// <summary>
        /// Шифрует или дешифрует строку с использованием шифра ROT13.
        /// </summary>
        /// <param name="text">Исходная строка для обработки.</param>
        /// <returns>
        /// Строка, в которой латинские буквы смещены на 13 позиций. 
        /// Если строка пуста или равна null, возвращается исходное значение.
        /// </returns>
        /// <example>
        /// <code>
        /// string encrypted = fynkcya.Rot13("Hello"); // Возвращает "Uryyb"
        /// </code>
        /// </example>
        public static string Rot13(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            StringBuilder result = new StringBuilder(text.Length);

            foreach (char c in text)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    // Для заглавных букв
                    char shifted = (char)(c + 13);
                    if (shifted > 'Z')
                        shifted = (char)(shifted - 26);
                    result.Append(shifted);
                }
                else if (c >= 'a' && c <= 'z')
                {
                    // Для строчных букв
                    char shifted = (char)(c + 13);
                    if (shifted > 'z')
                        shifted = (char)(shifted - 26);
                    result.Append(shifted);
                }
                else
                {
                    // Неалфавитные символы оставляем без изменений
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
