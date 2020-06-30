using System;
using System.Collections.Generic;

namespace Lab_1_NYSS
{
    class Notebook
    {
        static void Main(string[] args)
        {
            List<Note> notes = new List<Note>();
            int id = 0;//номер записи
            int pressedNum = 0;
            try
            {
                while (pressedNum >= 0)
                {
                    Console.WriteLine("Нажмите 1 для создания новой записи\n" +
                        "Нажмите 2 для редактирования записи\n" +
                        "Нажмите 3 для удаления записей\n" +
                        "Нажмите 4 для просмотра созданной учетной записи\n" +
                        "Нажмите 5 для просмотра всех созданных учетных записей списком\n" +
                        "Нажмите 0, чтобы выйти из программы.");
                    string input = Console.ReadLine();
                    if ((Int32.TryParse(input, out pressedNum)) && (pressedNum <= 5 || pressedNum >= 0))
                    {
                        switch (pressedNum)
                        {
                            case 1:
                                id++;
                                notes.Add(MakeNewNote(id));
                                break;
                            case 2:
                                Console.WriteLine("Выберите номер записи для редактирования: ");
                                for (int i = 0; i < notes.Count; i++)
                                {
                                    Console.WriteLine(notes[i].id + ". " + notes[i].Name);
                                }
                                int needId = int.Parse(Console.ReadLine());
                                for (int i = 0; i < notes.Count; i++)
                                {
                                    if (needId == notes[i].id)
                                    {
                                        Console.WriteLine("Поменять запись: " + notes[i].id + ". " + notes[i].Name);
                                        notes[i] = EditNote(notes[i]);
                                    }
                                }
                                break;
                            case 3:
                                Console.WriteLine("Впишите через запятую номера записей на удаление : ");
                                for (int i = 0; i < notes.Count; i++)
                                {
                                    Console.WriteLine(notes[i].id + ". " + notes[i].Name);
                                }
                                string needNums = Console.ReadLine();
                                string[] separators = { "," };
                                string[] needIds = needNums.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                                for (int j = 0; j < needIds.Length; j++)
                                {
                                    for (int i = 0; i < notes.Count; i++)
                                    {
                                        if (int.Parse(needIds[j]) == notes[i].id)
                                        {
                                            notes.RemoveAt(i);
                                        }
                                    }
                                }
                                break;
                            case 4:
                                if (notes.Count > 0)
                                {
                                    Console.WriteLine("Выберите номер записи, чтобы просмотреть информацию о ней.");
                                    Console.WriteLine("Список созданных записей:");
                                    for (int i = 0; i < notes.Count; i++)
                                    {
                                        Console.WriteLine(notes[i].id + ". " + notes[i].Name + notes[i].LastName);
                                    }
                                    int num = 0;
                                    string inputNum = Console.ReadLine();

                                    while (!(int.TryParse(inputNum, out num)) && num <= (notes.Count - 1) && num > 0)
                                    {
                                        Console.WriteLine("Неправильный номер или формат строки!!!");
                                    }
                                    ReadNote(notes[num - 1]);
                                }
                                else
                                {
                                    Console.WriteLine("Список пуст.");
                                }
                                break;
                            case 5:
                                if (notes.Count > 0)
                                {
                                    Console.WriteLine("Краткая информация по записям: ");
                                    for (int i = 0; i < notes.Count; i++)
                                    {
                                        Console.WriteLine($"{notes[i].id}." +
                                            $"\n{notes[i].LastName}" +
                                            $"\n{notes[i].Name}" +
                                            $"\n{notes[i].TelNum}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Список пуст.");
                                }
                                break;
                            case 0:
                                System.Environment.Exit(0);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неправильная цифра!!!");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ReadNote(Note note)
        {
            try
            {
                Console.WriteLine("Данные записи:");
                Console.WriteLine("Фамилия: ");
                Console.WriteLine(note.LastName);
                Console.WriteLine("Имя: ");
                Console.WriteLine(note.Name);
                Console.WriteLine("Отчество: ");
                Console.WriteLine(note.Patronymic);
                Console.WriteLine("Номер телефона: ");
                Console.WriteLine(note.TelNum);
                Console.WriteLine("Страна: ");
                Console.WriteLine(note.Country);
                Console.WriteLine("Дата рождения: ");
                if (!string.IsNullOrEmpty(note.DateofBirth.ToString()))
                {
                    Console.WriteLine(note.DateofBirth.ToString("dd MM yyyy г."));
                }
                else
                    Console.WriteLine("Не указано.");
                Console.WriteLine("Должность: ");
                Console.WriteLine(note.Profession);
                Console.WriteLine("Дополнительно: ");
                Console.WriteLine(note.Addition);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static Note EditNote(Note note)
        {
            try
            {
                Console.WriteLine("Данные записи:");
                Console.WriteLine("Фамилия: ");
                note.LastName = Console.ReadLine();
                Console.WriteLine("Имя: ");
                note.Name = Console.ReadLine();
                Console.WriteLine("Отчество(необязательно): ");
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                {
                    note.Patronymic = "Не указано.";
                }
                else
                    note.Patronymic = s;
                Console.WriteLine("Номер телефона(только цифры): ");
                int telNum = 0;

                while (!Int32.TryParse(Console.ReadLine(), out telNum))
                {
                    Console.WriteLine("Только цифры!!!");
                }
                note.TelNum = telNum;
                Console.WriteLine("Страна: ");
                note.Country = Console.ReadLine();
                Console.WriteLine("Дата рождения(необязательно): ");
                Console.WriteLine("Формат записи dd/MM/YYYY");
                DateTime iDate;
                string date = Console.ReadLine();
                if (!string.IsNullOrEmpty(date))
                {
                    while (!DateTime.TryParse(date, out iDate))
                    {
                        Console.WriteLine("Неправильный формат строки!!!");
                        date = Console.ReadLine();
                    }

                    note.DateofBirth = DateTime.Parse(date);
                }
                else
                {
                    Console.WriteLine("Не указано.");
                }
                Console.WriteLine("Должность(необязательно): ");
                string profString = Console.ReadLine();
                if (string.IsNullOrEmpty(profString))
                {
                    note.Profession = "Не указано.";
                }
                else
                    note.Profession = profString;
                Console.WriteLine("Дополнительно: ");
                note.Addition = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return note;
        }

        public static Note MakeNewNote(int id)
        {
            Note newNote = new Note();
            try
            {
                newNote.id = id;
                Console.WriteLine("Введите данные:");

                Console.WriteLine("Ваша фамилия: ");
                newNote.LastName = Console.ReadLine();


                Console.WriteLine("Ваше имя: ");
                newNote.Name = Console.ReadLine();


                Console.WriteLine("Ваше отчество(необязательно): ");
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                {
                    newNote.Patronymic = "Не указано.";
                }
                else
                    newNote.Patronymic = s;


                Console.WriteLine("Ваш номер телефона: ");
                int telNum = 0;

                while (!Int32.TryParse(Console.ReadLine(), out telNum))
                {
                    Console.WriteLine("Только цифры!!!");
                }
                newNote.TelNum = telNum;

                Console.WriteLine("Ваша страна: ");
                newNote.Country = Console.ReadLine();

                Console.WriteLine("Дата рождения(необязательно): ");
                Console.WriteLine("Формат записи dd/MM/YYYY");
                DateTime iDate;
                string date = Console.ReadLine();
                if (!string.IsNullOrEmpty(date))
                {
                    while (!DateTime.TryParse(date, out iDate))
                    {
                        Console.WriteLine("Неправильный формат строки!!!");
                        date = Console.ReadLine();
                    }

                    newNote.DateofBirth = DateTime.Parse(date);
                }
                else
                {
                    Console.WriteLine("Не указано.");
                }

                Console.WriteLine("Должность(необязательно): ");
                string profString = Console.ReadLine();
                if (string.IsNullOrEmpty(profString))
                {
                    newNote.Profession = "Не указано.";
                }
                else
                    newNote.Profession = profString;

                Console.WriteLine("Дополнительно: ");
                newNote.Addition = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newNote;
        }
        public class Note
        {
            public int id;
            private string lastname, name, patronomic, country, organization, profession, addition;
            private int telNum;
            DateTime dateofBirth;
            public string LastName
            {
                get
                {
                    return lastname;
                }
                set
                {
                    this.lastname = value;
                }

            }
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    this.name = value;
                }
            }
            public string Patronymic
            {
                get
                {
                    return patronomic;
                }
                set
                {
                    this.patronomic = value;
                }
            }
            public int TelNum
            {
                get
                {
                    return telNum;
                }
                set
                {
                    this.telNum = value;
                }
            }
            public string Country
            {
                get
                {
                    return country;
                }
                set
                {
                    this.country = value;
                }
            }
            public DateTime DateofBirth
            {
                get
                {
                    return dateofBirth;
                }
                set
                {
                    this.dateofBirth = value;
                }
            }
            public string Organization
            {
                get
                {
                    return organization;
                }
                set
                {
                    this.organization = value;
                }
            }
            public string Profession
            {
                get
                {
                    return profession;
                }
                set
                {
                    this.profession = value;
                }
            }
            public string Addition
            {
                get
                {
                    return addition;
                }
                set
                {
                    this.addition = value;
                }
            }
        }
    }
}
