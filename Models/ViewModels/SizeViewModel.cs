using System.ComponentModel.DataAnnotations.Schema;

namespace Models.ViewModels
{
    [Table("SizeModel")]
    public class SizeViewModel
    {        
        public long Id { set; get; }
        public string Name { set; get; }
    }
}
