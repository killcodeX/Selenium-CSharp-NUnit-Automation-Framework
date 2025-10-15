using AventStack.ExtentReports;

namespace AutomationExercise.Utils
{
    public class ExtentTestManager
    {
        [ThreadStatic]
        private static ExtentTest test;

        public static ExtentTest CreateTest(string testName, string description = "")
        {
            test = ExtentManager.GetExtent().CreateTest(testName, description);
            return test;
        }

        public static ExtentTest GetTest()
        {
            return test;
        }

        // Logging methods
        public static void LogInfo(string message)
        {
            test?.Info(message);
            Console.WriteLine($"ℹ️  {message}");
        }

        public static void LogPass(string message)
        {
            test?.Pass($"✅ {message}");
            Console.WriteLine($"✅ {message}");
        }

        public static void LogFail(string message)
        {
            test?.Fail($"❌ {message}");
            Console.WriteLine($"❌ {message}");
        }

        public static void LogWarning(string message)
        {
            test?.Warning($"⚠️  {message}");
            Console.WriteLine($"⚠️  {message}");
        }

        public static void LogSkip(string message)
        {
            test?.Skip(message);
            Console.WriteLine($"⏭️  {message}");
        }
    }
}