namespace MyFirstProject
{
    public class BoardGame : BoardGameBase
    {
       // public override event GradeAddedDelegate GradeAdded;
        public BoardGame(string name) //konstruktor
            : base(name)
        {
        }

        private List<float> score = new List<float>();

        public override void AddReviewPoints(float numberOfPionts)
        {
            if (numberOfPionts >= 0 && numberOfPionts <= 10)
            {
                this.score.Add(numberOfPionts);

                //if (GradeAdded != null)
                //{
                //    GradeAdded(this, new EventArgs());
                //}
            }
            else
            {
                throw new Exception("Podana liczba musi znajdować się w zakresie 0-10");
            }
        }
        //public override Statistics GetStatistics()
        //{
        //    var statistics = new Statistics();
        //    foreach (var item in this.score)
        //    {
        //        statistics.AddScore(item);
        //    }
        //    if (statistics.Count > 0)
        //    {
        //        return statistics;
        //    }
        //    else
        //    {
        //        throw new Exception("Ten pracownik nie ma żadnych ocen");
        //    }

        //}


    }
}
