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
        private Image thumbnail;
        private String name;
        private String description;
        private Decimal price;
        private Boolean available;

        public Item(int category, Image thumbnail, String name, String description, Decimal price, Boolean available)
        {
            this.category = category;
            this.thumbnail = thumbnail;
            this.name = name;
            this.description = description;
            this.price = price;
            this.available = available;
        }

        public int getCategory()
        {
            return category;
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

        public Decimal getPrice()
        {
            return price;
        }

        public Boolean getAvailable()
        {
            return available;
        }

    }
}
