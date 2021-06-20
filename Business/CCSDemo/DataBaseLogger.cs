using System;

namespace Business.CCSDemo
{
    public class DataBaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Veri Tabanına Loglandı");
        }
    }
}
