namespace UniversityInformationSystem.Models.Utillities
{
    using System;

    public class FacultyNumberGenerator
    {
        public static string GenerateFacultyNumber()
        {
            Random rnd = new Random();
            char[] facultyNumberArr = new char[10];
            for (int i = 0; i < facultyNumberArr.Length; i++)
            {
                facultyNumberArr[i] = char.Parse(rnd.Next(10).ToString());
            }

            return new string(facultyNumberArr);
        }
    }
}
