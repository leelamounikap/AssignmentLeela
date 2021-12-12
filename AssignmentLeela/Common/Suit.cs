using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AssignmentLeela.Common
{
    public class Card
    {
        public enum Suit
        {
            D = 0,
            S = 1,
            C = 2,
            H = 3,
        }
        public enum CardValue
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4,
            Six = 5,
            Seven = 6,
            Eight = 7,
            Nine = 8,
            Ten = 9,
            Jack = 10,
            Queen = 11,
            King = 12,
            Ace = 13,
        }
        

    }

}
