namespace MyFirstProject
{
    public class Statistics
    {
        public float Sum { get; private set; }
        public int Count { get; private set; }
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
        }

        public void CalculatePointsFromList(float numberOfPionts)
        {
            this.Count++;
            this.Sum += numberOfPionts;
        }

    }
}
