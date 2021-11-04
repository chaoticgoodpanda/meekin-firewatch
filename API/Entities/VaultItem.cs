using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    [Table("VaultItems")]
    public class VaultItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        
        //navigation properties
        public string PostId { get; set; }
        
        public Facebook.Post Post { get; set; }
        
        // EF Core setups so Vaults cannot exist without Posts
        public int VaultId { get; set; }
        public Vault Vault { get; set; }
    }
}