namespace MyFirstProject
{
    internal interface IBoardGame
    {
            string BoardGameName { get; }

            //event GradeAddedDelegate GradeAdded;

            void AddReviewPoints(float numberOfPionts);
            void AddReviewPoints(string numberOfPionts);
            void AddReviewPoints(decimal numberOfPionts);
            void AddReviewPoints(int numberOfPionts);
            
            //Statistics GetStatistics();
        
    }
}
