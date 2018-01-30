using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Backend.Models;
using RecipeApp.Service.Commands.Recipes;
using RecipeApp.Service.Interfaces.Dispatchers;
using RecipeApp.Service.Queries.Recipes;
using RecipeApp.Shared.Models;

namespace RecipeApp.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/recipes")]
    public class RecipeController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IMapper _mapper;

        public RecipeController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher, IMapper mapper)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
            _mapper = mapper;
        }

        // GET: api/Recipe
        [HttpGet]
        public async Task<IActionResult> GetRecipesAsync([FromQuery]GetRecipesQueryFilters filters, CancellationToken cancellationToken)
        {
            var query = new GetRecipesQuery();

            var recipes = await _queryDispatcher
                .HandleAsync<GetRecipesQuery, IEnumerable<Recipe>>(query, cancellationToken).ConfigureAwait(false);

            var recipeViewModels = _mapper.Map<IEnumerable<RecipeViewModel>>(recipes);

            return Ok(recipeViewModels);
        }

        // GET: api/Recipe/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Recipe
        [HttpPost]
        public async Task<IActionResult> AddRecipesAsync([FromBody]CreateRecipeModel recipe, CancellationToken cancellationToken)
        {
            if (recipe == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newRecipe = _mapper.Map<Recipe>(recipe);

            var command = new AddRecipeCommand() {Recipe = newRecipe};
            await _commandDispatcher.HandleAsync(command, cancellationToken).ConfigureAwait(false);

            return Created("/api/v1/recipes", newRecipe);
        }
        
        // PUT: api/Recipe/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
