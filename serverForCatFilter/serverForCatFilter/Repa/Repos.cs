using serverForCatFilter.Context;
using serverForCatFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serverForCatFilter.Repa
{
    public class Repos :IRepos
    {
        public IList<Cat> GetAllCats()
        {
            using(var db = new Db())
            {
                var Cats = db.Cats.ToList();
                return Cats;
            }
        }
        public void PostCat(Cat cat)
        {
            using (var db = new Db())
            {
                db.Cats.Add(cat);
                db.SaveChanges();
            }
        }
        public void DeleteCat(int id)
        {
           
            using (var db = new Db())
            {
                var cat = db.Cats.Where(c => c.Id == id).FirstOrDefault();
                db.Cats.Remove(cat);
                db.SaveChanges();
            }
        }
        public List<Cat> BreedCat(string breed)
        {

            using (var db = new Db())
            {
                var cat = db.Cats.Where(c => c.Breed == breed).ToList<Cat>();
                return cat;
            }
        }
        public List<Cat> SortCat(string cat)
        {

            using (var db = new Db())
            {
                List<Cat> catsort;
                if (cat=="Age"|| cat=="age")
                {
                    catsort = db.Cats.OrderBy(c=>c.Age).ToList<Cat>();
                    return catsort;
                }
                if (cat =="Name"||cat=="name")
                {
                    catsort = db.Cats.OrderBy(c => c.Name).ToList<Cat>();
                    return catsort;
                }
                else
                {
                    catsort = db.Cats.OrderBy(c => c.Name).ToList<Cat>();
                    return catsort;
                }
                
            }
        }
        public List<Cat> TakeCat(int t)
        {
            List<Cat> take;

            using (var db = new Db())
            {
                take = db.Cats.Take(t).ToList();
                return take;
            }
        }
    }
}
