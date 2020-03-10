using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecondCsharpProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Man [] man = new Man[5];
            newMemoryMan(man);
            int sw;
            int n=0;
            while(true)
            {
                Console.WriteLine("\n\t0 - exit,1 - enter users,2 - show users,3 - convert currency:  ");
                sw = int.Parse(Console.ReadLine());
                switch(sw)
                {
                    case 0: closeProgramm(); break;
                    case 1: { enterValue(man,n); n++; } break;
                    case 2: showValue(man,n); break;
                    case 3: convertSomeMoney(man,n); break;
                    default:Console.WriteLine("\n\tВведите 0-3!!!\n"); break;
                }
            }
        }

        static void newMemoryMan(Man []man)
        {
            for (int i = 0; i < 5; i++)
            {
                man[i] = new Man();
            }
        }

        static Man[] enterValue(Man []man,int n)
        {
            if (n == 5) 
            { 
                Console.WriteLine("\n\rMemory stack is full!!!\n");
                return man;
            }

            string typeOfValue="",surname="";
            int faceValue=0,id=0;
            int sw;
            Console.WriteLine("\n\t Please,enter your surname:");
            surname = Console.ReadLine();
            Console.WriteLine("\n\t Please,enter your id:");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\t Available type of values:");
                Console.WriteLine("\n\t 1 - ruble, 2 - dollar, 3 - euro");
                Console.WriteLine("\n\t Please,select one of these types(enter 1,2...etc): ");
                sw = int.Parse(Console.ReadLine());
                if (sw == 1)
                {
                    typeOfValue = "ruble";
                }
                if (sw == 2)
                {
                    typeOfValue = "dollar";
                }
                if (sw == 3)
                {
                    typeOfValue = "euro";
                }
                Console.WriteLine("\n\t Please,enter the face of value:");
                faceValue = int.Parse(Console.ReadLine());
                man[n].setSurname(surname);
                man[n].setId(id);
                man[n].setTypeOfValue(typeOfValue);
                man[n].setFaceValue(faceValue);            
            return man;
        }

        static void showValue(Man[] man,int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n\t Surname: " + man[i].getSurname());
                Console.WriteLine("\n\t ID: " + man[i].getId());
                Console.WriteLine("\n\t Type: " + man[i].getTypeOfValue());
                Console.WriteLine("\n\t Face of value: " + man[i].getFaceValue());
            }
        }
        static Man convertSomeMoney(Man[] man,int n)
        {
            string typeOfValue="",surname ="";
            int faceValue=0;
            int counter = 0;
            int sw = 0;
            Console.WriteLine("\n\t Enter your surname please: ");
            surname = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                if (String.Compare(man[i].getSurname(), surname) == 0)
                {
                    counter = i;
                    typeOfValue = man[i].getTypeOfValue();
                }
            }

            if (String.Compare(typeOfValue, "ruble") == 0)
            {
                Console.WriteLine("\n\t Convert to: ");
                Console.WriteLine("\n\t 1 - ruble in euro;");
                Console.WriteLine("\n\t 2 - ruble in dollar;");
                sw = int.Parse(Console.ReadLine());
                if (sw == 1) 
                {

                    man[counter].setFaceValue(man[counter].getFaceValue() / 4);
                    man[counter].setTypeOfValue("euro");
                }
                if (sw == 2)
                {
                    man[counter].setFaceValue(man[counter].getFaceValue() / 3);
                    man[counter].setTypeOfValue("dollar");
                }
            }
            if (String.Compare(typeOfValue, "dollar") == 0)
            {
                Console.WriteLine("\n\t Convert to: ");
                Console.WriteLine("\n\t 1 - dollar in euro;");
                Console.WriteLine("\n\t 2 - dollar in ruble;");
                sw = int.Parse(Console.ReadLine());
                if (sw == 1)
                {

                    man[counter].setFaceValue(man[counter].getFaceValue() / 2);
                    man[counter].setTypeOfValue("euro");
                }
                if (sw == 2)
                {
                    man[counter].setFaceValue(man[counter].getFaceValue()*3);
                    man[counter].setTypeOfValue("ruble");
                }
            }
            if (String.Compare(typeOfValue, "euro") == 0)
            {
                Console.WriteLine("\n\t Convert to: ");
                Console.WriteLine("\n\t 1 - euro in dollar;");
                Console.WriteLine("\n\t 2 - euro in ruble;");
                sw = int.Parse(Console.ReadLine());
                if (sw == 1)
                {

                    man[counter].setFaceValue(man[counter].getFaceValue() * 2);
                    man[counter].setTypeOfValue("dollar");
                }
                if (sw == 2)
                {
                    man[counter].setFaceValue(man[counter].getFaceValue() * 4);
                    man[counter].setTypeOfValue("ruble");
                }
            }



            return man[counter];
        }
        static void closeProgramm()
        {
            Environment.Exit(0);
        }

    }

    class Currency
    {
        string typeOfValue;
        int faceValue;
        public void setTypeOfValue(string typeOfValue)
        {
            this.typeOfValue = typeOfValue;
        }
        public string getTypeOfValue()
        {
            return typeOfValue;
        }
        public void setFaceValue(int faceValue)
        {
            this.faceValue = faceValue;
        }
        public int getFaceValue()
        {
            return faceValue;
        }
    }

    class Man:Currency
    {
        string surname;
        int id;
        public void setSurname(string surname)
        {
            this.surname = surname;
        }
        public string getSurname()
        {
            return surname;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }
    }
}
