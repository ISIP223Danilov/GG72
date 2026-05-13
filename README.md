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

## 3. Тестовые сценарии (до разработки)

### Позитивные тесты

| ID | Название | Входные данные | Ожидаемый результат | Фактический результат | Статус |
|----|----------|----------------|---------------------|----------------------|--------|
| TC-01 | Шифрование английского предложения | `"david is the best potato in the second world war"` | `"qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne"` | | |
| TC-02 | Дешифрование английского предложения | `"qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne"` | `"david is the best potato in the second world war"` | | |
| TC-03 | Самодвойственность ROT13 | `"Hello World"` → ROT13(ROT13(x)) | `"Hello World"` | | |
| TC-04 | Сохранение регистра (смешанный) | `"DaViD"` | `"QnIvQ"` | | |
| TC-05 | Сохранение регистра | `"David"` | `"Qnivq"` | | |
| TC-06 | Игнорирование цифр и знаков | `"hello, 123!"` | `"uryyb, 123!"` | | |
| TC-07 | Игнорирование спецсимволов | `"123!@# $%^"` | `"123!@# $%^"` | | |
| TC-08 | Кириллица без изменений | `"аксенова все увидит"` | `"аксенова все увидит"` | | |
| TC-09 | Смесь кириллицы и латиницы | `"привет world"` | `"привет jbeyq"` | | |
| TC-10 | Пустая строка | `""` | `""` | | |
| TC-11 | Строка из пробелов | `"       "` | `"       "` | | |
| TC-12 | Граничное значение: 'a' → 'n' | `'a'` | `'n'` | | |
| TC-14 | Граничное значение: 'z' → 'm' | `'z'` | `'m'` | | |
| TC-15 | Граничное значение: 'A' → 'N' | `'A'` | `'N'` | | |
| TC-16 | Граничное значение: 'Z' → 'M' | `'Z'` | `'M'` | | |

### Негативные тесты

| ID | Название | Входные данные | Ожидаемый результат | Фактический результат | Статус |
|----|----------|----------------|---------------------|----------------------|--------|
| TC-17 | Неравенство строк (позитивный тест на отрицание) | ROT13(`"david is the best david..."`) | ≠ `"qnivq vf gur orfg cbgngb..."` | | |
| TC-18 | Неравенство строк (обратный) | ROT13(`"qnivq vf gur orfg cbgngb..."`) | ≠ `"david is the best david..."` | | |
| TC-19 | Null значение | `null` | `""` (пустая строка) | | |

Тесты GUI и нефункциональные (проверяются вручную):

| ID | Название | Действие | Ожидаемый результат | Фактический результат | Статус |
|----|----------|----------|----------------------|----------------------|--------|
| 20 | Всплывающая подсказка | Навести курсор на поле ввода | Появляется ToolTip с пояснением | | |
| 21 | Кнопка "Очистить" (если есть) | Нажать | Поля ввода и результата очищаются | | |
| 22 | Кнопка "Копировать" (если есть) | Нажать | Результат копируется в буфер обмена | | |
| 23 | Обработка больших объёмов | Вставить 1 МБ текста | Преобразование выполняется без зависания | | |



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
Программа добавленна.

## 6. Отладка в Visual Studio

**Средства отладки:**
- Точки останова (Breakpoints)
- Окно "Локальные переменные" (Locals)
- Окно "Контрольные значения" (Watch)
- Немедленное окно (Immediate Window) для проверки выражений
- 
## 7. Автоматизированное тестирование


https://ctrlv.link/S8fN

<img width="624" height="316" alt="hgffgjh" src="https://github.com/user-attachments/assets/fbfe0b86-e6a4-4266-a0e1-57d30a73f6f1" />


## 8. Баг-репорт (автотестирование)
Багов необнаруженно.

## 9. Ручное тестирование нефункциональных требований

Тесты GUI и нефункциональные (проверяются вручную):

