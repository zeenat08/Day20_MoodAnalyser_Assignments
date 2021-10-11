using System;
using System.Collections.Generic;
using System.Text;


namespace Day20_MoodAnalyser
{
    public class Mood_Analyser
    {
        //variable
        string message;

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
                }
                if (this.message.ToLower().Contains("sad"))
                    return "SAD";
                else if (this.message.ToLower().Contains("happy"))
                    return "SAD";
                
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                throw new Mood_Analyser_Custom_Exception(Mood_Analyser_Custom_Exception.ExceptionType.NULL_MESSAGE, "Mood Should not be NULL");
            }
        }

    }
}

