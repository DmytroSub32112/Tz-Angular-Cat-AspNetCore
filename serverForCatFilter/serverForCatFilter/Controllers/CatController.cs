using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using serverForCatFilter.Models;
using serverForCatFilter.Repa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serverForCatFilter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController : ControllerBase
    {
        IRepos _repa;
        
        public CatController(IRepos repos)
        {
            _repa = repos;
        }
        [Route("/Cat")]
        [HttpGet]
        public IEnumerable<Cat> Get()
        {
            var cat = _repa.GetAllCats();
            return cat;
        }
        [Route("/Cat")]
        [HttpPost]
        public void Post(Cat cat)
        {
            var Cat = new Cat() { Age = cat.Age, Breed = cat.Breed, Info = cat.Info, Name = cat.Name, Url = cat.Url };
            _repa.PostCat(Cat);
        }
         [ Route("/Cat/{id}")]
            [HttpDelete]
        public void DeleteCat(int id)
        {
            _repa.DeleteCat(id);
        }
        [Route("/CatBreed")]
        [HttpPost]
        public List<Cat> Breed(Cat breed)
        
        {
            var Breadd = breed.Breed;
            var cat = _repa.BreedCat(Breadd);
            return cat;
        }
        [Route("/CatSort")]
        [HttpPost]
        public List<Cat> Sort(Cat sort)

        {
            var str = sort.Breed;
            var cat = _repa.SortCat(str);
            return cat;
        }
        [Route("/CatTake")]
        [HttpPost]
        public List<Cat> Take(Cat take)

        {
            var str = take.Age;
            var cat = _repa.TakeCat(str);
            return cat;
        }

    }
}
