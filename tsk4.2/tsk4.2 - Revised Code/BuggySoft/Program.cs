using System;
using System.Collections.Generic;
using System.Collections;

namespace DuplicateCode
{
    class DuplicateCode
    {

        static void Main(string[] args)
        {
            string[] tasksIndividual = new string[0], tasksWork = new string[0], tasksFamilly = new string[0];

            Category personal = new Category("Personal");
            Category work = new Category("Work");
            Category family = new Category("Family");
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
                Console.WriteLine("\nWhich category do you want to place a new task? Type \'Personal\', \'Work\', or \'Family\'");
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
    }

    public class Table
    {
        private string _name;
        private List<Category> _tableItems;
        public Table(string name)
        {
            this._name = name;
            this._tableItems = new List<Category>();
        }

        public void AddCategory(string categoryName)
        {
            this._tableItems.Add(new Category(categoryName));
        }

        public void RemoveCategory(string categoryName)
        {
            int i = 0;
            while(i<_tableItems.Count)
            {
                if (this._tableItems[i].GetName == categoryName)
                {
                    _tableItems.RemoveAt(i);
                }
                else i++;
            }
        }

        public Table BaseTable()
        {
            this.AddCategory("Personal");
            this.AddCategory("Work");
            this.AddCategory("Family");
            return this;
        }


    }

    public class Category
    {
        private string _name;
        private List<string> _listItem;

        public Category(string name)
        {
            this._name = name;
            this._listItem = new List<string>();
        }

        //Get the name and list of item
        public string GetName
        {
            get => this._name;
        }
        public List<string> GetList
        {
            get => this._listItem; 
        }

        //Mutator, add new item to the list
        public void AddItem(string item)
        {
            //add item to list
            this._listItem.Add(item);
        }
        public void PrintList()
        {
            foreach (var item in this._listItem)
            {
                Console.WriteLine("{0,30}|", item.Substring(0, 30));
            }
        }
    }
}