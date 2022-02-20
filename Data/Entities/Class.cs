
using Dapper;

namespace Data.Entities
{
  public  class Class
    {
        [Key]
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
