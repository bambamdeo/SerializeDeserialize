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

            Console.WriteLine(student.StudentName);

            Console.WriteLine(strOutput);

            //Actual XML format on Serialization of existing XML doc
            var studentlist = sSerialize.Serialize<StudentList>(studentss);

            #region Serialize Object to xml
            StudentList studs = new StudentList();
            studs.Students = new List<Student>();
            Student student1 = new Student { Course = "MCA", StudentAge = 21, StudentName = "Deo", StudentNumber = 1, StudentSurname = "Mr" };
            studs.Students.Add(student1);
            student1 = new Student { Course = "BTech", StudentAge = 21, StudentName = "Deo1", StudentNumber = 1, StudentSurname = "Mr" };
            studs.Students.Add(student1);
            student1 = new Student { Course = "BE", StudentAge = 31, StudentName = "Deo3", StudentNumber = 1, StudentSurname = "Mr" };
            studs.Students.Add(student1);
            student1 = new Student { Course = "BA", StudentAge = 41, StudentName = "Deo2", StudentNumber = 1, StudentSurname = "Mr" };
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
        public int StudentNumber { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentAge { get; set; }
        public string Course { get; set; }

    }
}
