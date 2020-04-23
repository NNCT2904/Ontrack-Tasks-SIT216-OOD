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
            Table testTable = new Table("testTable");
            testTable.TestSample();
            while (true)
            {
                Console.Clear();
                testTable.Print();
                Console.ResetColor();
                UI(testTable);
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
                case MenuOptions.AddCategory:
                    {
                        AddCat(table);
                        break;
                    }
                case MenuOptions.DeleteCategory:
                    {
                        DelCat(table);
                        break;
                    }
                case MenuOptions.SwapPriority:
                    {
                        Swap(table);
                        break;
                    }
                case MenuOptions.MoveTask:
                    {
                        Move(table);
                        break;
                    }
                case MenuOptions.Highligh:
                    {
                        Highlight(table);
                        break;
                    }
            }
        }

        //Table Functions
        private static void AddTask(Table table)
        {
            int index = ChooseCategory(table);

            Console.Write("Enter your task, max 30 symbols\n>> ");
            string taskName = CheckString(Console.ReadLine(), 30);

            Console.WriteLine("Enter the deadline, enter anything else if you don't have deadline");

            //User can ignore deadline
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
            int index = ChooseCategory(table);
            int taskOrder = ChooseTask(table, index);
            table.GetCategories[index].RemoveItem(taskOrder);
        }

        private static void AddCat(Table table)
        {
            Console.Write("Enter name for new category, under 20 characters\n>> ");
            //Limit category to 20 characters
            table.AddCategory(CheckString(Console.ReadLine(), 20));
        }

        private static void DelCat(Table table)
        {
            table.RemoveCategory(ChooseCategory(table));
        }

        private static void Swap(Table table)
        {
            int category = ChooseCategory(table);
            Console.Write("From ");
            int from = ChooseTask(table, category);
            Console.Write("To ");
            int to = ChooseTask(table, category);

            table.GetCategories[category].SwapOrder(from, to);
        }

        private static void Move(Table table)
        {
            Console.WriteLine("From ");
            int fromCat = ChooseCategory(table);
            int index = ChooseTask(table, fromCat);
            Console.WriteLine("To ");
            int toCat = ChooseCategory(table);

            table.Transfer(fromCat.ToString(), toCat.ToString(), index);
        }

        private static void Highlight(Table table)
        {
            int cat = ChooseCategory(table);
            int task = ChooseTask(table, cat);
            //Mark as priority, unmark if the task is already marked
            if (table.GetCategories[cat].GetList[task].GetPriority)
            {
                table.GetCategories[cat].GetList[task].NotPriority();
            }
            else table.GetCategories[cat].GetList[task].Priority();
        }

        //Methods
        //Return MenuOption datatype based on user input
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
                if (userInput <= 0 || userInput > Enum.GetValues(typeof(MenuOptions)).Length)
                {
                    Console.WriteLine("Unknown option, try again!");
                }
            } while (userInput <= 0 || userInput > Enum.GetValues(typeof(MenuOptions)).Length);

            return (MenuOptions)userInput;
        }

        //Check user input, and set a limit
        private static string CheckString(string input, int limit)
        {
            int count = 0;
            do
            {
                //Count the length of input
                count = 0;
                foreach (char character in input)
                    if (character == '/')
                        count++;
                if (count > limit)
                {
                    Console.WriteLine("Input should not over 30, try again");
                    input = Console.ReadLine();
                }
            } while (count > limit);
            return input;
        }

        //convert input to string
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

        private static DateTime InputToDatetime(string input)
        {
            DateTime time;
            while (!DateTime.TryParse(input, out time))
            {
                Console.WriteLine("Invalid date, try again");
                input = Console.ReadLine();
            }
            return time;
        }

        private static int ChooseCategory(Table table)
        {
            //Print Category and index
            Console.Write("Which category?");
            Console.WriteLine();
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
            //Return the index of chosen category in the table
            return index;
        }

        private static int ChooseTask(Table table, int category)
        {
            Console.Write("Which task?\n>> ");
            int taskOrder = 0;
            do
            {
                taskOrder = InputToInt(Console.ReadLine());
                if (taskOrder < 0 || taskOrder >= table.GetCategories[category].GetList.Count)
                {
                    Console.WriteLine("Unknown task! Please try again");
                }
            } while (taskOrder < 0 || taskOrder >= table.GetCategories[category].GetList.Count);
            return taskOrder;
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

        public void RemoveCategory(int index)
        {
            this._tableItems.RemoveAt(index);
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
            int max = this._tableItems[0].GetList.Count;
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
            //Print Category with index number
            for (int i = 0; i < this._tableItems.Count; i++)
            {
                Console.Write("{0,40}|", $"[{i}] " + this._tableItems[i].GetName);
            }

            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) + new string('-', (_tableItems.Count * 41 + 1)));

            //Print tasks in each category
            for (int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", $"[{i}]");
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
    
        //Sample table for testing 
        public void TestSample()
        {
            this._tableItems.Clear();
            this.BaseTable();
            this._tableItems[0].AddItem("Drink water");
            this._tableItems[0].AddItem("Birthday", new DateTime(2020, 04, 29));
            this._tableItems[0].AddItem("Onetrack task 3.2", new DateTime(2020, 04, 27));
            this._tableItems[1].AddItem("IT Interview", new DateTime(2020, 04, 30));
            this._tableItems[2].AddItem("Call Dad");
            
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