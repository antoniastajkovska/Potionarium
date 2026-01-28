using Potionarium.Domain.DomainModels;
using Potionarium.Domain.Identity;

public class BrewedPotion : BaseEntity
{
    public Guid PotionId { get; set; }
    public Potion Potion { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public int Quantity { get; set; }
    public DateTime BrewedOn { get; set; }
}
