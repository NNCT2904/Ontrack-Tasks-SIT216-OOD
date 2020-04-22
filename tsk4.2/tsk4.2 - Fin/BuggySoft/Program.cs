using System;

using System.Collections.Generic;

public enum MenuOptions
{
    AddTask = 1,
    RemoveTask = 2,
    AddCategory = 3,
    DeleteCategory = 4,
    SwapPriority = 5,
    MoveTask = 6,
    Highligh = 7,
}

namespace DuplicateCode
{
    internal class DuplicateCode
    {
        private static void Main(string[] args)
        {
            string[] tasksIndividual = new string[0], tasksWork = new string[0], tasksFamilly = new string[0];

            Category personal = new Category("Personal");
            Category work = new Category("Work");
            Category family = new Category("Family");

            Table testTable = new Table("testTable");
            testTable.GetCategories[0].AddItem("agdfgsdf", ConvertToDatetime("30/04/2020"));
            testTable.GetCategories[0].AddItem("bdtryjty");
            testTable.GetCategories[0].AddItem("csrfgt");
            testTable.GetCategories[0].AddItem("dsdfgsdgf");
            testTable.Transfer("Personal", "Work", 1);
            testTable.RemoveCategory("family");
            testTable.GetCategories[0].SwapOrder(1, 0);
            while (true)
            {
                Console.Clear();
                testTable.Print();
                Console.ResetColor();
                UI(testTable);
                Console.ReadKey();
            }
            while (true)
            {
                Console.Clear();
                int max = personal.GetList.Count > work.GetList.Count ? personal.GetList.Count : work.GetList.Count;
                max = max > family.GetList.Count ? max : family.GetList.Count;

                //Print out the Table
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(new string(' ', 12) + "CATEGORIES");
                Console.WriteLine(new string(' ', 10) + new string('-', 94));
                Console.WriteLine("{0,10}|{1,30}|{2,30}|{3,30}|", "item #", personal.GetName, work.GetName, family.GetName);
                Console.WriteLine(new string(' ', 10) + new string('-', 94));
                for (int i = 0; i < max; i++)
                {
                    Console.Write("{0,10}|", i);

                    if (personal.GetList.Count > i)
                    {
                        Console.Write("{0,30}|", personal.GetList[i]);
                    }
                    else
                    {
                        Console.Write("{0,30}|", "N/A");
                    }

                    if (work.GetList.Count > i)
                    {
                        Console.Write("{0,30}|", work.GetList[i]);
                    }
                    else
                    {
                        Console.Write("{0,30}|", "N/A");
                    }

                    if (family.GetList.Count > i)
                    {
                        Console.Write("{0,30}|", family.GetList[i]);
                    }
                    else
                    {
                        Console.Write("{0,30}|", "N/A");
                    }
                    Console.WriteLine();
                }

                //Ask for category and task
                Console.ResetColor();
                Console.Write("\nWhich category do you want to place a new task?");
                Console.WriteLine("Type \'Personal\', \'Work\', or \'Family\'");
                Console.Write(">> ");
                string listName = Console.ReadLine().ToLower();
                Console.WriteLine("Describe your task below (max. 30 symbols).");
                Console.Write(">> ");
                string task = Console.ReadLine();

                //Assign task to each category
                if (listName == "personal")
                {
                    personal.AddItem(task);
                }
                else if (listName == "work")
                {
                    work.AddItem(task);
                }
                else if (listName == "family")
                {
                    family.AddItem(task);
                }
            }
        }

        private static void UI(Table table)
        {
            switch (ReadUserInput())
            {
                case MenuOptions.AddTask:
                    {
                        AddTask(table);
                        break;
                    }
                case MenuOptions.RemoveTask:
                    {
                        RemoveTask(table);
                        break;
                    }
            }
        }

