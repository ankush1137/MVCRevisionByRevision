namespace ValidationDemo.Models
{
    public class StudentDb
    {
        public static List<Student> AllStudent()
        {

            List<Student> students = new List<Student>()
            {
                new Student() {RollNumber=100, Name="Onkar",Age=27, Gender="male",
                    Mobile=7769832384,Email="onkar123@gmail.com",Password="onkar@123",ConfirmPassword="onkar@123",AddmissionDate=DateTime.Now},
            };


            return students;
        }
    }
}
