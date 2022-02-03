using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerLangUp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerLangUp.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : Controller
    {
        private readonly TestContext context;
        public TestsController(TestContext context)
        {   
            this.context = context;
        }
        public async Task<ActionResult<IEnumerable<Test>>> Get(
            [FromQuery]string login, 
            [FromQuery]string password, 
            [FromQuery]string mainLang,
            [FromQuery]string learnLang)
        {
            if (login == null && password == null)
                return new List<Test>() { new Test() { TestId = -1 } };

            User user = context.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password).Result;
            
            if (user == null)
                return new List<Test>() { new Test() { TestId = -1 } };

            List<Test> userTests = await context.UserTests.Where(x => x.UserId == user.UserId).Select(x => x.Test).ToListAsync();

            if (mainLang == null)
            {
                if (learnLang == null)
                    return userTests;
                else
                    userTests = userTests.Where(x => x.LearnedLanguage == learnLang).ToList();
            }
            else
            {
                userTests = userTests.Where(x => x.MainLanguge == mainLang).ToList();
                if (learnLang != null)
                    userTests = userTests.Where(x => x.LearnedLanguage == learnLang).ToList();
            }
            return userTests;


        }
    }
}
