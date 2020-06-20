using System;
using System.Collections.Generic;

namespace Lab_1_NYSS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Note> notes = new List<Note>();
            int id = 0;//номер записи
            int pressedNum = 1;
            try
            {
                while (pressedNum > 0)
                {
                    Console.WriteLine("Нажмите 1 для создания новой записи\n" +
                        "Нажмите 2 для редактирования записи\n" +
                        "Нажмите 3 для удаления записей\n" +
                        "Нажмите 4 для просмотра созданных учетных записей\n" +
                        "Нажмите 5 для просмотра краткой информации всех созданных учетных записей\n" +
                        "Нажмите 0, чтобы выйти из программы.");
                    pressedNum = int.Parse(Console.ReadLine());
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
                                    notes[i] = EditNoteBook(notes[i]);
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
                                Console.WriteLine("Список созданных записей");
                                for (int i = 0; i < notes.Count; i++)
                                {

                                    Console.WriteLine(notes[i].id + ". " + notes[i].Name);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Список пуст.");
                            }
                            break;
                        case 5:
                            if (notes.Count > 0)
                            {
                                Console.WriteLine("Краткая информация по записям");
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
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static Note EditNoteBook(Note note)
        {
            try
            {
                Console.WriteLine("Данные записи:");
                Console.WriteLine("Фамилия: ");
                note.LastName = Console.ReadLine();
                Console.WriteLine("Имя: ");
                note.Name = Console.ReadLine();
                Console.WriteLine("Отчество(необязательно): ");
                note.Patronymic = Console.ReadLine();
                Console.WriteLine("Номер телефона(только цифры): ");
                note.TelNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Страна: ");
                note.Country = Console.ReadLine();
                Console.WriteLine("Дата рождения(необязательно): ");
                note.DateofBirth = Console.ReadLine();
                Console.WriteLine("Должность(необязательно): ");
                note.Profession = Console.ReadLine();
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
                newNote.Patronymic = Console.ReadLine();
                Console.WriteLine("Ваш номер телефона: ");
                newNote.TelNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Ваша страна: ");
                newNote.Country = Console.ReadLine();
                Console.WriteLine("Дата рождения(необязательно): ");
                newNote.DateofBirth = Console.ReadLine();
                Console.WriteLine("Должность(необязательно): ");
                newNote.Profession = Console.ReadLine();
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
            private string lastname, name, patronomic, country, dateofBirth, organization, profession, addition;
            private int telNum;
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
            public string DateofBirth
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
