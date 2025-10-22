namespace CostCalculator
{
    public static class Calculator
    {
        public static float NewCost(List<float> allCosts)
        {
            float output = 0;

            if (allCosts.Count >= 2)
            {
                float HighestNumber = 0;
                float SecondHigestNumber = 0;

                foreach (float cost in allCosts)
                {
                    if (cost > HighestNumber)
                    {
                        SecondHigestNumber = HighestNumber;
                        HighestNumber = cost;
                    }
                }

                output = (HighestNumber + (SecondHigestNumber / 2)) * 1.25f;
            }
            else if (allCosts.Count == 1)
            {
                output = allCosts[0] * 1.25f;
            }
            else
            {
                output = 1;
            }

                return output;
        }
    }
}
