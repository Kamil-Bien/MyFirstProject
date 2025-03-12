namespace MyFirstProject
{
    public class BoardGame : BoardGameBase
    {
        // public override event GradeAddedDelegate GradeAdded;

        private string CurrentFileName = "plikTestowy.txt";
        public BoardGame(string name) //konstruktor
            : base(name)
        {
        }
      
        public override void AddReviewPoints(float numberOfPionts)
        {
            if (numberOfPionts >= 0 && numberOfPionts <= 10)
            {
                using (var writer = File.AppendText(CurrentFileName))
                {
                    writer.WriteLine(numberOfPionts);
                }

                //        if (ReviewAdded != null)
                //        {
                //            ReviewAdded(this, new EventArgs());
                //        }
            }
            else
            {
                throw new Exception("Podana liczba musi znajdować się w zakresie 0-10");
            }
        }
        private List<float> score = new List<float>();
        public override Statistics GetStatistics()
        {
            if (File.Exists(CurrentFileName))
            {
                using (var reader = File.OpenText(CurrentFileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var singleValue = float.Parse(line);
                        score.Add(singleValue);
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception("plik nieistnieje");
            }

            var statistics = new Statistics();

            foreach (var item in this.score)
            {
                statistics.CalculatePointsFromList(item);
            }
            if (statistics.Count > 0)
            {
                return statistics;
            }
            else
            {
                throw new Exception("Ten pracownik nie ma żadnych ocen");
            }
        }
    }
}
