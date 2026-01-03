using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using LottoManager.Domain.Common;

namespace LottoManager.Domain.Models;

public class Lottery : BaseEntity
{
    private string _name = string.Empty;
    public required string Name 
    { 
        get => _name;
        set 
        {
            _name = value;
            Slug = GenerateSlug(value);
        }
    }

    public string Slug { get; private set; } = string.Empty;

    public byte MinNumber { get; set; } = 1;

    public byte MaxNumber { get; set; }

    public byte NumbersToDraw { get; set; }
    
    public ushort SingleBetPrice { get; set; }
    
    public byte MaxBetNumberAmount  { get; set; }

    public List<LotteryPrizeHit> PrizeHits { get; set; } = [];

    private string GenerateSlug(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return string.Empty;
        
        string str = name.ToLowerInvariant().Trim();
        
        string normalizedString = str.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();

        foreach (char c in normalizedString)
        {
            UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
            if (category != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }
        
        string result = sb.ToString().Normalize(NormalizationForm.FormC);
        
        result = result.Replace(" ", "-");
        
        result = Regex.Replace(result, @"[^a-z0-9\-]", "");
        result = Regex.Replace(result, @"\-{2,}", "-");

        return result;
    }
}