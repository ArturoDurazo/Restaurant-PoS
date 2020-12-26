using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Single
{
    class Item
    {
        private int category;
        private int itemId;
        private Image thumbnail;
        private String name;
        private String description;
        private int price;
        private bool available;
        private bool toggled;

        public Item(int category,int itemId, Image thumbnail, String name, String description, int price, bool available, bool toggled)
        {
            this.category = category;
            this.itemId = itemId;
            this.thumbnail = thumbnail;
            this.name = name;
            this.description = description;
            this.price = price;
            this.available = available;
            this.toggled = toggled;
        }

        public int getCategory()
        {
            return category;
        }

        public int getId()
        {
            return itemId;
        }

        public Image getThumbnail()
        {
            return thumbnail;
        }

        public String getName()
        {
            return name;
        }

        public String getDescription()
        {
            return description;
        }

        public int getPrice()
        {
            return price;
        }

        public Boolean getAvailable()
        {
            return available;
        }

        public Boolean getToggled()
        {
            return toggled;
        }

    }
}
