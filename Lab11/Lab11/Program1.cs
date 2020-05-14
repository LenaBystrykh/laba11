using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Lab10;

namespace Lab11
{
    class Program1
    {
        //доделать последний подсчет времени!!!
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            int choice = -1;
            while (choice != 4)
            {
                Console.WriteLine("1. Задание 1. Хеш-таблица");
                Console.WriteLine("2. Задание 2. Queue<T>");
                Console.WriteLine("3. Задание 3. Stack, Dictionary");
                Console.WriteLine("4. Выход");

                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 1 || choice > 4);
                }
                switch (choice)
                {
                    case 1:
                        Hashtable hashtable = new Hashtable();
                        MakeHashtable(hashtable);
                        MenuHashtable(hashtable);
                        break;
                    case 2:
                        Queue<Trial> myQueue = new Queue<Trial>();
                        MakeQueue(myQueue);
                        MenuQueue(myQueue);
                        break;
                    case 3:
                        Console.WriteLine("Введите длину коллекции");
                        int length = int.Parse(Console.ReadLine());
                        Stack<Test> StackTest = new Stack<Test>();
                        Stack<string> StackString = new Stack<string>();
                        Dictionary<Test, Test> DictTest = new Dictionary<Test, Test>();
                        Dictionary<string, Test> DictString = new Dictionary<string, Test>();
                        TestCollections collections = new TestCollections(length, out StackString, out StackTest, out DictTest, out DictString);
                        MenuStack(collections, StackTest, StackString, DictString, DictTest);
                        break;
                    case 4:
                        choice = 4;
                        break;
                }
            }
        }

        public static void MenuHashtable(Hashtable hashtable)
        {
            Console.WriteLine("Нажмите соответствующую цифру для выбора действия");
            int choice = -1;
            while (choice != 7)
            {
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Печать хеш-таблицы");
                Console.WriteLine("4. Найти элемент");
                Console.WriteLine("5. Выполнить клонирование");
                Console.WriteLine("6. Запросы");
                Console.WriteLine("7. Назад");
                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 1 || choice > 7);
                }
                switch (choice)
                {
                    case 1:
                        AddElement(hashtable);
                        break;
                    case 2:
                        DeleteElement(hashtable);
                        break;
                    case 3:
                        Print(hashtable);
                        break;
                    case 4:
                        Search(hashtable);
                        break;
                    case 5:
                        CloneTable(hashtable);
                        break;
                    case 6:
                        Tasks(hashtable);
                        break;
                    case 7:
                        Console.Clear();
                        choice = 7;
                        break;
                }
            }
        }
        public static void MakeHashtable(Hashtable hashtable)
        {
            Test t1 = new Test(17, 03, 6, 30);
            Test t2 = new Test(17, 03, 9, 30);
            Test t3 = new Test(17, 03, 2, 30);
            Exam e1 = new Exam(15, 02, 3, "Алгебра");
            Exam e2 = new Exam(18, 04, 8, "История");
            FinalExam f1 = new FinalExam(13, 11, 10, "Программирование", true);
            FinalExam f2 = new FinalExam(21, 05, 7, "Английский язык", false);
            Trial[] arr = { t1, e1, t2, f1, e2, f2, t3 };
            foreach (Trial tr in arr)
            {
                if (tr is FinalExam)
                {
                    FinalExam f = (FinalExam)tr;
                    hashtable.Add(f.key, f.value);
                }
                else
                {
                    if (tr is Exam)
                    {
                        Exam e = (Exam)tr;
                        hashtable.Add(e.key, e.value);
                    }
                    else
                    {
                        if (tr is Test)
                        {
                            Test t = (Test)tr;
                            hashtable.Add(t.key, t.value);
                        }
                    }
                }
            }
        }
        public static void Print(Hashtable hashtable)
        {
            if (hashtable == null)
            {
                Console.WriteLine("Таблица пустая");
                return;
            }
            foreach (DictionaryEntry de in hashtable)
            {
                if (de.Value.ToString().Contains("автомат"))
                {
                    Trial f = new FinalExam();
                    f.value = (string)de.Value;
                    f.key = (int)de.Key;
                    Console.WriteLine("Код: " + f.key + ". " + f.value);
                }
                else
                {
                    if (de.Value.ToString().Contains("экзамен"))
                    {
                        Trial e = new Exam();
                        e.value = (string)de.Value;
                        e.key = (int)de.Key;
                        Console.WriteLine("Код: " + e.key + ". " + e.value);
                    }
                    else
                    {
                        if (de.Value.ToString().Contains("тест"))
                        {
                            Trial t = new Test();
                            t.value = (string)de.Value;
                            t.key = (int)de.Key;
                            Console.WriteLine("Код: " + t.key + ". " + t.value);
                        }
                    }
                }
            }
        }
        public static void AddElement(Hashtable hashtable)
        {
            Console.WriteLine("Нажмите соответствующую цифру для выбора действия");
            int choice = -1;
            while (choice != 4)
            {
                Console.WriteLine("1. Добавить тест");
                Console.WriteLine("2. Добавить экзамен");
                Console.WriteLine("3. Добавить итоговый экзамен");
                Console.WriteLine("4. Назад");
                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 1 || choice > 4);
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите день проведения теста:");
                        int d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц проведения теста:");
                        int mo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите полученную оценку:");
                        int ma = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите количество вопросов в тесте:");
                        int n = int.Parse(Console.ReadLine());
                        Test t = new Test(d, mo, ma, n);
                        hashtable.Add(t.key, t.value);
                        Console.Clear();
                        Console.WriteLine("Элемент добавлен");
                        break;
                    case 2:
                        Console.WriteLine("Введите день проведения экзамена:");
                        d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц проведения экзамена:");
                        mo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите полученную оценку:");
                        ma = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите дисциплину:");
                        string s = Console.ReadLine();
                        Exam e = new Exam(d, mo, ma, s);
                        hashtable.Add(e.key, e.value);
                        Console.Clear();
                        Console.WriteLine("Элемент добавлен");
                        break;
                    case 3:
                        Console.WriteLine("Введите день проведения итогового экзамена:");
                        d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц проведения итогового экзамена:");
                        mo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите полученную оценку:");
                        ma = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите дисциплину:");
                        s = Console.ReadLine();
                        Console.WriteLine("Нажмите +, если предусмотрена возможность получения оценки автоматом");
                        bool a = false;
                        if (Console.ReadLine().Contains("+"))
                        {
                            a = true;
                        }
                        else
                        {
                            a = false;
                        }
                        FinalExam f = new FinalExam(d, mo, ma, s, a);
                        hashtable.Add(f.key, f.value);
                        Console.Clear();
                        Console.WriteLine("Элемент добавлен");
                        break;
                    case 4:
                        choice = 4;
                        break;
                }
            }
        }
        public static void DeleteElement(Hashtable hashtable)
        {
            Console.WriteLine("Введите код элемента, который необходимо удалить");
            int del = int.Parse(Console.ReadLine());
            if (hashtable.ContainsKey(del) == false) Console.WriteLine("Элемент с заданным ключом отсутствует");
            else
            {
                hashtable.Remove(del);
                Console.WriteLine("Элемент удалён");
            }
        }
        public static void Search(Hashtable hashtable)
        {
            Console.WriteLine("Введите код элемента, который необходимо найти");
            int del = int.Parse(Console.ReadLine());
            if (hashtable.ContainsKey(del) == false) Console.WriteLine("Элемент с заданным ключом отсутствует");
            else
            {
                Console.WriteLine(hashtable[del]);
            }
        }
        public static void CloneTable(Hashtable hashtable)
        {
            Hashtable cloneHashtable = hashtable.Clone() as Hashtable;

            Console.WriteLine("Клонируемая хеш-таблица:");
            Console.WriteLine();
            foreach (DictionaryEntry de in hashtable)
            {
                Console.WriteLine("Код: " + de.Key + ". " + de.Value);
            }
            Console.WriteLine();
            Console.WriteLine("Копия хеш-таблицы:");
            Console.WriteLine();
            
            foreach (DictionaryEntry de in cloneHashtable)
            {
                Console.WriteLine("Код: " + de.Key + ". " + de.Value);
            }
        }
        public static void Tasks(Hashtable hashtable)
        {
            Console.WriteLine("Нажмите соответствующую цифру для выбора действия");
            int choice = -1;
            while (choice != 4)
            {
                Console.WriteLine("1. Вывести количество тестов в хеш-таблице");
                Console.WriteLine("2. Напечатать все экзамены");
                Console.WriteLine("3. Напечатать все испытания, сданные на отлично");
                Console.WriteLine("4. Назад");
                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 1 || choice > 4);
                }
                switch (choice)
                {
                    case 1:
                        CountTests(hashtable);
                        break;
                    case 2:
                        PrintExams(hashtable);
                        break;
                    case 3:
                        Marks(hashtable);
                        break;
                    case 4:
                        break;
                }
            }
        }
        public static void CountTests(Hashtable hashtable)
        {
            int count = 0;
            //запрос 1: вывести количество тестов
            foreach (DictionaryEntry de in hashtable)
            {
                if (de.Value.ToString().Contains("тест"))
                {
                    count++;
                }
            }
            Console.WriteLine($"Количество тестов: {count}");
        }
        public static void PrintExams(Hashtable hashtable)
        {
            foreach (DictionaryEntry de in hashtable)
            {
                if (de.Value.ToString().Contains("экзамен"))
                {
                    Console.WriteLine("Код: " + de.Key + ". " + de.Value);
                }
            }
        }
        public static void Marks(Hashtable hashtable)
        {
            foreach (DictionaryEntry de in hashtable)
            {
                if (de.Value.ToString().Contains("Оценка: 8") || de.Value.ToString().Contains("Оценка: 9") || de.Value.ToString().Contains("Оценка: 10"))
                {
                    Console.WriteLine("Код: " + de.Key + ". " + de.Value);
                }
            }
        }


        public static void MenuQueue(Queue<Trial> myQueue)
        {
            int choice = -1;
            while (choice != 7)
            {
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Печать");
                Console.WriteLine("4. Найти элемент");
                Console.WriteLine("5. Выполнить клонирование");
                Console.WriteLine("6. Запросы");
                Console.WriteLine("7. Назад");
                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 1 || choice > 7);
                }
                switch (choice)
                {
                    case 1:
                        AddElement(myQueue);
                        break;
                    case 2:
                        myQueue.Dequeue();
                        Console.WriteLine("Элемент удален");
                        break;
                    case 3:
                        Print(myQueue);
                        break;
                    case 4:
                        Search(myQueue);
                        break;
                    case 5:
                        CloneQueue(myQueue);
                        break;
                    case 6:
                        Tasks(myQueue);
                        break;
                    case 7:
                        Console.Clear();
                        choice = 7;
                        break;
                }
            }
        }
        public static void MakeQueue(Queue<Trial> myQueue)
        {
            Test t1 = new Test(17, 03, 6, 30);
            Test t2 = new Test(17, 03, 9, 30);
            Test t3 = new Test(17, 03, 2, 30);
            Exam e1 = new Exam(15, 02, 3, "Алгебра");
            Exam e2 = new Exam(18, 04, 8, "История");
            FinalExam f1 = new FinalExam(13, 11, 10, "Программирование", true);
            FinalExam f2 = new FinalExam(21, 05, 7, "Английский язык", false);

            myQueue.Enqueue(t1);
            myQueue.Enqueue(t2);
            myQueue.Enqueue(t3);
            myQueue.Enqueue(e1);
            myQueue.Enqueue(e2);
            myQueue.Enqueue(f1);
            myQueue.Enqueue(f2);

            foreach (Trial tr in myQueue)
            {
                if (tr is FinalExam)
                {
                    FinalExam f = (FinalExam)tr;
                    Console.WriteLine(f.value);
                }
                else
                {
                    if (tr is Exam)
                    {
                        Exam e = (Exam)tr;
                        Console.WriteLine(e.value);
                    }
                    else
                    {
                        if (tr is Test)
                        {
                            Test t = (Test)tr;
                            Console.WriteLine(t.value);
                        }
                    }
                }
            }
        }
        public static void AddElement(Queue<Trial> myQueue)
        {
            Console.WriteLine("Нажмите соответствующую цифру для выбора действия");
            int choice = -1;
            while (choice != 4)
            {
                Console.WriteLine("1. Добавить тест");
                Console.WriteLine("2. Добавить экзамен");
                Console.WriteLine("3. Добавить итоговый экзамен");
                Console.WriteLine("4. Назад");
                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 1 || choice > 4);
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите день проведения теста:");
                        int d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц проведения теста:");
                        int mo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите полученную оценку:");
                        int ma = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите количество вопросов в тесте:");
                        int n = int.Parse(Console.ReadLine());
                        Test t = new Test(d, mo, ma, n);
                        myQueue.Enqueue(t);
                        Console.Clear();
                        Console.WriteLine("Элемент добавлен");
                        break;
                    case 2:
                        Console.WriteLine("Введите день проведения экзамена:");
                        d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц проведения экзамена:");
                        mo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите полученную оценку:");
                        ma = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите дисциплину:");
                        string s = Console.ReadLine();
                        Exam e = new Exam(d, mo, ma, s);
                        myQueue.Enqueue(e);
                        Console.Clear();
                        Console.WriteLine("Элемент добавлен");
                        break;
                    case 3:
                        Console.WriteLine("Введите день проведения итогового экзамена:");
                        d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц проведения итогового экзамена:");
                        mo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите полученную оценку:");
                        ma = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите дисциплину:");
                        s = Console.ReadLine();
                        Console.WriteLine("Нажмите +, если предусмотрена возможность получения оценки автоматом");
                        bool a = false;
                        if (Console.ReadLine().Contains("+"))
                        {
                            a = true;
                        }
                        else
                        {
                            a = false;
                        }
                        FinalExam f = new FinalExam(d, mo, ma, s, a);
                        myQueue.Enqueue(f);
                        Console.Clear();
                        Console.WriteLine("Элемент добавлен");
                        break;
                    case 4:
                        choice = 4;
                        break;
                }
            }
        }
        public static void Print(Queue<Trial> myQueue)
        {
            if (myQueue == null)
            {
                Console.WriteLine("Очередь пустая");
                return;
            }
            foreach (Trial tr in myQueue)
            {
                if (tr is FinalExam)
                {
                    FinalExam f = (FinalExam)tr;
                    Console.WriteLine(f.value);
                }
                else
                {
                    if (tr is Exam)
                    {
                        Exam e = (Exam)tr;
                        Console.WriteLine(e.value);
                    }
                    else
                    {
                        if (tr is Test)
                        {
                            Test t = (Test)tr;
                            Console.WriteLine(t.value);
                        }
                    }
                }
            }
        }
        public static void Search(Queue<Trial> myQueue)
        {
            int choice = -1;
            while (choice != 4)
            {
                Console.WriteLine("1. Найти тест");
                Console.WriteLine("2. Найти экзамен");
                Console.WriteLine("3. Найти итоговый экзамен");
                Console.WriteLine("4. Назад");
                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 1 || choice > 4);
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите день проведения теста:");
                        int d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц проведения теста:");
                        int mo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите полученную оценку:");
                        int ma = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите количество вопросов в тесте:");
                        int n = int.Parse(Console.ReadLine());
                        bool yes = myQueue.Contains(new Test(d,mo,ma,n));
                        if (yes == true) Console.WriteLine("Элемент найден");
                        else Console.WriteLine("Элемент не найден");
                            break;
                    case 2:
                        Console.WriteLine("Введите день проведения экзамена:");
                        d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц проведения экзамена:");
                        mo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите полученную оценку:");
                        ma = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите дисциплину:");
                        string s = Console.ReadLine();
                        yes = myQueue.Contains(new Exam(d,mo,ma,s));
                        if (yes == true) Console.WriteLine("Элемент найден");
                        else Console.WriteLine("Элемент не найден");
                        break;
                    case 3:
                        Console.WriteLine("Введите день проведения итогового экзамена:");
                        d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц проведения итогового экзамена:");
                        mo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите полученную оценку:");
                        ma = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите дисциплину:");
                        s = Console.ReadLine();
                        Console.WriteLine("Нажмите +, если предусмотрена возможность получения оценки автоматом");
                        bool a = false;
                        if (Console.ReadLine().Contains("+"))
                        {
                            a = true;
                        }
                        else
                        {
                            a = false;
                        }
                        yes = myQueue.Contains(new FinalExam(d, mo, ma, s, a));
                        if (yes == true) Console.WriteLine("Элемент найден");
                        else Console.WriteLine("Элемент не найден");
                        break;
                    case 4:
                        choice = 4;
                        break;
                }
            }
        }
        public static void CloneQueue(Queue<Trial> myQueue)
        {
            Queue<Trial> cloneQueue = new Queue<Trial>();
            foreach (Trial tr in myQueue)
            {
                if (tr is FinalExam)
                {
                    FinalExam f = (FinalExam)tr;
                    cloneQueue.Enqueue((Trial)f.Clone());
                }
                else
                {
                    if (tr is Exam)
                    {
                        Exam e = (Exam)tr;
                        cloneQueue.Enqueue((Trial)e.Clone());
                    }
                    else
                    {
                        if (tr is Test)
                        {
                            Test t = (Test)tr;
                            cloneQueue.Enqueue((Trial)t.Clone());
                        }
                    }
                }
            }
            Print(cloneQueue);
        }
        public static void Tasks(Queue<Trial> myQueue)
        {
            Console.WriteLine("Нажмите соответствующую цифру для выбора действия");
            int choice = -1;
            while (choice != 4)
            {
                Console.WriteLine("1. Вывести количество тестов в очереди");
                Console.WriteLine("2. Напечатать все экзамены");
                Console.WriteLine("3. Напечатать все испытания, сданные на отлично");
                Console.WriteLine("4. Назад");
                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 1 || choice > 4);
                }
                switch (choice)
                {
                    case 1:
                        CountTests(myQueue);
                        break;
                    case 2:
                        PrintExams(myQueue);
                        break;
                    case 3:
                        Marks(myQueue);
                        break;
                    case 4:
                        break;
                }
            }
        }
        public static void CountTests(Queue<Trial> myQueue)
        {
            int count = 0;
            foreach (Trial tr in myQueue)
            {
                if (tr is Test)
                    count++;
            }
            Console.WriteLine($"Количество тестов: {count}");
        }
        public static void PrintExams(Queue<Trial> myQueue)
        {
            foreach (Trial tr in myQueue)
            {
                if ((!(tr is FinalExam)) && (tr is Exam))
                {
                    Exam e = (Exam)tr;
                    Console.WriteLine(e.value);
                }
            }
        }
        public static void Marks(Queue<Trial> myQueue)
        {
            foreach (Trial tr in myQueue)
            {
                if (tr.value.Contains("Оценка: 8") || tr.value.Contains("Оценка: 9") || tr.value.Contains("Оценка: 10"))
                {
                    if (tr is FinalExam)
                    {
                        FinalExam f = (FinalExam)tr;
                        Console.WriteLine(f.value);
                    }
                    else
                    {
                        if (tr is Exam)
                        {
                            Exam e = (Exam)tr;
                            Console.WriteLine(e.value);
                        }
                        else
                        {
                            if (tr is Test)
                            {
                                Test t = (Test)tr;
                                Console.WriteLine(t.value);
                            }
                        }
                    }
                }
            }
        }

        public static void MenuStack(TestCollections collections, Stack<Test> StackTest, Stack<string> StackString, Dictionary<string, Test> DictString, Dictionary<Test, Test> DictTest)
        {
            int choice = -1;
            while (choice != 5)
            {
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Печать");
                Console.WriteLine("4. Измерение времени поиска");
                Console.WriteLine("5. Назад");
                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 1 || choice > 5);
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите ключ");
                        string key = Console.ReadLine();
                        if (StackString.Contains(key))
                        {
                            Console.WriteLine("Данный ключ уже существует. Попробуйте ещё раз");
                            key = Console.ReadLine();
                        } while (StackString.Contains(key));
                        Random r = new Random();
                        int d = r.Next(1, 30);
                        int mo = r.Next(1, 12);
                        int ma = r.Next(1, 10);
                        int n = r.Next(1, 100);
                        int d1 = r.Next(1, 30);
                        int mo1 = r.Next(1, 12);
                        int ma1 = r.Next(1, 10);
                        int n1 = r.Next(1, 100);
                        collections.AddElement(key, new Test(d1, mo1, ma1, n1), new Test(d, mo, ma, n), StackString, StackTest, DictTest, DictString);
                        break;
                    case 2:
                        collections.DeleteElement(StackString, StackTest, DictString, DictTest);
                        break;
                    case 3:
                        collections.Print(StackTest, DictString);
                        break;
                    case 4:
                        collections.Time(StackString, StackTest, DictTest, DictString);
                        break;
                    case 5:
                        Console.Clear();
                        choice = 5;
                        break;
                }
            }

        }

        public class TestCollections
        {
            public Stack<Test> StackTest;
            public Stack<string> StackString;
            public Dictionary<Test, Test> DictTest;
            public Dictionary<string, Test> DictString;

            public int Length;

            public TestCollections(int length, out Stack<string> StackString, out Stack<Test> StackTest,
                out Dictionary<Test,Test> DictTest, out Dictionary<string, Test> DictString)
            {
                StackTest = new Stack<Test>();
                StackString = new Stack<string>();
                DictTest = new Dictionary<Test, Test>();
                DictString = new Dictionary<string, Test>();

                Length = length;

                Random r = new Random();
                for (int i = 0; i < Length; i++)
                {
                    int d = r.Next(1, 30);
                    int mo = r.Next(1, 12);
                    int ma = r.Next(1, 10);
                    int n = r.Next(1, 100);
                    Test t = new Test(d, mo, ma, n);
                    Console.WriteLine(t.value);

                    string tmpString = i.ToString();

                    StackString.Push(tmpString);
                    StackTest.Push(t);

                    int d1 = r.Next(1, 30);
                    int mo1= r.Next(1, 12);
                    int ma1 = r.Next(1, 10);
                    int n1 = r.Next(1, 100);
                    Test tmp = new Test(d1, mo1, ma1, n1);
                    Console.WriteLine(tmp.value);

                    DictString.Add(tmpString, tmp);
                    DictTest.Add(t, tmp);
                }
            }

            public void AddElement(string key, Test tKey, Test tValue, Stack<string> StackString, Stack<Test> StackTest,
                Dictionary<Test, Test> DictTest, Dictionary<string, Test> DictString)
            {
                if (!StackString.Contains(key) && !StackTest.Contains(tKey))
                {
                    Length += 1;

                    StackString.Push(key);
                    StackTest.Push(tKey);

                    DictTest.Add(tKey, tValue);
                    DictString.Add(key, tValue);
                }
                else
                {
                    throw new Exception("Duplicate key. It's must be unique.");
                }
            }

            public void DeleteElement(Stack<string> StackString, Stack<Test> StackTest, Dictionary<string, Test> DictString, Dictionary<Test, Test> DictTest)
            {
                StackString.Pop();
                StackTest.Pop();
                Console.WriteLine("Элемент удалён из стека");
                Console.WriteLine("Введите ключ для удаления из словаря");
                string key = Console.ReadLine();
                if (!DictString.ContainsKey(key))
                {
                    key = Console.ReadLine();
                } while (!DictString.ContainsKey(key));

                DictString.Remove(key);
                Console.WriteLine("Элемент удалён из словаря");
            }

            public void Print(Stack<Test> StackTest, Dictionary<string, Test> DictString)
            {
                Console.Clear();
                foreach(Test t in StackTest)
                {
                    Test newT = new Test(t.Day, t.Month, t.Mark, t.NumberOfQuestions);
                    Console.WriteLine(newT.value);
                }
                foreach (KeyValuePair<string, Test> item in DictString)
                {
                    Console.Write(item.Key + ": ");
                    Console.WriteLine((item.Value).value);
                }
            }

            public void Time(Stack<string> StackString, Stack<Test> StackTest,
                Dictionary<Test, Test> DictTest, Dictionary<string, Test> DictString)
            {
                string[] arr = StackString.ToArray();
                Stopwatch stopwatch = new Stopwatch();
                var cont = false;
                stopwatch.Start();
                cont = StackString.Contains(arr[0]);
                cont = StackString.Contains(arr[arr.Length - 1]);
                cont = StackString.Contains(arr[arr.Length % 2]);
                cont = StackString.Contains("*ао,в");
                stopwatch.Stop();
                long ticks = stopwatch.ElapsedTicks;
                Console.WriteLine("Время, затраченное на поиск 1, последнего, среднего и несуществующего " +
                    "элемента в коллекции Stack<string>: " + ticks.ToString() + " тиков");

                Test[] tests = StackTest.ToArray();
                stopwatch = new Stopwatch();
                stopwatch.Start();
                cont = StackTest.Contains(tests[0]);
                cont = StackTest.Contains(tests[tests.Length - 1]);
                cont = StackTest.Contains(tests[tests.Length % 2]);
                cont = StackTest.Contains(new Test(500,500,500,500));
                stopwatch.Stop();
                ticks = stopwatch.ElapsedTicks;
                Console.WriteLine("Время, затраченное на поиск 1, последнего, среднего и несуществующего " +
                    "элемента в коллекции Stack<Test>: " + ticks.ToString() + " тиков");

                Console.WriteLine("Введите ключ");
                string key = Console.ReadLine();
                stopwatch = new Stopwatch();
                stopwatch.Start();
                cont = DictString.ContainsKey(key);
                stopwatch.Stop();
                ticks = stopwatch.ElapsedTicks;
                Console.WriteLine("Время, затраченное на поиск элемента по ключу в коллекции " +
                    "Dictionary<string>: " + ticks.ToString() + " тиков");

                KeyValuePair<Test, Test>[] mas = DictTest.ToArray();
                Test t = new Test();
                if (int.Parse(key) <= mas.Length)
                {
                    //содержится
                    int d = mas[int.Parse(key)].Value.Day;
                    int mo = mas[int.Parse(key)].Value.Month;
                    int ma = mas[int.Parse(key)].Value.Mark;
                    int n = mas[int.Parse(key)].Value.NumberOfQuestions;
                    t = new Test(d, mo, ma, n);
                }
                stopwatch = new Stopwatch();
                stopwatch.Start();
                cont = DictTest.ContainsKey(t);
                stopwatch.Stop();
                ticks = stopwatch.ElapsedTicks;
                Console.WriteLine("Время, затраченное на поиск элемента по ключу в коллекции " +
                    "Dictionary<Test, Test>: " + ticks.ToString() + " тиков");


                Console.WriteLine("Введите день теста");
                int userday = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите месяц теста");
                int usermonth = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите полученную оценку");
                int usermark = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите количество вопросов");
                int usernumber = int.Parse(Console.ReadLine());
                Test tKey = new Test(userday, usermonth, usermark, usernumber);
                stopwatch = new Stopwatch();
                stopwatch.Start();
                cont = DictTest.ContainsValue(tKey);
                stopwatch.Stop();
                ticks = stopwatch.ElapsedTicks;
                Console.WriteLine("Время, затраченное на поиск элемента по значению в коллекции " +
                    "Dictionary<Test, Test>: " + ticks.ToString() + " тиков");
                if (cont == true) Console.WriteLine("Элемент найден");
                else Console.WriteLine("Элемент не найден");
            }
        }
    }
}
