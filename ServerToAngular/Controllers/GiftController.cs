using Microsoft.AspNetCore.Mvc;
using ServerToAngular.Models;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
namespace ServerToAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GiftController : ControllerBase
    {
        public static List<Gift> gifts = new List<Gift>
        {
            new Gift(1,"camera","you",250,"good","1.png"),
            new Gift(2,"car","bbb",40,"good","2.png"),
            new Gift(3,"house","ccc",50,"good","3.png"),
            new Gift(4,"gift","aaa",60,"good","4.png")
        };
        [HttpGet]
        public List<Gift> GetGifts()
        {
            return gifts;
        }

        [HttpPost]
        public int AddGift([FromBody] Gift gift)
        {
            if (gift.Id <= 0)
            {
                var max = gifts.Max(x => x.Id);
                gift.Id = max + 1;
            }
            gifts.Add(gift);
            return gift.Id;
        }
        
        [HttpPut]
        public bool UpdateGift([FromBody] Gift gift)
        {
            var g = gifts.FirstOrDefault(x => x.Id == gift.Id);
            if (g != null)
            {
                g.Name = gift.Name;
                g.Donor = gift.Donor;
                g.Price = gift.Price;
                return true;
            }
            return false;
        }
        [Route("{id}")]
        [HttpDelete]
        public bool DeleteGift(int id)
        {
            var g = gifts.FirstOrDefault(x => x.Id == id);
            if (g != null)
            {
                gifts.Remove(g);
                return true;
            }
            return false;
        }
        [Route("{id}")]
        [HttpGet]
        public Gift GetById(int id)
        {
            return gifts.FirstOrDefault(x => x.Id == id);
        }
  }
}
