using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace Teknologiks.Kursus.Website.Models
{
    public class Customer : TableEntity
    {
        public Customer(string area, string customerNumber)
        {
            PartitionKey = area;
            RowKey = customerNumber;
        }

        public Customer()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Category { get; set; }
        
    }
}
