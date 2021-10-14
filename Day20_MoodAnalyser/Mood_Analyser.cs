using System;
using System.Collections.Generic;
using System.Text;


namespace Day20_MoodAnalyser
{
    public class Mood_Analyser
    {
        //variable
        public string message;

        //Constructor with no parameter
        public Mood_Analyser()
        {

        }

        //constructor with a string type parameter
        public Mood_Analyser(string message)
        {
            this.message = message;
        }

        //method for checking mood
         public string AnalyseMood()
            {
                //Exception Handling
                try
                {
                    if (this.message.Equals(string.Empty))
                    {
                        throw new Mood_Analyser_Custom_Exception(Mood_Analyser_Custom_Exception.ExceptionType.EMPTY_MESSAGE, "Mood should not be EMPTY");
                        //throw new Exception();
                    }
                    if (this.message.ToLower().Contains("sad"))
                        return "SAD";
                    else
                        return "HAPPY";
                }
                catch (NullReferenceException e)
                {
                    return e.Message; ////e used in UC2 case
                                      //throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood Should not be NULL");
                                      ////throw new Exception(e.Message);
                }

         }
    }
}


