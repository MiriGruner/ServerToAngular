using Microsoft.AspNetCore.Mvc;
using ServerToAngular.Models;

namespace ServerToAngular.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class DonorController : Controller
    {
        public static List<Donor> donors = new List<Donor>
        {
            new Donor(1,"aaa","aaaaaaaaaa","1.png") ,
            new Donor(2,"bbb","bbbbbbbbbb","2.png"),
            new Donor(3,"ccc","cccccccccc","3.png"),
            new Donor(4,"ddd","dddddddddd","4.png")
        };

        [HttpGet]
        public List<Donor> GetDonors()
        {
            return donors;
        }
        [HttpPost]
        public int AddDonor([FromBody] Donor donor)
        {
            if (donor.Id <= 0)
            {
                var max = donors.Max(x => x.Id);
                donor.Id = max + 1;
            }
            donors.Add(donor);
            return donor.Id;
        }

     
        [HttpPut]
        public bool UpdateDonor([FromBody] Donor donor)
        {
            var g = donors.FirstOrDefault(x => x.Id == donor.Id);
            if (g != null)
            {
                g.Name = donor.Name;
                g.Id = donor.Id;
               
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteDonor(int id)
        {
            var d = donors.FirstOrDefault(x => x.Id == id);
            if (d != null)
            {
                donors.Remove(d);
                return true;
            }
            return false;
        }

        [Route("{id}")]
        [HttpGet]
        public Donor GetDonorById(int id)
        {
            return donors.FirstOrDefault(x => x.Id == id);
        }

    }
}

