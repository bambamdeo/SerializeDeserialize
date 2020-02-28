using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SerializeDeserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericXmlSerializer sSerialize = new GenericXmlSerializer();

            string strPath = string.Empty;
            string strInput = string.Empty;
            string strOutput = string.Empty;

            strPath = Directory.GetCurrentDirectory() + @"\Student.xml";
            var strsPath = Directory.GetCurrentDirectory() + @"\Students.xml";
            strInput = File.ReadAllText(strPath);
            var strsInput = File.ReadAllText(strsPath);

            Student student = sSerialize.Deserialize<Student>(strInput);
            StudentList studentss = sSerialize.Deserialize<StudentList>(strsInput);
            strOutput = sSerialize.Serialize<Student>(student);

            Console.WriteLine(student.Name);

            Console.WriteLine(strOutput);

            //Actual XML format on Serialization of existing XML doc
            var studentlist = sSerialize.Serialize<StudentList>(studentss);

            #region Serialize Object to xml
            StudentList studs = new StudentList();
            studs.Students = new List<Student>();
            Student student1 = new Student { Course = "MCA", Age = 21, Name = "Deo", ID = 1, Surname = "Mr" };
            studs.Students.Add(student1);
            student1 = new Student { Course = "BTech", Age = 21, Name = "Deo1", ID = 1, Surname = "Mr" };
            studs.Students.Add(student1);
            student1 = new Student { Course = "BE", Age = 31, Name = "Deo3", ID = 1, Surname = "Mr" };
            studs.Students.Add(student1);
            student1 = new Student { Course = "BA", Age = 41, Name = "Deo2", ID = 1, Surname = "Mr" };
            studs.Students.Add(student1);

            var Output = sSerialize.Serialize<StudentList>(studs);
            Console.WriteLine(Output);

            #endregion

            #region Json

            var obj2Json = JsonConvert.SerializeObject(studs);

            var json2Obj = JsonConvert.DeserializeObject(obj2Json);

            #endregion
            
            Console.ReadKey();

        }

    }

    public class StudentList
    {
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }

    }
}
