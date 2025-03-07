namespace MyFirstProject
{
    public abstract class BoardGameBase : IBoardGame
    {

        public string BoardGameName { get; private set; }
        public string CurrentFileName;

        public BoardGameBase(string name)
        {
            this.BoardGameName = name;
        }

        //public delegate void ReviewAddedDelegate(object sender, EventArgs args);

        //public abstract event ReviewAddedDelegate ReviewAdded;

        public abstract void AddReviewPoints(float numberOfPionts);

        //public void AddReviewPoints(float numberOfPionts)
        //{
        //    if (numberOfPionts >= 0 && numberOfPionts <= 10)
        //    {
        //        using (var writer = File.AppendText(CurrentFileName))
        //        {
        //            writer.WriteLine(numberOfPionts);
        //        }

        //        if (ReviewAdded != null)
        //        {
        //            ReviewAdded(this, new EventArgs());
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("Podana liczba musi znajdować się w zakresie 0-10");
        //    }
        //}

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

        //public abstract Statistics GetStatistics();

    }
}
