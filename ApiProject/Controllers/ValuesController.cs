using ApiProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProject.Controllers
{
    public class StudentsController : ApiController
    {
        //List<Student> studentL = new List<Student>();
        DatabaseManager dm;

        public StudentsController()
        {
            this.dm = new DatabaseManager();
            dm.ConnectDB();


          //  var s1 = new Student();
          //  s1.Name = "Francis";
          //  s1.Age = 30;
          //  s1.Location = "KWl/2";
          //  s1.Country = "Malawi";
          //  s1.Chidren.Add(new Child { Name = "Sophia" });
          //  s1.Chidren.Add(new Child { Name = "Sophia" });
          //  studentL.Add(s1);

          //  var s2 = new Student();
          //  s2.Name = "Lisungwe";
          //  s2.Age = 70;
          //  s2.Location = "Lisungwe";
          //  s2.Country = "DRC";

          //  studentL.Add(s2);

          //  var s3 = new Student("Guy", 56, "Likuni", "Rwanda");

          ////  dm.InsertIdentities(s2.Name, s2.Age, s2.Location, s2.Country);
          //  if (studentL.Count > 0)
          //  {
          //      for (int i = 0; i < studentL.Count; i++)
          //      {
          //          dm.InsertIdentities(studentL[i].Name, studentL[i].Age, studentL[i].Location, studentL[i].Country);
          //      }
          //  }
          //  else
          //  {
              
          //  }
           

        }
        // GET api/values
        public IEnumerable<Student> Get()
        {
            return ReadFromDB();
        }

        // GET api/values/5
        public Student Get(int id)
        {
           var select = ReadFromDB();
           return select[id];
        }

        // POST api/values
        public void Post([FromBody]Student student)
        {
            dm.InsertIdentities(student.Name, student.Age, student.Location, student.Country);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public List<Student> ReadFromDB()
        {
            var select = dm.ShowIdentities(2);
            return JsonConvert.DeserializeObject<List<Student>>(select);
        }
    }
}
