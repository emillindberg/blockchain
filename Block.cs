using System.Security.Cryptography;
using System.Text;

namespace Blockchain.Models
{
    public class Block
    {
        public Block(Transaction _transaction)
        {
            this.transaction = _transaction;
            this.date = DateTime.UtcNow;
            this.hash = sha256(_transaction);
        }
        public Transaction transaction { get;}
        public DateTime date { get; }
        public string hash { get; }


        static string sha256(Transaction _transaction)
        {

            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(_transaction.sender + _transaction.recipient + _transaction.amount.ToString()));

            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

    }
}
