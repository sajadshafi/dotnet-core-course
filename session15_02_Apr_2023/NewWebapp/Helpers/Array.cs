using NewWebapp.Models;

namespace NewWebapp.Helpers
{
    public class Array<T>
    {
        public T[] list;
        public int length;

        public Array()
        {
            list = new T[5];
            length = 0;
        }

        public void AddElement(T value) { 
            list[length] = value;
            length++;
        }
    }

    public class GenericTest
    {
        public void mainTest()
        {
            Array<int> numbers = new Array<int>();
            Array<string> names = new();

            numbers.AddElement(4);

            names.AddElement("Younis");

            Response<Student> response = new(); 

            response.Data = 

        }
    }


    public class Response<T> {
        T Data { get; set; }
    }

    public class Department {
        public int Id { get; set; }
        public string DepttName { get; set; }
    }


    

}
9