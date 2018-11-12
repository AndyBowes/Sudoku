﻿using System.Collections.Generic;

namespace Sudoku
{
    class PencilMarkReducer
    {
        private readonly IPencilMarkReducer[] reducers = new IPencilMarkReducer[]
        {
                new CandidateLines(),
                new DoublePairs()
        };

        internal List<string> Reduce(Grid grid, PencilMarks pencilMarks)
        {
            var results = new List<string>();
            var previousCount = -1;
            while (results.Count > previousCount)
            {
                previousCount = results.Count;
                foreach (var reducer in reducers)
                    results.AddRange(reducer.Evaluate(grid, pencilMarks));
            }

            return results;
        }
    }
}