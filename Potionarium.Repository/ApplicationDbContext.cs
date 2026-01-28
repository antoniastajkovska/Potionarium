using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Potionarium.Domain.Identity;
using Potionarium.Domain.DomainModels;

namespace Potionarium.Repository
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Potion> Potion { get; set; }
        public DbSet<Spell> Spell { get; set; } 
        public DbSet<SpellBook> SpellBook { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<SpellInSpellBook> SpellInSpellBooks { get; set; }
        public DbSet<LearnedSpell> LearnedSpells { get; set; }
        public DbSet<BrewedPotion> BrewedPotions { get; set; }


    }
}
