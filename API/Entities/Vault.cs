using System.Collections.Generic;
using System.Linq;

namespace API
{
    public class Vault
    {
        public int Id { get; set; }
        
        // temp randomly generated Id for User who is not signed in yet
        public string UserId { get; set; }

        public List<VaultItem> Items { get; set; } = new List<VaultItem>();

        public void AddItem(Facebook.Post post, int quantity)
        {
            if (Items.All(item => item.PostId != post.Id))
            {
                Items.Add(new VaultItem{Post = post, Quantity = quantity});
            }

            var existingItem = Items.FirstOrDefault(item => item.PostId == post.Id);
            if (existingItem != null) existingItem.Quantity = existingItem.Quantity = quantity;
        }

        public void RemoveItem(string postId, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.PostId == postId);
            if (item == null) return;
            item.Quantity -= quantity;
            if (item.Quantity == 0) Items.Remove(item);
        }


    }
}