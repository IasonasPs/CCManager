using CCManager.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace CCManager.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        static List<Candidate> candidates = new List<Candidate>
        {
            new Candidate
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateOnly(1990, 5, 15),
                Email = "john.doe@example.com"
            },
            new Candidate
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateOnly(1985, 10, 22),
                Email = "jane.smith@example.com"
            },
            new Candidate
            {
                Id = 3,
                FirstName = "Alice",
                LastName = "Johnson",
                DateOfBirth = new DateOnly(1992, 3, 9),
                Email = "alice.johnson@example.com"
            }
        };

        [HttpGet("GetCa/{id}")]
        public ActionResult Get(int id)
        {
            if (id > candidates.Count - 1)
            {
                return NoContent();
            }
            return Ok(candidates[id]);
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            if (candidates.Count <= 0)
            {
                return NotFound();
            }
            return Ok(candidates);
        }


        [HttpPost("CreateCandidate")]
        public ActionResult<Candidate> Post(int id , string fname , string lname , DateOnly bdate , string mailAddress)
        {
            Candidate candidate = new Candidate { Id = id, FirstName = fname, LastName = lname, DateOfBirth = bdate, Email = mailAddress };

            candidates.Add(candidate);

            return Ok(candidate);
        }

        [HttpPut("UpdateCandidate/{id}")]
        public ActionResult Put(int id, string fname, string lname, DateOnly bdate, string mailAddress)
        {
            if (id > candidates.Count)
            {
                return NotFound();
            }

            var candidate = candidates.First(c => c.Id == id);

            candidate.FirstName = fname;
            candidate.LastName = lname;
            candidate.DateOfBirth = bdate;
            candidate.Email = mailAddress;

            return Ok(candidate);
        }

        [HttpDelete("DeleteCandidate/{id}")]
        public ActionResult Delete(int id)
        {
            //if (id > candidates.Count)
            //{
            //    return NotFound();
            //}

            var candidate = candidates.First(c => c.Id == id);

            candidates.Remove(candidate);

            return Ok();
        }

    }
}
