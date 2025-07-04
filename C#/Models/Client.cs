namespace Client.Models{
        public class Clientsettings{
        public string nameClient;
        public int age;
        public string document;

        public Clientsettings( string nameClient, int age, string document){
            if (string.IsNullOrWhiteSpace(nameClient)){
                Console.WriteLine("Nome inválido!");
            }
            if (age < 18){
                Console.WriteLine("Não pode realizar cadastro por ser menor de idade!");
            }
            if (document.Length != 11){
                Console.WriteLine("Documento inválido! Deve ter 11 dígitos.");
            }

            this.nameClient = nameClient;
            this.age = age;
            this.document = document;

        }
    }
}