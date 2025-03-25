namespace MyFirstProject.Test
{

    public class Tests
    {
        [Test]
        public void TestGetStatistics()
        {
            //Arrange
            var gameTest1 = new BoardGame("GraTestowa");
            gameTest1.FileSelection("PlikTestowy");

            //Act
            gameTest1.AddReviewPoints("6");
            gameTest1.AddReviewPoints("10");
            gameTest1.AddReviewPoints("2");
            var result = gameTest1.GetStatistics();
            

            //Assert
            Assert.That(6, Is.EqualTo(result.Average));
        }

    }
}
