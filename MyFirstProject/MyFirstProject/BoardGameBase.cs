namespace MyFirstProject
{
    public abstract class BoardGameBase : IBoardGame
    {

        public string BoardGameName { get; private set; }
        

        public BoardGameBase(string name)
        {
            this.BoardGameName = name;
        }

        //public delegate void ReviewAddedDelegate(object sender, EventArgs args);

        //public abstract event ReviewAddedDelegate ReviewAdded;

        public abstract void FileSelection(string subjectName);

        public abstract void AddReviewPoints(float numberOfPionts);

        public void AddReviewPoints(string numberOfPionts)
        {
            if (float.TryParse(numberOfPionts, out float resultOfTypeCasting))
            {
                this.AddReviewPoints(resultOfTypeCasting);
            }
            else
            {
                throw new Exception("Błąd rzutowania zmiennej");
            }
        }

        public void AddReviewPoints(decimal numberOfPionts)
        {
            float numberOfPiontsFromDecimalType = (float)numberOfPionts;
            this.AddReviewPoints(numberOfPiontsFromDecimalType);
        }

        public void AddReviewPoints(int numberOfPionts)
        {
            float numberOfPiontsFromIntigerType = (float)numberOfPionts;
            this.AddReviewPoints(numberOfPiontsFromIntigerType);
        }

        public abstract Statistics GetStatistics();

    }
}
