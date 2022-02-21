using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Task01
{
    [Serializable]
    public class Student    
    {
        public string Name { get; set; }
        public int Year { get; set; }
        
        public Student() { }
        public Student(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
    [Serializable]
    public class Group    
    {
        [JsonInclude]
        public List<Student> Students { get; set; }
        [JsonInclude]
        public string Name { get; set; }
        
        public Group() { }
        public Group(List<Student> students, string name)
        {
            Students = students; 
            Name = name;
        }
        
        public override string ToString()
        {
            string ans = String.Empty;
            
            foreach (var student in Students)
            {
               ans += $"{student.Name}: {student.Year}\n";
            }
            
            return ans;
        }
    }
    
    
    class Program    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            
            students.Add(new Student("Dudarev", 1000));
            students.Add(new Student("Juikin", -10));
            
            Group @group = new Group(students, "Lol");
            
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("info1.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, @group);
            }
            
            using (FileStream file = new FileStream("info1.txt", FileMode.OpenOrCreate))
            {
                Group binGroup = (Group)formatter.Deserialize(file);
                Console.WriteLine(binGroup);
            }
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Group));
            using (FileStream file = new FileStream("info2.txt", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(file, @group);
            }
            
            using (FileStream file = new FileStream("info2.txt", FileMode.OpenOrCreate))
            {
                var xmlGroup = (Group)xmlSerializer.Deserialize(file);
                Console.WriteLine(xmlGroup);
            }
            
            var jsonGroup  = JsonSerializer.Serialize<Group>(@group, null);
            var groups = JsonSerializer.Deserialize<Group>(jsonGroup);
            Console.WriteLine(groups);
            
        }
    }
}