using Microsoft.AspNetCore.Mvc;
using OnlineTest.API.Models;
using OnlineTestWithMongoDB.API.Service;

namespace OnlineTestWithMongoDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService) => _questionService = questionService;

        [HttpGet]
        public async Task<List<Questions>> Get() => await _questionService.GetAsync();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Questions>> Get(int id)
        {
            var question = await _questionService.GetAsync(id);

            if (question is null)
            {
                return NotFound();
            }

            return question;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Questions newQuestions)
        {
            await _questionService.CreateAsync(newQuestions);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(int id, Questions updatedQuestions)
        {
            var question = await _questionService.GetAsync(id);

            if (question is null)
            {
                return NotFound();
            }

            updatedQuestions.QuestionID = question.QuestionID;

            await _questionService.UpdateAsync(id, updatedQuestions);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(int id)
        {
            var question = await _questionService.GetAsync(id);

            if (question is null)
            {
                return NotFound();
            }

            await _questionService.RemoveAsync(id);

            return NoContent();
        }
    }
}
