using Microsoft.AspNetCore.Mvc;
using Models.BloodBankEntry;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class BloodBankController : ControllerBase
{
    private static List<BloodBankEntry> bloodBankEntries = new List<BloodBankEntry>
    {
        new BloodBankEntry
        {
            Id = 1,
            DonorName = "Nishant",
            Age = 20,
            BloodType = "A+",
            ContactInfo = "nishantgk2004@gmail.com",
            Quantity = 500,
            CollectionDate = System.DateTime.Now.AddDays(-5),
            ExpirationDate = System.DateTime.Now.AddMonths(1),
            Status = "Available"
        },
        new BloodBankEntry
        {
            Id = 2,
            DonorName = "Nikhil",
            Age = 21,
            BloodType = "O-",
            ContactInfo = "nikhil@gmail.com",
            Quantity = 450,
            CollectionDate = System.DateTime.Now.AddDays(-10),
            ExpirationDate = System.DateTime.Now.AddDays(20),
            Status = "Requested"
        },
        new BloodBankEntry
        {
            Id = 3,
            DonorName = "John",
            Age = 25,
            BloodType = "C-",
            ContactInfo = "john@gmail.com",
            Quantity = 300,
            CollectionDate = System.DateTime.Now.AddDays(-2),
            ExpirationDate = System.DateTime.Now.AddMonths(2),
            Status = "Available"
        }
    };

    [HttpGet]
    public ActionResult<IEnumerable<BloodBankEntry>> GetAll()
    {
        return bloodBankEntries; 
    }

    [HttpGet("{id}")]
    public ActionResult<BloodBankEntry> GetById(int id)
    {
        var entry = bloodBankEntries.FirstOrDefault(e => e.Id == id);
        if (entry == null) return NotFound();
        return entry;
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEntry(int id, BloodBankEntry newEntry)
    {
        var entry = bloodBankEntries.FirstOrDefault(e => e.Id == id);
        if (entry == null) return NotFound();
        entry.DonorName = newEntry.DonorName;
        entry.Age = newEntry.Age;
        entry.BloodType = newEntry.BloodType;
        entry.ContactInfo = newEntry.ContactInfo;
        entry.Quantity = newEntry.Quantity;
        entry.CollectionDate = newEntry.CollectionDate;
        entry.ExpirationDate = newEntry.ExpirationDate;
        entry.Status = newEntry.Status;
        return NoContent();
    }

    [HttpPost]
    public ActionResult<BloodBankEntry> AddEntry(BloodBankEntry newEntry)
    {
        newEntry.Id = bloodBankEntries.Last().Id + 1;
        bloodBankEntries.Add(newEntry);
        return newEntry;
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEntry(int id)
    {
        var entry = bloodBankEntries.FirstOrDefault(e => e.Id == id);
        if (entry == null) return NotFound();
        bloodBankEntries.Remove(entry);
        return NoContent();
    }

    [HttpGet("search/type/{bloodType}")]
    public ActionResult<IEnumerable<BloodBankEntry>> GetEntriesByType(string bloodType)
    {
        if(string.IsNullOrEmpty(bloodType))
        {
            return NotFound();
        }
        return bloodBankEntries.Where(e => e.BloodType == bloodType).ToList();
    }

    [HttpGet("search/status/{status}")]
    public ActionResult<IEnumerable<BloodBankEntry>> GetEntriesByStatus(string status)
    {
        if(string.IsNullOrEmpty(status))
        {
            return NotFound();
        }
        return bloodBankEntries.Where(e => e.Status == status).ToList();
    }

    [HttpGet("search/donorName/{donorName}")]
    public ActionResult<IEnumerable<BloodBankEntry>> GetEntriesByName(string donorName)
    {
        if (string.IsNullOrEmpty(donorName))
        {
            return NotFound();
        }

        var Entries = bloodBankEntries
            .Where(e => e.DonorName.Contains(donorName, StringComparison.OrdinalIgnoreCase))
            .ToList();
        return Entries;
    }

    [HttpGet("page")]
    public ActionResult<IEnumerable<BloodBankEntry>> GetPageData(int pageNumber, int pageSize)
    {
        return bloodBankEntries.Skip((pageNumber-1) * pageSize).Take(pageSize).ToList();
    }

}
