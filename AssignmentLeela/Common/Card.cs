using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AssignmentLeela.Common.Card;

namespace AssignmentLeela.Common
{
  public class CardInDeck
    {
        public CardValue cardValue { get; set; }
        public Suit suit { get; set; }
        public CardInDeck(string cardValue, string suitValue)
        {
            this.cardValue = (CardValue)Enum.Parse(typeof(CardValue),cardValue, true); 
            this.suit = (Suit)Enum.Parse(typeof(Suit), suitValue, true);
        } 
    }
}
