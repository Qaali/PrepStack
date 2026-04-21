using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrepStack.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Difficulty { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }

        //Encapsulation—grouping related data together.
        //In C#, we create a class to represent our database table. This is Encapsulation.


        //Interview Prep Tip: What are { get; set; }? These are called Properties.
        //They allow you to read (get) and write (set) data.
        //Using properties instead of just public variables is a core part of Encapsulation.

    }
}
