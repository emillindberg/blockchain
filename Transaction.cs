namespace Blockchain.Models
{
    public class Transaction
    {
        public Transaction(string _sender, string _recipent, float _amount)
        {
            this.sender = _sender;
            this.recipient = _recipent; 
            this.amount = _amount;
        }

        public string sender { get; }
        public string recipient { get; }
        public float amount { get; }


    }
}