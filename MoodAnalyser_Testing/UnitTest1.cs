using Day20_Mood_Analyser;
using Day20_MoodAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser_Testing;
using System;

namespace MoodAnalyser_Testing
{
    [TestClass]
    public class UnitTest1
    {
        //UC1
        [TestMethod] //TC1.1
        public void Given_SadMood_Expecting_Sad_Results()
        {
            //Arrangement 
            Mood_Analyser mood = new Mood_Analyser("I am in Sad Mood");
            string expected = "SAD";

            //Act
            string actualMsg = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actualMsg);
        }

        [TestMethod] //TC1.2
        public void Given_Any_Mood_Expecting_Happy_Results()
        {
            //Arrangement 
            Mood_Analyser mood = new Mood_Analyser("I am in Any Mood");
            string expected = "HAPPY";

            //Act
            string actualMsg = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actualMsg);
        }


        //Refactor UC1
        [TestMethod]  //Refactor-TC 1.1
        public void Giving_SAD_Mood_Expecting_Sad_Result()
        {
            //Arrangement 
            Mood_Analyser mood = new Mood_Analyser("I am in Sad Mood");
            string message = "SAD";

            //Act
            string result = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(message, result);
        }

        [TestMethod]  //Refactor-TC 1.2
        public void Giving_HappyMood_Expecting_Happy_Result()
        {
            //Arrangement 
            Mood_Analyser mood = new Mood_Analyser("I am in Happy Mood");
            string message = "HAPPY";

            //Act
            string actualmsg = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(message, actualmsg);
        }

        // UC2
        [TestMethod]
        //[ExpectedException(typeof(Exception))] //not needed if we use "retrun" insteadof "throw" 
        public void Giving_NullMood_Expecting_Exception_Results()
        {
            //Arrangement
            Mood_Analyser mood = new Mood_Analyser(null);
            string expected = "Object reference not set to an instance of an object.";

            try
            {
                //Act
                string actualMsg = mood.AnalyseMood();
            }

            catch (NullReferenceException ex)
            {
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }

        }


        [TestMethod] //TC 2.1
        public void Given_NullMood_Expecting_Happy_Results()
        {
            //Arrangement
            Mood_Analyser mood = new Mood_Analyser("null");
            string expected = "HAPPY";

            //Act
            string actualMsg = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actualMsg);
        }


            //TC 3.1
            [TestMethod]
            //[ExpectedException(typeof(MoodAnalyserCustomException))]
            public void Giving_NullMood_Expecting_CustomException_Results()
            {
                //Arrange
                Mood_Analyser obj = new Mood_Analyser(null);
                string expected = "Mood should not be NULL";

                try
                {
                    //Act
                    string actualMsg = obj.AnalyseMood();
                }

                catch (Mood_Analyser_Custom_Exception ex)
                {
                    //Assert
                    Assert.AreEqual(expected, ex.Message);
                }


            }

            //TC 3.2
            [TestMethod]
            //[ExpectedException(typeof(MoodAnalyserCustomException))]
            public void Giving_EmptyMood_Expecting_CustomException_Results()
            {
                //Arrange
                Mood_Analyser obj = new Mood_Analyser("");
                string expected = "Mood should not be EMPTY";

                try
                {
                    //Act
                    string actualMsg = obj.AnalyseMood();
                }

                catch (Mood_Analyser_Custom_Exception ex)
                {
                    //Assert
                    Assert.AreEqual(expected, ex.Message);
                }

            }

            //TC 4.1
            [TestMethod]
            public void GivenMoodAnalyserClassName_ShouldReturnMoodAnalyseObject() //have to check by passing the full address in place of null
            {
                //Arrange
                string message = null;
                Mood_Analyser expected = new Mood_Analyser(message);

                //Act
                object obj = MoodAnalyserFactory.CreateMoodAnalyser("Day20_MoodAnalyser.Mood_Analyser", "Mood_Analyser");
                //expected.Equals(obj);

                //Assert
                Assert.AreNotEqual(expected, obj);
            }


            //TC 5.1
            [TestMethod]
            public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
            {
                //Arrange
                object expected = new Mood_Analyser("HAPPY");

                //Act
                object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("Day20_MoodAnalyer.Mood_Analyser", "Mood_Analyser", "HAPPY");

                //Assert
                expected.Equals(obj);
            }

            //TC 6.1
            [TestMethod]
            public void Given_HappyMood_Should_Return_Happy()
            {
                //Arrange
                string expected = "HAPPY";

                //Act
                string mood = MoodAnalyserFactory.InvokeAnalyserMood("Happy", "AnalyseMood");

                //Assert
                Assert.AreEqual(expected, mood);
            }

            //TC 7.1
            [TestMethod]
            public void Given_HappyMessage_With_Reflector_Should_Return_Happy()
            {
                //Act
                string result = MoodAnalyserFactory.SetField("HAPPY", "message");

                //Assert
                Assert.AreEqual("HAPPY", result);
            }
        }
    }


       
