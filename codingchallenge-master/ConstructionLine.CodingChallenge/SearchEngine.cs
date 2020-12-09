using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.
            // Create pre empty ColorCount etc if needed

        }


        public SearchResults Search(SearchOptions options)
        {
            // Match Shirts
            var filteredSizeOrders = _shirts.Where(o => options.Sizes.Contains(o.Size));
            var filteredColourOrders = _shirts.Where(o => options.Colors.Contains(o.Color));
            var matchingShirts = filteredSizeOrders.Union(filteredColourOrders).ToList();
            
            var colorList = new List<ColorCount>();
            var sizeList = new List<SizeCount>();


            var returnedSizes = matchingShirts.Select(x => x.Size)
                .GroupBy(x => x.Name).Select(group => new { 
                    Size = group.Key, 
                    Count = group.Count() 
                }).ToList();
            
            var returnedColours = matchingShirts.Select(x => x.Color)
                .GroupBy(x => x.Name).Select(group => new { 
                    Color = group.Key, 
                    Count = group.Count() 
                }).ToList();
            
            foreach (var color in Color.All)
            {

                var test = returnedColours.Where(x => x.Color == color.Name).Select(x => x.Count).SingleOrDefault();
                var test2 = returnedColours.Where(x => x.Color == color.Name).Select(x => x.Count);
                colorList.Add(new ColorCount
                {
                    Color = color,
                    Count = returnedColours.Where(x => x.Color == color.Name).Select(x => x.Count).SingleOrDefault()
                });
            }
            
            foreach (var size in Size.All)
            {
                sizeList.Add(new SizeCount
                {
                    Size = size,
                    Count = returnedSizes.Where(x => x.Size == size.Name).Select(x => x.Count).SingleOrDefault()
                });
            }
            
            return new SearchResults
            {
                Shirts = matchingShirts,
                SizeCounts = sizeList,
                ColorCounts = colorList
            };
        }
    }
}