using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using BookIndex;
using System.IO;

namespace CSharpZachetChimitovZhamso
{
    public class Class1
    {
        public static void Main()
        {
            ObservableCollection<Index> indices = new ObservableCollection<Index>();
            indices.CollectionChanged += Indices_CollectionChanged;

            indices.Add(new Index("CIGIL", new List<int> { 1, 5, 6, 2, 6, 7, 12, 15, 17, 60 }));
            indices.Add(new Index("TOP", new List<int> { 12, 52, 26, 22, 62, 27, 122, 15, 127, 620 }));
            indices.Add(new Index("Paver", new List<int> { 10, 50, 56, 22, 46, 47, 112, 195, 167, 608 }));
            indices.Add(new Index("Sad", new List<int> { 1, 5, 6, 2, 6, 7, 12, 15, 17, 60 }));
            indices.Add(new Index("Change", new List<int> { 12, 52, 26, 22, 62, 27, 122, 15, 127, 620 }));
            indices.Add(new Index("Japan", new List<int> { 10, 50, 56, 22, 46, 47, 112, 195, 167, 608 }));
            indices.Add(new Index("Port", new List<int> { 1, 5, 6, 2, 6, 7, 12, 15, 17, 60 }));
            indices.Add(new Index("Reol", new List<int> { 12, 52, 26, 22, 62, 27, 122, 15, 127, 620 }));
            indices.Add(new Index("Mystery", new List<int> { 10, 50, 56, 22, 46, 47, 112, 195, 167, 608 }));

            bool doCycle = true;
            while (doCycle)
            {
                Console.WriteLine();
                Console.WriteLine("-=Предметный указатель=-");
                int nextOperation = PrintDialog(new List<string>
                {
                    "Напечатать предметный указатель",
                    "Вывести номера страниц для определенного слова",
                    "Добавить слово",
                    "Удалить слово",
                    "Загрузка из XML",
                    "Сохранить в XML"
                });
                switch (nextOperation)
                {
                    case 1: //Напечатать предметный указатель
                        indices = new ObservableCollection<Index>(indices.OrderBy(R => R.Word));
                        foreach(Index index in indices)
                        {
                            index.PrintInfo();
                        }
                        break;
                    case 2: //Вывести номера страниц для определенного слова
                        Console.WriteLine("Введите искомое слово");
                        string FindedWord = Console.ReadLine().ToLower();
                        bool isFind = false;
                        foreach(Index index in indices)
                        {
                            if (index.Word.Equals(FindedWord))
                            {
                                index.PrintInfo();
                                isFind = true;
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            Console.WriteLine($"Слово {FindedWord} не найдено");
                        }
                        break;
                    case 3: //Добавить слово
                        Console.WriteLine("Введите слово которое вы хотите добавить");
                        string AddedWord = Console.ReadLine();
                        Console.WriteLine("Введите все номера страницы через пробел в одну строчку");
                        List<int> tempList = new List<int>();
                        string[] stringArray = Console.ReadLine().Split(' ');
                        foreach(string i in stringArray)
                        {
                            tempList.Add(Convert.ToInt32(i));
                        }
                        indices.Add(new Index(AddedWord, tempList));
                        break;
                    case 4: //Удалить слово
                        int n = 1;
                        Console.WriteLine("каким способом вы хотите удалить слово?");
                        int nextOperationTwo = PrintDialog(new List<string>
                        {
                            "Удалить через номер слова",
                            "Удалить через слово"
                        });
                        switch (nextOperationTwo)
                        {
                            case 1: //Удалить через номер слова
                                Console.WriteLine("Список слов с номерами");
                                foreach (Index index in indices)
                                {
                                    Console.Write(n++ + ") ");
                                    index.PrintInfo();
                                }
                                Console.WriteLine($"Введите номер удаляемого слова (1-{n - 1})");
                                int RemoveID = Convert.ToInt32(Console.ReadLine());
                                indices.RemoveAt(RemoveID - 1);
                                break;
                            case 2: //Удалить через слово
                                Console.WriteLine("Введите удаляемое слово");
                                string RemoveWord = Console.ReadLine().ToLower();
                                for(int i = 0; i < indices.Count; i++)
                                {
                                    if (indices.ElementAt(i).Word.Equals(RemoveWord))
                                    {
                                        indices.RemoveAt(i);
                                    }
                                }
                                break;
                        }
                        
                        break;
                    case 5: //Загрузка из XML
                        break;
                    case 6: //Сохранить в XML
                        break;
                    default:
                        Console.WriteLine("Выбран некорректный вариант, введите число от 1 до 8");
                        break;
                }
            }

            Console.Read();
        }

        public static void Indices_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Index newIndex = e.NewItems[0] as Index;
                    Console.WriteLine($"Добавлено новое слово \"{newIndex.Word}\" и {newIndex.Pages.Count} страниц(а) для него");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Index oldIndex = e.OldItems[0] as Index;
                    Console.WriteLine($"Удалено слово \"{oldIndex.Word}\"");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Index replacedIndex = e.OldItems[0] as Index;
                    Index replacingIndex = e.NewItems[0] as Index;
                    Console.WriteLine($"Слово \"{replacedIndex.Word}\" заменено словом \"{replacingIndex.Word}\"");
                    break;
            }
        }

        public static int PrintDialog(List<string> strings)
        {
            Console.WriteLine("Выберите вариант ответа");
            int i = 1;
            foreach(string str in strings)
            {
                Console.WriteLine($"{i++}) {str}");
            }
            string answer = Console.ReadLine();
            int answerInt = Convert.ToInt32(answer);
            return answerInt;
        }
    }
}
