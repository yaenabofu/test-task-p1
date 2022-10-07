using System;

namespace api.Models.DatabaseObjects
{
    public class Worker
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string ThirdName { get; set; }
        public DateTime Birthday { get; set; }
        public string Snils { get; set; }
        public int CompanyId { get; set; }
    }
}
