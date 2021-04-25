using System.Collections.Generic;
using DiaryApi.Models;
using DiaryApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace DiaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryEventController : ControllerBase
    {
        private readonly DiaryService _diaryService;

        public DiaryEventController(DiaryService diaryService)
        {
            _diaryService = diaryService;
        }

        [HttpGet]
        public ActionResult<List<DiaryEvent>> Get() =>
            _diaryService.Get();

        [HttpGet("{id:length(24)}", Name = "GetDiary")]
        public ActionResult<DiaryEvent> Get(string id)
        {
            var book = _diaryService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<DiaryEvent> Create(DiaryEvent diaryEvent)
        {
            _diaryService.Create(diaryEvent);

            return CreatedAtRoute("GetDiary", new { id = diaryEvent.Id.ToString() }, diaryEvent);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, DiaryEvent diaryIn)
        {
            var book = _diaryService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _diaryService.Update(id, diaryIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _diaryService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _diaryService.Remove(book.Id);

            return NoContent();
        }
    }
}
