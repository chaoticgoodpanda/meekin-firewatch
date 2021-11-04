using System.Collections.Generic;
using System.Linq;
using API.Facebook;

namespace API
{
    public class Vault
    {
        public int Id { get; set; }
        
        // temp randomly generated Id for User who is not signed in yet
        public string UserId { get; set; }

        public List<VaultItem> Items { get; set; } = new List<VaultItem>();

        public void AddItem(List<Post> posts, int quantity)
        {
            var post = posts.Select(p => p.PlatformId);
            var stringPost = string.Join("", post.ToArray() );
            if (Items.All(item => item.PostId != stringPost))
            {
                Items.Add(new VaultItem{Posts = posts, Quantity = quantity});
            }

            var existingItem = Items.FirstOrDefault(item => item.PostId == stringPost);
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