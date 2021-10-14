using Day20_MoodAnalyser;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Day20_Mood_Analyser
    {
        public class MoodAnalyserFactory
        {
            public string message;
            public MoodAnalyserFactory(string message)
            {
                this.message = message;
            }

            //below code is UC 4
            /// <summary>
            /// CreateMoodAnalyser Method to create object of MoodAnalyser class
            /// </summary>
            /// <param name="className"></param>
            /// <param name="constructorName"></param>
            /// <returns></returns>
            public static object CreateMoodAnalyser(string className, string constructorName)
            {
                string pattern = @"." + constructorName + "$";
                Match result = Regex.Match(className, pattern);
                if (result.Success)
                {
                    try
                    {
                        Assembly executing = Assembly.GetExecutingAssembly();
                        Type moodAnalyseType = executing.GetType(className);
                        return Activator.CreateInstance(moodAnalyseType);
                    }
                    catch (ArgumentNullException)
                    {
                        throw new Mood_Analyser_Custom_Exception(Mood_Analyser_Custom_Exception.ExceptionType.NO_SUCH_CLASS, "Class not found");
                    }
                }
                else
                {
                    throw new Mood_Analyser_Custom_Exception(Mood_Analyser_Custom_Exception.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                }
            }

            //below code is UC-5
            /// <summary>
            /// Create MoodAnalyse Method to create object of MoodAnalyser class
            /// </summary>
            /// <param name="className"></param>
            /// <param name="constructorName"></param>
            /// <param name="message"></param>
            /// <returns></returns>
            public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName, string message)
            {
                Type type = typeof(Mood_Analyser);
                if (type.Name.Equals(className) || type.FullName.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                        object instance = ctor.Invoke(new object[] { message });
                        return instance;
                    }
                    else
                    {
                        throw new Mood_Analyser_Custom_Exception(Mood_Analyser_Custom_Exception.ExceptionType.NO_SUCH_CLASS, "Class not found");
                        throw new Mood_Analyser_Custom_Exception(Mood_Analyser_Custom_Exception.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                    }
                }
                else
                {
                    throw new Mood_Analyser_Custom_Exception(Mood_Analyser_Custom_Exception.ExceptionType.NO_SUCH_CLASS, "Class not found");

                }
            }

            //below code is UC6
            /// <summary>
            /// Using Reflection to invoke AnalyseMood Method
            /// </summary>
            /// <param name="message"></param>
            /// <param name="methodName"></param>
            /// <returns></returns>
            public static string InvokeAnalyserMood(string message, string methodName)
            {
                try
                {
                    Type type = Type.GetType("Day20_MoodAnalyser.Mood_Analyser");
                    object moodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("Day20_MoodAnalyser.Mood_Analyser", "Mood_Analyser", message);
                    MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                    object mood = analyseMoodInfo.Invoke(moodAnalyserObject, null);
                    return mood.ToString();
                }
                catch (NullReferenceException)
                {
                    throw new Mood_Analyser_Custom_Exception(Mood_Analyser_Custom_Exception.ExceptionType.NO_SUCH_METHOD, "Method is Not Found");
                }
            }


            //below code is UC7
            /// <summary>
            /// Function to Set The Field Dynamically using Reflection.
            /// </summary>
            /// <param name="moodAnalyseobject"></param>
            /// <param name="fieldName"></param>
            /// <returns></returns>
            public static string SetField(string message, string fieldName)
            {
                try
                {
                    Mood_Analyser moodAnalyser = new Mood_Analyser();
                    Type type = typeof(Mood_Analyser);
                    FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                    if (message == null)
                    {
                        throw new Mood_Analyser_Custom_Exception(Mood_Analyser_Custom_Exception.ExceptionType.NO_SUCH_FIELD, "Message should not be null");
                    }
                    field.SetValue(moodAnalyser, message);
                    return moodAnalyser.message;
                }
                catch (NullReferenceException)
                {
                    throw new Mood_Analyser_Custom_Exception(Mood_Analyser_Custom_Exception.ExceptionType.NO_SUCH_FIELD, "Field is not Found");
                }
            }
        }
}



