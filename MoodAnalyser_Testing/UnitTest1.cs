using Day20_MoodAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser_Testing;


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
            public void Giving_HappyMood_Expecting_Sad_Result()
            {
                //Arrangement 
                Mood_Analyser mood = new Mood_Analyser("I am in Happy Mood");
                string message = "SAD";

                //Act
                string actualmsg = mood.AnalyseMood();

                //Assert
                Assert.AreEqual(message, actualmsg);
            }

            //UC2
            [TestMethod]
            [ExpectedException(typeof(Mood_Analyser_Custom_Exception))]
            public void GivenMoodNull_ShouldThrowException()
            {
                Mood_Analyser obj = new Mood_Analyser(null);
                string result = obj.AnalyseMood();
                Assert.AreEqual("HAPPY", result);

            }


            [TestMethod] //TC 2.1
            public void Given_NullMood_Expecting_Happy_Results()
            {
                //Arrangement
                Mood_Analyser mood = new Mood_Analyser(null);
                string expected = "Happy";

                //Act
                string actualMsg = mood.AnalyseMood();

                //Assert
                Assert.AreEqual(expected, actualMsg);
            }
        }
}

