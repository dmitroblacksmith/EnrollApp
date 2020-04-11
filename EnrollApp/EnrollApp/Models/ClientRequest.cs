namespace EnrollApp.Models
{
    public class ClientRequest
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public string Question { get; set; }
        public int? OfferId { get; set; }
        public Offer Offer { get; set; }
        public int ClientRequestStateId { get; set; }
        public ClientRequestState ClientRequestState { get; set; }
    }
}