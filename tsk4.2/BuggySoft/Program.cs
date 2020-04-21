using System;

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
                int max = personal.GetList.Length > work.GetList.Length ? personal.GetList.Length : work.GetList.Length;
                max = max > family.GetList.Length ? max : family.GetList.Length;


                //Print out the Table
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(new string(' ', 12) + "CATEGORIES");
                Console.WriteLine(new string(' ', 10) + new string('-', 94));
                Console.WriteLine("{0,10}|{1,30}|{2,30}|{3,30}|", "item #", personal.GetName, work.GetName, family.GetName);
                Console.WriteLine(new string(' ', 10) + new string('-', 94));
                for (int i = 0; i < max; i++)
                {
                    Console.Write("{0,10}|", i);

                    if (personal.GetList.Length > i)
                    {
                        Console.Write("{0,30}|", personal.GetList[i]);
                    }
                    else
                    {
                        Console.Write("{0,30}|", "N/A");
                    }

                    if (work.GetList.Length > i)
                    {
                        Console.Write("{0,30}|", work.GetList[i]);
                    }
                    else
                    {
                        Console.Write("{0,30}|", "N/A");
                    }

                    if (family.GetList.Length > i)
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
                if (task.Length > 30) task = task.Substring(0, 30);

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


    public class Category
    {
        private string _name;
        private string[] _listItem;

        public Category(string name)
        {
            this._name = name;
            this._listItem = new string[0];
        }

        //Get the name and list of item
        public string GetName
        {
            get { return this._name; }
        }
        public string[] GetList
        {
            get { return this._listItem; }
        }

        //Mutator, add new item to the list
        public void AddItem(string item)
        {

            //Copy the current array to a new array with +1 length
            string[] listIndividualNew = new string[this._listItem.Length + 1];
            for (int j = 0; j < this._listItem.Length; j++)
            {
                listIndividualNew[j] = this._listItem[j];
            }

            //Assign the new item to the last position of the new array
            listIndividualNew[listIndividualNew.Length - 1] = item;

            //Transfer the new array's item to the old one
            this._listItem = listIndividualNew;
        }
        public void PrintList()
        {
            foreach (var item in this._listItem)
            {
                Console.WriteLine("{0,30}|", item);
            }
        }
    }
}