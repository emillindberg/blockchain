using System.Security.Cryptography;
using System.Text;
using Blockchain.Models;

//Skapar blockkedjan
List<Block> chain = new List<Block>();

//Skapar och lägger till första blocket (genesisblocket)
var genesisBlock = new Block(new Transaction("", "", 0));
chain.Add(genesisBlock);


while (true)
{
    Console.Clear();

    Console.WriteLine("1. Skapa ny transaktion");
    Console.WriteLine("2. Visa alla block");
    Console.WriteLine("3. Visa saldo");

    var val = Int32.Parse(Console.ReadLine());

    switch (val)
    {
        case 1:
            Console.Clear();

            Console.WriteLine("Ange den som skickar");
            var skickare = Console.ReadLine();

            Console.WriteLine("Ange den som tar emot");
            var mottagare = Console.ReadLine();

            Console.WriteLine("Ange hur mycket som skickas");
            var summa = float.Parse(Console.ReadLine());

            Block newBlock = new Block(new Transaction(skickare, mottagare, summa));
            chain.Add(newBlock);

            Console.WriteLine("Minar block...");

            Console.WriteLine("Block klart");

            Console.ReadLine();

            break;

        case 2:
            Console.Clear();

            foreach (var block in chain)
            {
                Console.WriteLine(block.hash);
                Console.WriteLine(block.date);
                Console.WriteLine($"{block.transaction.sender} skickade {block.transaction.amount} till {block.transaction.recipient}");
                Console.WriteLine("###################################");
                Console.WriteLine();
            }

            Console.WriteLine("Alla block");

            Console.ReadLine();

            break;

        case 3:
            Console.Clear();

            Console.WriteLine("Ange adress");

            string address = Console.ReadLine();

            float sum = 0;

            foreach (var block in chain)
            {
                if(block.transaction.recipient == address)
                {
                    sum += block.transaction.amount;
                }else if(block.transaction.sender == address)
                {
                    sum-= block.transaction.amount;
                }
            }

            Console.WriteLine($"Summan för adressen {address} är {sum}");

            Console.ReadLine();

            break;
    }

}

