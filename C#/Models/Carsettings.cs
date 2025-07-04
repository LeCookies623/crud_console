namespace Carsettings.Models {

    public class Car{
            public string name;
            public int model;
            public double value;
            public string color;
        
        public Car(string name, int model, double value, string color)
        {
            if (string.IsNullOrEmpty(name)) {
                Console.WriteLine("Nome inválido");
            }

            if (model <= 0){
                Console.WriteLine("Modelo inexistente!");
            }
            
            if (value <= 0){
                Console.WriteLine("Valor inválido ou negativo!");
            }
        
            this.name = name;
            this.model = model;
            this.value = value;
            this.color = color;
        }
    }

}