        private static MenuOptions ReadUserInput()
        {
            int userInput;

            //Print out the menu options
            Console.WriteLine("Which action?");
            foreach (MenuOptions choices in Enum.GetValues(typeof(MenuOptions)))
            {
                Console.Write($"| {(int)choices}. {choices.ToString()} |");
            }
            Console.WriteLine();
            //limit user input
            do
            {
                Console.Write(">> ");
                userInput = InputToInt(Console.ReadLine());
                if (userInput <= 0 || userInput >= Enum.GetValues(typeof(MenuOptions)).Length)
                {
                    Console.WriteLine("Unknown option, try again!");
                }
            } while (userInput <= 0 || userInput >= Enum.GetValues(typeof(MenuOptions)).Length);

            return (MenuOptions)userInput;
        }

        private static void AddTask(Table table)
        {
            Console.WriteLine("Which category?");
            for (int i = 0; i < table.GetCategories.Count; i++)
            {
                Console.Write($"| {i}. {table.GetCategories[i].GetName} |");
            }
            Console.Write("\n>> ");

            int index = 0;
            do
            {
                index = InputToInt(Console.ReadLine());
                if (index < 0 || index > table.GetCategories.Count)
                {
                    Console.WriteLine("Unknown Category! Please ty again");
                }
            } while (index < 0 || index > table.GetCategories.Count);

            Console.Write("Enter your task, max 30 symbols\n>> ");
            string taskName = CheckString(Console.ReadLine());

            Console.WriteLine("Enter the deadline, enter anything else if you don't have deadline");

            if (DateTime.TryParse(Console.ReadLine(), out DateTime deadlineDate))
            {
                table.GetCategories[index].AddItem(taskName, deadlineDate);
            }
            else
            {
                table.GetCategories[index].AddItem(taskName);
            }

        }

        private static void RemoveTask(Table table)
        {
            Console.WriteLine("Which category");
            for (int i = 0; i < table.GetCategories.Count; i++)
            {
                Console.Write($"| {i}. {table.GetCategories[i].GetName} |");
            }
            Console.Write("\n>> ");

            int index = 0;
            do
            {
                index = InputToInt(Console.ReadLine());
                if (index < 0 || index >= table.GetCategories.Count)
                {
                    Console.WriteLine("Unknown Category! Please ty again");
                }
            } while (index < 0 || index > table.GetCategories.Count);

            Console.Write("Which task do you want to remove?\n>> ");

            int taskOrder = 0;
            do
            {
                taskOrder = InputToInt(Console.ReadLine());
                if (taskOrder < 0 || taskOrder >= table.GetCategories[index].GetList.Count)
                {
                    Console.WriteLine("Unknown task! Please try again");
                }
            } while (taskOrder < 0 || taskOrder >= table.GetCategories[index].GetList.Count);

            table.GetCategories[index].RemoveItem(taskOrder);
        }

        //Methods
        //Check user input, it should not be over 30 character
        private static string CheckString(string input)
        {
            int count = 0;
            do
            {
                //Count the length of input
                count = 0;
                foreach (char character in input)
                    if (character == '/')
                        count++;
                if (count > 30)
                {
                    Console.WriteLine("Input should not over 30, try again");
                    input = Console.ReadLine();
                }
            } while (count > 30);
            return input;
        }

        private static int InputToInt(string inputNumberAsString)
        {
            int inputNumber;
            while (!int.TryParse(inputNumberAsString, out inputNumber))
            {
                Console.WriteLine("This is not quite an integer");
                inputNumberAsString = Console.ReadLine();
            }
            return inputNumber;
        }


        private static DateTime ConvertToDatetime(string input)
        {
            DateTime time;
            while (!DateTime.TryParse(input, out time))
            {
                Console.WriteLine("Invalid date, try again");
                input = Console.ReadLine();
            }
            return time;
        }
    }

    public class Table
    {
        private string _name;
        private List<Category> _tableItems;

        public Table(string name)
        {
            this._name = name;
            this._tableItems = new List<Category>();
            this.BaseTable();
        }

        //Get name and categories
        public string GetName
        {
            get => this._name;
        }

        public List<Category> GetCategories
        {
            get => this._tableItems;
        }

        public void BaseTable()
        {
            this.AddCategory("Personal");
            this.AddCategory("Work");
            this.AddCategory("Family");
        }

