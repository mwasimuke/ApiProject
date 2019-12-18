using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ApiProject.Models;
using ApiProject;

namespace StudentsConsole
{
   public class Program
    {
       //DatabaseManager dm = new DatabaseManager();
      public  static void Main(string[] args)
        {
            var client = new HttpClient();
            var stri = "";
            try
            {
              
                 stri = client.GetStringAsync("http://localhost:49164/api/Students/0").Result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
               // throw;
            }
           

            //Console.WriteLine(stri);
            //Console.WriteLine("Hello World!");


            // Convert the JSON string into a Student object
            //  var student = JsonConvert.DeserializeObject<Student>(stri);

            //Console.WriteLine(student.Name);


            if (string.IsNullOrEmpty(stri))
            {
                Console.WriteLine(stri);

                // Convert the JSON string into a Student object
                var st = DatabaseManager.showName;
                var student = JsonConvert.DeserializeObject<Student>(stri);

                Console.WriteLine(student.Name);
            }



            // Create new student
            var newStudent = new Student("Khalid", 29, "Lisungwe","DRC");
            // Serialize Student object into JSON string
            var jsonStudent = JsonConvert.SerializeObject(newStudent);

            // Describe the structure string as JSON in UTF/8 format 
            var content = new StringContent(jsonStudent, Encoding.UTF8, "application/json");

            // POST the JSON Student to the server
            var result = client.PostAsync("http://localhost:49164/api/Students", content).Result;

            Console.WriteLine("Did we create the student " + result.IsSuccessStatusCode);

        


            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 


        }
    }
}