| ID | Название | Действие | Ожидаемый результат | Фактический результат | Статус |
|----|----------|----------|----------------------|----------------------|--------|
| 20 | Всплывающая подсказка | Навести курсор на кнопку шифрования и назжать| Появляется ToolTip с пояснением | Появлени окошка с рекомендацией | Успешно |
| 21 | Кнопка "Очистить" (если есть) | Нажать | Поля ввода и результата очищаются | Только через комбинации Ctrl;| нейтрально |
| 22 | Кнопка "Копировать" (если есть) | Нажать | Результат копируется в буфер обмена | Только через комбинации Ctrl;| нейтрально |
| 23 | Обработка больших объёмов | Вставить 1 МБ текста | Преобразование выполняется без зависания | Кодирует большой обьем | Успешно |

## 10. Баг-репорт (ручное тестирование)

Багов не обнаруженно

## 11. Итоговые тестовые сценарии (с результатами)

| ID | Название | Входные данные | Ожидаемый результат | Фактический результат | Статус |
|----|----------|----------------|---------------------|----------------------|--------|
| TC-01 | Шифрование английского предложения | `"david is the best potato in the second world war"` | `"qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne"` |  Шифрование `"qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne"` | Успешно|
| TC-02 | Дешифрование английского предложения | `"qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne"` | `"david is the best potato in the second world war"` | Дешифрование `"david is the best potato in the second world war"` | Успешно |
| TC-03 | Самодвойственность ROT13 | `"Hello World"` → ROT13(ROT13(x)) | "Hello World" | Самодвойственность| Успешно |
| TC-04 | Сохранение регистра (смешанный) | `"DaViD"` | `"QnIvQ"` | Регситр сохранен `"QnIvQ"` | Успешно |
| TC-05 | Сохранение регистра | `"David"` | `"Qnivq"` | Регситр сохранен `"Qnivq"` | Успешно |
| TC-06 | Игнорирование цифр и знаков | `"hello, 123!"` | `"uryyb, 123!"` | Игнорирование цифр и знаков `"uryyb, 123!"` | Успешно |
| TC-07 | Игнорирование спецсимволов | `"123!@# $%^"` | `"123!@# $%^"` | Игнорирование спецсимволов `"123!@# $%^"` | Успешно |
| TC-08 | Кириллица без изменений | `"аксенова все увидит"` | `"аксенова все увидит"` | Кириллица без изменений `"аксенова все увидит"` | Успешно |
| TC-09 | Смесь кириллицы и латиницы | `"привет world"` | `"привет jbeyq"` | Кириллица без изменений `"привет jbeyq"` | Успешно |
| TC-10 | Пустая строка | `""` | `"просоит ввести текст"` | просоит ввести текст | Успешно |
| TC-11 | Строка из пробелов | `"       "` | `"       "` |  Строка из пробелов | Успешно |
| TC-12 | Граничное значение: 'a' → 'n' | `'a'` | `'n'` | n | Успешно |
| TC-14 | Граничное значение: 'z' → 'm' | `'z'` | `'m'` | m | Успешно |
| TC-15 | Граничное значение: 'A' → 'N' | `'A'` | `'N'` | N | Успешно |
| TC-16 | Граничное значение: 'Z' → 'M' | `'Z'` | `'M'` | M | Успешно |

### Негативные тесты

| ID | Название | Входные данные | Ожидаемый результат | Фактический результат | Статус |
|----|----------|----------------|---------------------|----------------------|--------|
| TC-17 | Неравенство строк (позитивный тест на отрицание) | ROT13(`"david is the best david..."`) | ≠ `"qnivq vf gur orfg cbgngb..."` |  ≠ `"qnivq vf gur orfg cbgngb..."` | Успешно |
| TC-18 | Неравенство строк (обратный) | ROT13(`"qnivq vf gur orfg cbgngb..."`) | ≠ `"david is the best david..."` | ≠ `"david is the best david..."` | Успешно |
| TC-19 | Null значение | `null` | `""` (пустая строка) | Null значение | Успешно |

## 12. Выводы

В ходе работы были применены следующие виды и техники тестирования:
Функциональное тестирование (автотесты)
Нефункциональное тестирование (UI, эргономика)
TDD и Ручное тестирование (тесты до кода)
Негативное тестирование (некорректный ввод)
Отладкав Visual Studio

Все требования выполнены. Приложение работает стабильно, корректно обрабатывает ошибки.

