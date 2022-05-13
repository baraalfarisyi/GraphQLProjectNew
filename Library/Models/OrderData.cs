namespace Library.Models
{
    public class OrderData
    {
     
        public string UserName { get; set; }
        public string Code { get; set; }

        public List<ODetail> Details { get; set; }
    }

}
