using AssignmentLeela.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentLeela.Manager
{
    public class CardManager:ICardManager
    {
        private static readonly Dictionary<string, string> valueWordPair = new Dictionary<string, string>
        {
            {"2","Two" },
            {"3","Three" },
            {"4","Four" },
            {"5","Five" },
            {"6","Six" },
            {"7","Seven" },
            {"8", "Eight"},
            {"9","Nine" },
            {"10","Ten" },
            {"J","Jack" },
            {"Q","Queen" },
            {"K","King" },
            {"A","Ace" },
        };
        public Task<List<string>> SortDeckOfCards(List<string> inputList)
        {
            //Converting input list to Type CardInDeck 
            List<CardInDeck> convertedList = new List<CardInDeck>();
            foreach (string c in inputList)
            {
                string cardValue = c.Remove(c.Length - 1, 1);
                string suitValue = c.Substring(c.Length - 1, 1);
                string cardValueString = valueWordPair[cardValue];
                convertedList.Add(new CardInDeck(valueWordPair[cardValue], suitValue));
            }

            //LinQ query to groupby Suit,then sort by  both suit,facevalue
            var query = convertedList.GroupBy(x => x.suit)
                  .Select(y =>
                        new
                        {
                            cardValues = y.OrderBy(x => (int)x.cardValue)
                        })
                  .OrderBy(card => (int)card.cardValues.First().suit).ThenBy(x => (int)x.cardValues.First().cardValue);

            ///converting query result to sorted  object list
            var sortedList = new List<CardInDeck>();
            foreach (var x in query)
            {
                foreach (var y in x.cardValues)
                {
                    sortedList.Add(new CardInDeck(y.cardValue.ToString(),
                                        y.suit.ToString()));
                }
            }
            ///converting sorted object List to input Data Type  
            List<string> result = new List<string>();
            foreach (CardInDeck x in sortedList.Distinct())
            {
                result.Add(valueWordPair.FirstOrDefault(l => l.Value == x.cardValue.ToString()).Key +
                    x.suit.ToString().ToLower());
            }
            return Task.FromResult(result);
        }
    }
}
