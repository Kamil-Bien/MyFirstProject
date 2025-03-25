using static MyFirstProject.BoardGameBase;

namespace MyFirstProject
{
    internal interface IBoardGame
    {
            string BoardGameName { get; }

            event ReviewAddedDelegate ReviewAdded;

            void FileSelection(string subjectName);
            void AddReviewPoints(float numberOfPionts);
            void AddReviewPoints(string numberOfPionts);
            void AddReviewPoints(decimal numberOfPionts);
            void AddReviewPoints(int numberOfPionts);
            
            Statistics GetStatistics();
        
    }
}
