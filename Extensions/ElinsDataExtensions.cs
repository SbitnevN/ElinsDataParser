using ElinsDataParser.Data;

namespace ElinsDataParser.Extensions
{
    public static class ElinsDataExtensions
    {
        public static double FindNearestFrequency(this ElinsData data, double frequency)
        {
            foreach (double currentFrequency in data.Frequencies)
            {
                if (currentFrequency > frequency)
                    return currentFrequency;
            }

            return frequency;
        }

        public static void FillPotential(this ElinsData data, double start, double end, double step)
        {
            IEnumerator<Step> enumerator = data.Steps.GetEnumerator();
            for (double current = start; current < end; current += step)
            {
                if (!enumerator.MoveNext())
                    return;

                enumerator.Current.FillPotential(current);
            }
        }
    }
}
