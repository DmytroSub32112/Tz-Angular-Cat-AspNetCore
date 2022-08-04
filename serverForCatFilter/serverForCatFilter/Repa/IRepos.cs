using serverForCatFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serverForCatFilter.Repa
{
    public interface IRepos
    {
        public IList<Cat> GetAllCats();
        public void PostCat(Cat cat);
        public void DeleteCat(int id);
        public List<Cat> BreedCat(string breed);
        public List<Cat> SortCat(string cat);
        public List<Cat> TakeCat(int t);
    }
}