        public void AddCategory(string categoryName)
        {
            this._tableItems.Add(new Category(categoryName));
        }

        public void RemoveCategory(string categoryName)
        {
            this._tableItems.Remove(StringToCategory(categoryName));
        }

        public void Transfer(string from, string to, int order)
        {
            //Get the task from one category
            string taskTransfer = StringToCategory(from).GetList[order].GetName;

            //Then remove that task
            StringToCategory(from).RemoveItem(order);

            //Transfer to another category
            StringToCategory(to).AddItem(taskTransfer);
        }

        public void Print()
        {
            int max = this._tableItems[0].GetList.Count > this._tableItems[1].GetList.Count ?
                this._tableItems[0].GetList.Count : this._tableItems[1].GetList.Count;
            foreach (var category in this._tableItems)
            {
                max = max > category.GetList.Count ? max : category.GetList.Count;
            }

            //Default console color
            var defaultConsoleColor = ConsoleColor.Blue;
            Console.ForegroundColor = defaultConsoleColor;

            //Print out the Table
            Console.WriteLine(new string(' ', 12) + "CATEGORIES");
            Console.WriteLine(new string(' ', 10) + new string('-', (_tableItems.Count * 41 + 1)));
            Console.Write("{0,10}|", "Item #");
            foreach (var category in this._tableItems)
            {
                Console.Write("{0,40}|", category.GetName);
            }
            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) + new string('-', (_tableItems.Count * 41 + 1)));

            //Print tasks in each category
            for (int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", i);
                foreach (var category in this._tableItems)
                {
                    if (category.GetList.Count > i)
                    {
                        //Highlight if the task is marked as priority
                        if (category.GetList[i].GetPriority)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0,40}", category.GetList[i].GetName + new string($" ({category.GetList[i].GetDeadline})"));
                            Console.ForegroundColor = defaultConsoleColor;
                            Console.Write("|");
                        }
                        else Console.Write("{0,40}|", category.GetList[i].GetName + new string($" ({category.GetList[i].GetDeadline})"));
                    }
                    else
                    {
                        Console.Write("{0,40}|", "N/A");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string(' ', 10) + new string('-', (_tableItems.Count * 41 + 1)));
        }

        //Private methods, add more spices because I want to
        private Category StringToCategory(string input)
        {
            foreach (var category in this._tableItems)
                if (category.GetName.ToLower() == input.ToLower())
                    return category;

            return null;
        }
    }

    public class Category
    {
        private string _name;
        private List<Task> _listItem;

        public Category(string name)
        {
            this._name = name;
            this._listItem = new List<Task>();
        }

        //Get the name and list of item
        public string GetName
        {
            get => this._name;
        }

        public List<Task> GetList
        {
            get => this._listItem;
        }

        //Mutator, add/remove item to the list
        public void AddItem(string item, DateTime deadLine)
        {
            this._listItem.Add(new Task(item, deadLine));
        }

        public void AddItem(string item)
        {
            this._listItem.Add(new Task(item));
        }

        public void RemoveItem(int order)
        {
            this._listItem.RemoveAt(order);
        }

        public void SwapOrder(int from, int to)
        {
            Task temp = this._listItem[from];

            this._listItem[from] = this._listItem[to];

            this._listItem[to] = temp;
        }

        public void PrintList()
        {
            foreach (var item in this._listItem)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Task
    {
        private string _name;
        private DateTime _deadline;
        private bool _priority;

        public Task(string name)
        {
            this._name = name;
        }

        public Task(string name, DateTime deadline)
        {
            this._name = name;
            this._deadline = deadline;
        }

        public string GetName
        {
            get => _name;
        }

        public bool GetPriority
        {
            get => _priority;
        }

        public string GetDeadline
        {
            get
            {
                if (_deadline == DateTime.MinValue)
                    return "Undated";
                return this._deadline.ToString("dd/MM/yy");
            }
        }

        public void Priority()
        {
            this._priority = true;
        }

        public void NotPriority()
        {
            this._priority = false;
        }
    }
}