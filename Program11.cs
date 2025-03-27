using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Dynamic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Configuration;

namespace ConsoleApp14
{
    public class Row : IComparable<Row> // <- Interface!!!
    {
        public int hours;
        public int minutes;
        public string subject;
        public string classroom;
        public string teachersname;
        public int difficulty = 0;
        public Row(int hours, int minutes, string subject, string classroom, string teachersname, int difficulty)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.subject = subject;
            this.classroom = classroom;
            this.teachersname = teachersname;
            this.difficulty = difficulty;
        }
        public int CompareTo(Row row)
        {
            return difficulty.CompareTo(row.difficulty);
        }
    }
    public class Day
    {
        public List<int> Alltime = new List<int>();
        public List <Row> AllRows = new List <Row>();
        public void AddRow()
        {
            Console.WriteLine("Please, enter the time of the lesson in format HH:MM");
            Console.WriteLine();
            int hours;
            int minutes;
            while (true)
            {
                string timeinput = Console.ReadLine();
                if (((int.TryParse((timeinput[0].ToString() + timeinput[1].ToString()), out hours)) || ((timeinput[0] == '0') && (int.TryParse(timeinput[1].ToString(), out hours)))) && ((int.TryParse((timeinput[3].ToString() + timeinput[4].ToString()), out minutes)) || ((timeinput[3] == '0') && (int.TryParse(timeinput[4].ToString(), out minutes)))) && (timeinput[2] == ':') && (timeinput.Length == 5))
                {
                    if (hours < 24 && minutes < 60)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Time format is incorrect!");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Time format is incorrect!");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Please, enter the subject of the lesson");
            Console.WriteLine();
            string subject = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please, enter the classroom");
            Console.WriteLine();
            string classroom = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please, enter the teachers name");
            Console.WriteLine();
            string teachersname = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please, enter the difficulty of the lesson, 0 to 10");
            Console.WriteLine();
            int difficulty;
            while (true)
            {
                string diffinput = Console.ReadLine();
                if (int.TryParse(diffinput, out difficulty))
                {
                    if (difficulty >= 0 && difficulty <= 10)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wrong.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Wrong.");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Row newrow = new Row(hours, minutes, subject, classroom, teachersname, difficulty);
            int index = Alltime.BinarySearch(hours * 60 + minutes);
            if (index < 0)
            {
                index = ~index;
            }
            Alltime.Insert(index, (hours * 60 + minutes));
            AllRows.Insert(index, newrow);
            Console.WriteLine("Lesson added successfully");
            Console.WriteLine();
        }
        public void AddRowKNOWNPARAMETERS(int hours, int minutes, string subject, string classroom, string teachersname, int difficulty)
        {
            Row newrow = new Row(hours, minutes, subject, classroom, teachersname, difficulty);
            int index = Alltime.BinarySearch(hours * 60 + minutes);
            if (index < 0)
            {
                index = ~index;
            }
            Alltime.Insert(index, (hours * 60 + minutes));
            AllRows.Insert(index, newrow);
        }
        public void PrintRows()
        {
            if (AllRows.Count != 0)
            {
                foreach (Row row in AllRows)
                {
                    Console.Write($"Lesson number: {AllRows.IndexOf(row) + 1}    ");
                    if (row.hours < 10 && row.minutes < 10)
                    {
                        Console.Write($"Time: 0{row.hours}:0{row.minutes}    ");
                    }
                    else if (row.hours < 10 && row.minutes >= 10)
                    {
                        Console.Write($"Time: 0{row.hours}:{row.minutes}    ");
                    }
                    else if (row.hours >= 10 && row.minutes < 10)
                    {
                        Console.Write($"Time: {row.hours}:0{row.minutes}    ");
                    }
                    else
                    {
                        Console.Write($"Time: {row.hours}:{row.minutes}    ");
                    }
                    Console.Write($"Subject: {row.subject}    ");
                    Console.Write($"Classroom: {row.classroom}    ");
                    Console.Write($"Teachers name: {row.teachersname}    ");
                    Console.Write($"Difficulty rating: {row.difficulty}\n");
                }
            }
            else
            {
                Console.WriteLine("Nothing planned yet.");
            }
        }
        public void PrintRowsByDifficulty()
        {
            if (AllRows.Count != 0)
            {
                var original = AllRows.Select((item, index) => new { item, index }).ToList();
                AllRows.Sort();
                foreach (Row row in AllRows)
                {
                    Console.Write($"Lesson number: {AllRows.IndexOf(row) + 1}    ");
                    if (row.hours < 10 && row.minutes < 10)
                    {
                        Console.Write($"Time: 0{row.hours}:0{row.minutes}    ");
                    }
                    else if (row.hours < 10 && row.minutes >= 10)
                    {
                        Console.Write($"Time: 0{row.hours}:{row.minutes}    ");
                    }
                    else if (row.hours >= 10 && row.minutes < 10)
                    {
                        Console.Write($"Time: {row.hours}:0{row.minutes}    ");
                    }
                    else
                    {
                        Console.Write($"Time: {row.hours}:{row.minutes}    ");
                    }
                    Console.Write($"Subject: {row.subject}    ");
                    Console.Write($"Classroom: {row.classroom}    ");
                    Console.Write($"Teachers name: {row.teachersname}    ");
                    Console.Write($"Difficulty rating: {row.difficulty}\n");
                }
                AllRows = original.OrderBy(x => x.index).Select(x => x.item).ToList();
            }
            else
            {
                Console.WriteLine("Nothing planned yet.");
            }
        }
        public void RemoveRow()
        {
            Console.WriteLine();
            Console.WriteLine("Which lesson do you want to remove?");
            Console.WriteLine();
            int lessonnum;
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine();
                if (int.TryParse(input, out lessonnum))
                {
                    if (lessonnum > this.AllRows.Count || lessonnum == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Unvalid lesson number");
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Unvalid lesson number");
                    Console.WriteLine();
                }
            }
            AllRows.RemoveAt(lessonnum - 1);
            Alltime.RemoveAt(lessonnum - 1);
            Console.WriteLine();
            Console.WriteLine("Lesson removed successfully");
            Console.WriteLine();

        }
        public void ChangeRow()
        {
            Console.WriteLine();
            Console.WriteLine("Which lesson do you want to change?");
            Console.WriteLine();
            int lessonnum;
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine();
                if (int.TryParse(input, out lessonnum))
                {
                    if (lessonnum > this.AllRows.Count || lessonnum == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Unvalid lesson number");
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Unvalid lesson number");
                    Console.WriteLine();
                }
            }
            AllRows.RemoveAt(lessonnum - 1);
            Alltime.RemoveAt(lessonnum - 1);
            this.AddRow();
        }
    }
    public static class Week
    {
        public static Day monday = new Day();
        public static Day tuesday = new Day();
        public static Day wednesday = new Day();
        public static Day thursday = new Day();
        public static Day friday = new Day();
        public static Day saturday = new Day();
        public static Day sunday = new Day();
        public static void ReturnWeek()
        {
            Console.WriteLine();
            Console.WriteLine("Monday");
            monday.PrintRows();
            Console.WriteLine("Tuesday");
            tuesday.PrintRows();
            Console.WriteLine("Wednesday");
            wednesday.PrintRows();
            Console.WriteLine("Thursday");
            thursday.PrintRows();
            Console.WriteLine("Friday");
            friday.PrintRows();
            Console.WriteLine("Saturday");
            saturday.PrintRows();
            Console.WriteLine("Sunday");
            sunday.PrintRows();
            Console.WriteLine();
        }
        public static void ReturnDifficultWeek()
        {
            Console.WriteLine();
            Console.WriteLine("Monday");
            monday.PrintRowsByDifficulty();
            Console.WriteLine("Tuesday");
            tuesday.PrintRowsByDifficulty();
            Console.WriteLine("Wednesday");
            wednesday.PrintRowsByDifficulty();
            Console.WriteLine("Thursday");
            thursday.PrintRowsByDifficulty();
            Console.WriteLine("Friday");
            friday.PrintRowsByDifficulty();
            Console.WriteLine("Saturday");
            saturday.PrintRowsByDifficulty();
            Console.WriteLine("Sunday");
            sunday.PrintRowsByDifficulty();
            Console.WriteLine();
        }
    }
    internal class Program11
    {
        public static Day GetDay()
        {
            Console.WriteLine();
            Console.WriteLine("In what day?");
            Console.WriteLine();
            string day;
            while (true)
            {
                string dayinput = Console.ReadLine();
                Console.WriteLine();
                if (dayinput.ToLower() == "monday" || dayinput.ToLower() == "tuesday" || dayinput.ToLower() == "wednesday" || dayinput.ToLower() == "thursday" || dayinput.ToLower() == "friday" || dayinput.ToLower() == "saturday" || dayinput.ToLower() == "sunday")
                {
                    day = dayinput.ToLower();
                    break;
                }
                else
                {
                    Console.WriteLine("Day of the week format is incorrect!");
                    Console.WriteLine();
                }
            }
            FieldInfo fieldInfo = typeof(Week).GetField(day, BindingFlags.Static | BindingFlags.Public);
            Day field = (Day)fieldInfo.GetValue(null);
            return field;
        }
        public static void ExportDay(string path, Day day, string dayname)
        {
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine($"{dayname}\n");
                if (day.AllRows.Count != 0)
                {
                    foreach (Row row in day.AllRows)
                    {
                        sw.Write($"Lesson number:\n{day.AllRows.IndexOf(row) + 1}\n");
                        if (row.hours < 10 && row.minutes < 10)
                        {
                            sw.Write($"Time:\n0{row.hours}:0{row.minutes}\n");
                        }
                        else if (row.hours < 10 && row.minutes >= 10)
                        {
                            sw.Write($"Time:\n0{row.hours}:{row.minutes}\n");
                        }
                        else if (row.hours >= 10 && row.minutes < 10)
                        {
                            sw.Write($"Time:\n{row.hours}:0{row.minutes}\n");
                        }
                        else
                        {
                            sw.Write($"Time:\n{row.hours}:{row.minutes}\n");
                        }
                        sw.Write($"Subject:\n{row.subject}\n");
                        sw.Write($"Classroom:\n{row.classroom}\n");
                        sw.Write($"Teachers name:\n{row.teachersname}\n");
                        sw.Write($"Difficulty rating:\n{row.difficulty}\n");
                    }
                }
                else
                {
                    sw.WriteLine("Nothing planned yet.\n");
                }
                sw.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\79263\Documents\schedule.txt";
            FileInfo fileinfo = new FileInfo(path);
            if (!fileinfo.Exists)
            {
                using (FileStream fs = File.Create(path)) { }
            }
            else if (fileinfo.Length != 0)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    List<string> AllWeekDays = new List<string>{"monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"};
                    for (int i = 0; i <= 6; i++)
                    {
                        sr.ReadLine();
                        sr.ReadLine();
                        string a = sr.ReadLine();
                        if (a == "Nothing planned yet.")
                        {
                            sr.ReadLine();
                            sr.ReadLine();
                            continue;
                        }
                        else
                        {
                            while (true)
                            {
                                sr.ReadLine();
                                sr.ReadLine();
                                string b = sr.ReadLine();
                                int hour = Convert.ToInt32($"{b[0]}{b[1]}");
                                int minute = Convert.ToInt32($"{b[3]}{b[4]}");
                                sr.ReadLine();
                                string subj = sr.ReadLine();
                                sr.ReadLine();
                                string classr = sr.ReadLine();
                                sr.ReadLine();
                                string teach = sr.ReadLine();
                                sr.ReadLine();
                                string d = sr.ReadLine();
                                int diff = Convert.ToInt32(d);
                                FieldInfo fieldInfo = typeof(Week).GetField(AllWeekDays[i], BindingFlags.Static | BindingFlags.Public);
                                Day field = (Day)fieldInfo.GetValue(null);
                                field.AddRowKNOWNPARAMETERS(hour, minute, subj, classr, teach, diff);
                                string c = sr.ReadLine();
                                if (c != "Lesson number:")
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            while (true)
            {
                Console.WriteLine("Please, select an action:");
                Console.WriteLine("Press 1 to view your schedule");
                Console.WriteLine("Press 2 to add a lesson");
                Console.WriteLine("Press 3 to remove a lesson");
                Console.WriteLine("Press 4 to change a lesson");
                Console.WriteLine("Press 5 to view your schedule by difficulty");
                Console.WriteLine("Press 0 to save and exit");
                Console.WriteLine();
                int num;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out num))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter a NUMBER, idiot!");
                        Console.WriteLine();
                    }
                }
                if (num == 0)
                {
                    break;
                }
                else if (num == 1)
                {
                    Week.ReturnWeek();
                }
                else if (num == 2)
                {
                    GetDay().AddRow();
                }
                else if (num == 3)
                {
                    GetDay().RemoveRow();
                }
                else if (num == 4)
                {
                    GetDay().ChangeRow();
                }
                else if (num == 5)
                {
                    Week.ReturnDifficultWeek();
                }
            }
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default)) { }
            ExportDay(path, Week.monday, "Monday");
            ExportDay(path, Week.tuesday, "Tuesday");
            ExportDay(path, Week.wednesday, "Wednesday");
            ExportDay(path, Week.thursday, "Thursday");
            ExportDay(path, Week.friday, "Friday");
            ExportDay(path, Week.saturday, "Saturday");
            ExportDay(path, Week.sunday, "Sunday");
        }
    }
}