# Практичска работа 7.2 : Приложение ROT13


Вариант: 12
Алгоритм: ROT13 (сдвиг Цезаря на 13, только латиница)

## 1. Анализ предметной области и требований

Предметная область: Криптография, симметричное шифрование.

Алгоритм ROT13:
Частный случай шифра Цезаря с фиксированным сдвигом 13.
Самодвойственность: ROT13(ROT13(text)) = text (шифрование = дешифрование).
- Работает только с буквами латинского алфавита (A-Z, a-z).
- Неалфавитные символы (цифры, знаки препинания, пробелы, кириллица) остаются без изменений.

Функциональные требования:
- Применение ROT13 к введённому тексту.
- Сохранение регистра букв (A→N, a→n).
- Игнорирование нелатинских символов.
- Валидация входных данных (обработка null и пустой строки).

Нефункциональные требования:
- Графический интерфейс (Windows Forms / WPF).
- Обработка исключений (не падать при любом вводе).

## 2. Диаграмма вариантов использования

В файле проекта.

## 3. Тестовые сценарии (до разработки)

Позитивные тесты:

| ID | Название | Входные данные (text) | Ожидаемый результат | Фактический результат | Статус |
|----|----------|----------------------|----------------------|----------------------|--------|
| 1 | Преобразование строчных букв | "abc" | "nop" | | |
| 2 | Преобразование заглавных букв | "ABC" | "NOP" | | |
| 3 | Самодвойственность | ROT13("hello") → "uryyb", затем ROT13("uryyb") | "hello" | | |
| 4 | Смешанный регистр | "AbC" | "NoP" | | |
| 5 | Неалфавитные символы (цифры) | "abc123" | "nop123" | | |
| 6 | Неалфавитные символы (пробелы) | "hello world" | "uryyb jbeyq" | | |
| 7 | Неалфавитные символы (знаки) | "hello!" | "uryyb!" | | |
| 8 | Кириллица | "привет" | "привет" | | |
| 9 | Смесь латиницы и кириллицы | "hello привет" | "uryyb привет" | | |
| 10 | Пустая строка | "" | "" | | |
| 11 | Длинный текст (1000+ символов) | "abc..." × 1000 | "nop..." × 1000 | | |
| 12 | Только нелатинские символы | "123 !@#" | "123 !@#" | | |

Негативные тесты (обработка исключений):

| ID | Название | Входные данные | Ожидаемый результат | Фактический результат | Статус |
|----|----------|----------------|----------------------|----------------------|--------|
| 13 | Null значение | null | Исключение или сообщение об ошибке (не падение приложения) | | |
| 14 | Пустая строка | "" | "" (корректная работа) | | |
| 15 | Только пробелы | "   " | "   " | | |

Тесты GUI и нефункциональные (проверяются вручную):

| ID | Название | Действие | Ожидаемый результат | Фактический результат | Статус |
|----|----------|----------|----------------------|----------------------|--------|
| 16 | Всплывающая подсказка | Навести курсор на поле ввода | Появляется ToolTip с пояснением | | |
| 17 | Кнопка "Очистить" (если есть) | Нажать | Поля ввода и результата очищаются | | |
| 18 | Кнопка "Копировать" (если есть) | Нажать | Результат копируется в буфер обмена | | |
| 19 | Обработка больших объёмов | Вставить 1 МБ текста | Преобразование выполняется без зависания | | |



## 4. Автоматизированные тесты (C#)

Реализованы в проекте `Rot13Tests`.


    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using static _72GGg.fynkcya;
    namespace UnitTestProject1
    {
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string text = "david is the best potato in the second world war";
            string text2 = "qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne";
            Assert.AreEqual(text, Rot13(text2));
        }
        [TestMethod]
        public void TestMethod2()
        {
            string text = "david is the best david in the second world war";
            string text2 = "qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne";
            Assert.AreNotEqual(text, Rot13(text2));
        }
        [TestMethod]
        public void TestMethod3()
        {
            string text = "       ";
            string text2 = "       ";
            Assert.AreEqual(text, Rot13(text2));

        }
        [TestMethod]
        public void TestMethod4()
        {
            string text = "david is the best potato in the second world war";
            string text2 = "qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne";
            Assert.AreEqual(text2, Rot13(text));

        }
        [TestMethod]
        public void TestMethod5()
        {
            string text = "david is the best david in the second world war";
            string text2 = "qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne";
            Assert.AreNotEqual(text2, Rot13(text));

        }
        [TestMethod]
        public void TestMethod6()
        {
            string text = "аксенова все увидит";
            string text2 = "аксенова все увидит";
            Assert.AreEqual(text, Rot13(text2));

        }
        [TestMethod]
        public void TestMethod7()
        {
            string text = "David";
            string expected = "Qnivq";
            Assert.AreEqual(expected, Rot13(text));
            Assert.AreEqual(text, Rot13(expected));
        }
        [TestMethod]
        public void TestMethod8()
        {
            string original = "Hello World";
            string once = Rot13(original);
            string twice = Rot13(once);
            Assert.AreEqual(original, twice);
        }
        [TestMethod]
        public void TestMethod9()
        {
            string text = "привет world";
            string expected = "привет jbeyq";
            Assert.AreEqual(expected, Rot13(text));
        }
        [TestMethod]
        public void TestMethod10()
        {
            string text = "hello, 123!";
            string expected = "uryyb, 123!";
            Assert.AreEqual(expected, Rot13(text));
        }
        [TestMethod]
        public void TestMethod11()
        {
            Assert.AreEqual("", Rot13(""));
        }
        [TestMethod]
        public void TestMethod12()
        {
            string text = "123!@# $%^";
            Assert.AreEqual(text, Rot13(text));
        }
        [TestMethod]
        public void TestMethod13()
        {
            string text = "DaViD";
            string expected = "QnIvQ";
            Assert.AreEqual(expected, Rot13(text));
        }
        [TestMethod]
        public void TestMethod14()
        {
            Assert.AreEqual('a', Rot13("n")[0]);   
            Assert.AreEqual('z', Rot13("m")[0]);   
            Assert.AreEqual('A', Rot13("N")[0]);
            Assert.AreEqual('Z', Rot13("M")[0]);
        }
        public void TestMethod15()
        {
            string longStr = new string('a', 10000);
            string encoded = Rot13(longStr);
            Assert.AreEqual(longStr.Length, encoded.Length);
            Assert.AreEqual('n', encoded[0]);
        }
        
      }
    }
## 5. Разработка приложения
В коде проекта программа.
Клонировать репризеторий:
Внутри фукции есть и шифоромание и дешифрование.

Графический интерфейс: WPF. 
Код задокументирован XML-комментариями.

