using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentLeela.Manager
{
    public interface ICardManager
    {
        Task<List<string>> SortDeckOfCards(List<string> inputList);
    }
}
