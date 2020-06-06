using System;
using System.Collections.Generic;

namespace OOP_Lab_4_2
{
    class Book
    {
        public string author;
        public string name;
        public string edition;
        public int year;
        public int amount;
        public Book(string Author, string Name, string Edition, int Year, int Amount)
        {
            author = Author;
            name = Name;
            edition = Edition;
            year = Year;
            amount = Amount;
        }
    }

    class Program
    {
        static void groupByYear(Book[] books)
        {
            int tempYear, tempAmount;
            string tempAuthor, tempName, tempEdition;
            for (int i = 0; i < books.Length - 1; i++)
            {
                for (int j = i + 1; j < books.Length; j++)
                {
                    if (books[i].year > books[j].year)
                    {
                        tempYear = books[i].year;
                        books[i].year = books[j].year;
                        books[j].year = tempYear;

                        tempAuthor = books[i].author;
                        books[i].author = books[j].author;
                        books[j].author = tempAuthor;

                        tempName = books[i].name;
                        books[i].name = books[j].name;
                        books[j].name = tempName;

                        tempEdition = books[i].edition;
                        books[i].edition = books[j].edition;
                        books[j].edition = tempEdition;

                        tempAmount = books[i].amount;
                        books[i].amount = books[j].amount;
                        books[j].amount = tempAmount;
                    }
                }
            }
            Console.WriteLine("+----------------------+------------------------------------------+---------------------------+------+-----------+");
            Console.WriteLine("|     Автор книги      |                Назва книги               |          Видання          | Рiк  | Кiлькiсть |");
            Console.WriteLine("+----------------------+------------------------------------------+---------------------------+------+-----------+");
            foreach (Book item in books)
            {
                Console.WriteLine(String.Format("| {0,-20} | {1,-40} | {2,-25} | {3,-4} | {4,-9} |", item.author, item.name, item.edition, item.year, item.amount));
            }
            Console.WriteLine("+----------------------+------------------------------------------+---------------------------+------+-----------+");

        }

        static void countAmount(Book[] books)
        {
            Console.WriteLine("+------+-----------+");
            Console.WriteLine("| Рiк  | Кiлькiсть |");
            Console.WriteLine("+------+-----------+");

            Dictionary<int, int> Count = new Dictionary<int, int>();
            for (int i = 0; i < books.Length; i++)
            {
                for (int j = i; j < books.Length; j++)
                {
                    if (books[i].year != books[j].year)
                    {
                        int a = 0;
                        for (int k = i; k < j; k++)
                        {
                            a += books[k].amount;
                        }
                        Count.Add(books[i].year, a);
                        i = j - 1;

                        break;
                    }
                    if (j == books.Length - 1)
                    {
                        int a = 0;
                        for (int k = i; k < j + 1; k++)
                        {
                            a += books[k].amount;
                        }
                        Count.Add(books[i].year, a);
                        i = j;
                    }
                }
            }

            foreach (KeyValuePair<int, int> keyValue in Count)
            {
                Console.WriteLine(String.Format("| {0,-4} | {1,-9} |", keyValue.Key, keyValue.Value));
            }
            Console.WriteLine("+------+-----------+");
        }

        static void Main(string[] args)
        {
            Book b1 = new Book("Лiор Даян", "Люди волiють тонути в морi", "Темпора", 2015, 10);
            Book b2 = new Book("Анджей Сапковський", "Вiдьмак. Останнє бажання. Книга 1", "Клуб Сiмейного Дозвiлля", 2016, 8);
            Book b3 = new Book("Джоан К. Ролiнг", "Гаррi Поттер i напiвкровний принц", "А-ба-ба-га-ла-ма-га", 2013, 15);
            Book b4 = new Book("Роберт Грiн", "48 законiв влади", "Клуб Сiмейного Дозвiлля", 2017, 3);
            Book b5 = new Book("Марк Гудмен", "Злочини майбутнього", "Фабула", 2018, 25);
            Book b6 = new Book("Микола Гоголь", "Тарас Бульба. Iлюстроване видання", "А-ба-ба-га-ла-ма-га", 2018, 7);
            Book b7 = new Book("Сильвiя Плат", "Пiд скляним ковпаком", "Видавництво Старого Лева", 2017, 5);
            Book b8 = new Book("Михайло Пантич", "Прогулянка хмарами", "Темпора", 2013, 10);
            Book b9 = new Book("Сашко Дерманський", "Чудове чудовисько i погане поганисько", "А-ба-ба-га-ла-ма-га", 2015, 30);
            Book b10 = new Book("Оксана Демченко", "Моя казкотерапiя. Запаслива бiлочка", "Кенгуру", 2018, 2);

            Book[] Books = new Book[10];
            Books[0] = b1;
            Books[1] = b2;
            Books[2] = b3;
            Books[3] = b4;
            Books[4] = b5;
            Books[5] = b6;
            Books[6] = b7;
            Books[7] = b8;
            Books[8] = b9;
            Books[9] = b10;

            groupByYear(Books);
            countAmount(Books);
        }
    }
}
