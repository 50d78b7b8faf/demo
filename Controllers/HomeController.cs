using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.DTO;
using Web.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiCocktailService _apiCocktailService;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IApiCocktailService cocktailService, IUnitOfWork unitOfWork)
        {
            _apiCocktailService = cocktailService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index() => View();

        [Route("Cocktail/Coincidences")]
        [HttpGet]
        public async Task<IActionResult> Coincidences(string name)
        {
            var apiResponse = ApiResponseDto.Ok();
            apiResponse.Result = await _apiCocktailService.GetCocktailsAsync(name);
            return StatusCode(apiResponse.StatusCode, apiResponse);
        }

        [Route("Cocktail/Set")]
        [HttpPost]
        public async Task<IActionResult> SetCocktail([FromBody] List<CocktailDto> lstData)
        {
            var apiResponse = ApiResponseDto.Ok();

            foreach (var cocktailDto in lstData)
            {
                await _unitOfWork.CocktailRepository.AddAsync(new Cocktail
                {
                    Ingredients = string.Join(",", cocktailDto.Ingredients),
                    Instructions = cocktailDto?.Instructions,
                    Name = cocktailDto?.Name,   
                });
            }
            await _unitOfWork.CompleteAsync();
            return StatusCode(apiResponse.StatusCode, apiResponse);
        }
    }
}