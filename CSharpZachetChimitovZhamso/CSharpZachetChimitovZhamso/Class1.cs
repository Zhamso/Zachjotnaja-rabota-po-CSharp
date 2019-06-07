using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using BookIndex;

namespace CSharpZachetChimitovZhamso
{
    public class Class1
    {
        public static void Main()
        {
            ObservableCollection<Index> indices = new ObservableCollection<Index>();
            indices.CollectionChanged += Indices_CollectionChanged;

            //indices.Add(new Index("CIGIL", new List<int> { 1, 5, 6, 2, 6, 7, 12, 15, 17, 60 }));
            //indices.Add(new Index("TOP", new List<int> { 12, 52, 26, 22, 62, 27, 122, 15, 127, 620 }));
            //indices.Add(new Index("Paver", new List<int> { 10, 50, 56, 22, 46, 47, 112, 195, 167, 608 }));

            while (true)
            {
                Console.WriteLine("-=Предметный указатель=-");
                int nextOperation = PrintDialog(new List<string> {
                    "Загрузить указатель из файла",
                    "Напечатать предметный указатель",
                    "Сохранить в файл",
                    "Вывести номера страниц для определенного слова",
                    "Добавить слово",
                    "Удалить слово",
                    "Загрузка из XML",
                    "Сохранить в XML"
                });
                switch (nextOperation)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
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
