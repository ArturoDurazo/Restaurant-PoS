using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Single
{
    class Transaction
    {
        int transactionId;
        int totalCost;
        int status;
        DateTime createdAt;
        List<String> itemList;
        public Transaction()
        {
            transactionId = -1;
            totalCost = -1;
            status = -1;
            createdAt = DateTime.Now;
            itemList = new List<String>();
        }

        public int getTransactionId()
        {
            return transactionId;
        }
        public void setTransactionId(int transactionId)
        {
            this.transactionId = transactionId;
        }

        public int getTotalCost()
        {
            return totalCost;
        }
        public void setTotalCost(int totalCost)
        {
            this.totalCost = totalCost;
        }

        public int getStatus()
        {
            return status;
        }
        public void setStatus(int status)
        {
            this.status = status;
        }

        public DateTime getCreatedAt()
        {
            return createdAt;
        }

        public void setCreatedAt(DateTime createdAt)
        {
            this.createdAt = createdAt;
        }

        public List<String> getItemList()
        {
            return itemList;
        }

        public void addItem(String item)
        {
            itemList.Add(item);
        }

    }
}
