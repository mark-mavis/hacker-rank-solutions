namespace InterviewQuestions
{
    class CircularPrinter
    { 
        public static void RunExercise(string s)
        {
            //Variable Setup
            int timeSum = 0;
            int normalize_val = 65;
            s = "A" + s;    //Append Starting Point to first element

            for(int i = 1; i < s.Length; i++)
            {
                //Each Loop, take the Minimum val of the Counter Clockwise Rotation and the Clockwise rotation between the index and index-1) 
                timeSum += Math.Min( (Math.Abs((s[i] - normalize_val) - (s[i - 1] - normalize_val))) , (26 - Math.Abs((s[i] - normalize_val) - (s[i - 1] - normalize_val))) ); // Min(CounterClockWise, ClockWise)
            }
            Console.WriteLine(timeSum);
        }

        public static void Run()
        {
            string s = "AZGB";
            RunExercise(s);
            s = "BZA";
            RunExercise(s);
            s = "FZDXMRE";
            RunExercise(s);
        }
    }
}
