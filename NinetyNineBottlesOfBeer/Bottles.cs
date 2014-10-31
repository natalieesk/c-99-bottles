namespace NinetyNineBottlesOfBeer
{
    public interface IVerseProvider
    {
        string GetVerse(int bottles);
    }

    public class MultipleUpperMultipleLowerVerseProvider : IVerseProvider
    {
        public string GetVerse(int bottles)
        {
            return string.Format("{0} bottles of beer on the wall, {0} bottles of beer.\r\nTake one down and pass it around, {1} bottles of beer on the wall.", bottles, bottles - 1);
        }
    }

    public class MultipleUpperSingularLowerVerseProvider : IVerseProvider
    {
        public string GetVerse(int bottles)
        {
            return string.Format("{0} bottles of beer on the wall, {0} bottles of beer.\r\nTake one down and pass it around, {1} bottle of beer on the wall.", bottles, bottles - 1);
        }
    }

    public class PenultimateVerseProvider : IVerseProvider
    {
        public string GetVerse(int bottles)
        {
            return string.Format("{0} bottle of beer on the wall, {0} bottle of beer.\r\nTake it down and pass it around, no more bottles of beer on the wall.", bottles);
        }
    }


    public class LastVerseProvider : IVerseProvider
    {
        public string GetVerse(int bottles)
        {
            return
                "No more bottles of beer on the wall, no more bottles of beer.\r\nGo to the store and buy some more, 99 bottles of beer on the wall.";
        }
    }

    public class Bottles
    {
        public string Verse(int num)
        {
            var verseProvider = GetVerseProvider(num);
            return verseProvider.GetVerse(num);
        }

        private IVerseProvider GetVerseProvider(int num)
        {
            if (num > 2)
            {
                return new MultipleUpperMultipleLowerVerseProvider();
            }
            else if (num == 2)
            {
                return new MultipleUpperSingularLowerVerseProvider();
            }
            else if (num == 1)
            {
                return new PenultimateVerseProvider();
            }

            return new LastVerseProvider();
        }

        public string Verse(int upperBound, int lowerBound)
        {

            string finalAnswer = "";
            for (int i = upperBound; i >= lowerBound; i--)
            {
                finalAnswer += GetVerseProvider(i).GetVerse(i) + "\r\n\r\n";
            }
            return finalAnswer;
        }
    }
}
