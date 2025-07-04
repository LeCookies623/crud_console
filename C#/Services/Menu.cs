using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using Carsettings.Models;
using Client.Models;

namespace Services {

    public static class Menu
    {
        public static void ShowMenu()
        {

            List<Car> cars = new List<Car>();
            List<Clientsettings> client = new List<Clientsettings>();

            foreach (var car in cars){
                Console.WriteLine($"Nome: {car.name}, Modelo: {car.model}, Valor: {car.value}");
            }

            foreach (var clients in client) {
                Console.WriteLine($"Nome: {clients.nameClient}, Idade: {clients.age}, Documento: {clients.document}");
            }

            bool executando = true;

            while (executando){

                Console.WriteLine("---------Página de Consultas e Cadastro--------");
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1 - Cadastrar Carro: ");
                Console.WriteLine("2 - Cadastrar Cliente: ");
                Console.WriteLine("3 - Consulte Carros Disponíveis: ");
                Console.WriteLine("4 - Consulte Clientes já Cadastrados! ");
                Console.WriteLine("5 - Editar Dados do Cliente! ");
                Console.WriteLine("6 - Editar Dados do Carro! ");
                Console.WriteLine("7 - Excluir Cadastro Cliente! ");
                Console.WriteLine("8 - Excluir Cadastro Carro! ");
                Console.WriteLine("0 - Sair ");
                
                string option = Console.ReadLine();
                switch (option){

                    case "1":
                        Console.WriteLine("Digite o Nome do Carro:  ");
                        string name = Console.ReadLine();

                        //Parse utilizado para converter string p/ Número
                        Console.WriteLine("Digite o Ano do Carro:  ");
                        int model = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o Valor do Carro: ");
                        int value = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a Cor do Carro: ");
                        string color = Console.ReadLine();


                        Car newCar = new Car(name, model, value, color);

                        cars.Add(newCar); 

                        Console.WriteLine("Carro cadastrado com sucesso!");
                        break;

                    case "2":
                        Console.WriteLine("Qual é o seu nome? ");
                        string nameClient = Console.ReadLine();

                        Console.WriteLine("Qual é a sua idade? ");
                        int age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Poderia me informar seu CPF? ");
                        string document = Console.ReadLine();

                        Clientsettings newclient = new Clientsettings(nameClient, age, document);

                        client.Add(newclient);

                        Console.WriteLine("Cliente Cadastrado com Sucesso!");
                        break;
                    
                    case "3":
                        foreach (var car in cars){
                        Console.WriteLine($"Nome: {car.name}, Modelo: {car.model}, Valor: {car.value}");
                    }
                        break;

                    case "4":
                        foreach (var clients in client) {
                        Console.WriteLine($"Nome: {clients.nameClient}, Idade: {clients.age}, Documento: {clients.document}");
                    }
                        break;
                    
                    case "5":
                            Console.WriteLine("Clientes cadastrados: ");
                        for (int i = 0; i < client.Count; i++)
                        {
                            Console.WriteLine($"[{i}] Nome: {client[i].nameClient}, Idade: {client[i].age}, Documento {client[i].document}");
                        }

                        Console.WriteLine("Digite o número do cliente que deseja atualizar: ");
                        int indexClient = int.Parse(Console.ReadLine());

                        if (indexClient >= 0 && indexClient < client.Count)
                        {
                            Console.WriteLine("Digite o novo nome: ");
                            string editedName = Console.ReadLine();

                            Console.WriteLine("Digite a nova idade: ");
                            int newage = int.Parse(Console.ReadLine());
                            client[indexClient].age = newage;


                            client[indexClient].nameClient = editedName;
                            client[indexClient].age = newage;

                            Console.WriteLine("Cliente atualizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido!");
                        }

                        break;

                    case "6":
                        Console.WriteLine("Carros cadastrados:");

                        //Contador começa com 0 e vai acrescentando conforme adiciona a lista
                        for (int i = 0; i < cars.Count; i++) {
                            Console.WriteLine($"[{i}] Nome: {cars[i].name}, Modelo: {cars[i].model}, Valor: {cars[i].value}");
                        }

                        //Leitura e edição do cadastro carro
                        Console.WriteLine("Digite o número do carro que deseja atualizar: ");
                        int index = int.Parse(Console.ReadLine());

                        Console.WriteLine("Carros cadastrados:");

                        //index é como um "contador"
                        if (index >= 0 && index < cars.Count){
                        
                            Console.WriteLine("Digite o novo nome: ");
                            string newName = Console.ReadLine();

                            cars[index].name = newName;

                            Console.WriteLine("Carro atualizado com sucesso!");
                        } else {
                            Console.WriteLine("Índice inválido!");
                        }
                        
                        break;

                    case "7":
                        //Imprimir novamente a lista já existente.
                        Console.WriteLine("Clientes cadastrados: ");
                        for (int i = 0; i < client.Count; i++)
                        {
                            Console.WriteLine($"[{i}] Nome: {client[i].nameClient}, Idade: {client[i].age}, Documento: {client[i].document}");
                        }

                        Console.WriteLine("Digite o número do cliente que deseja remover: ");
                        int deleteClientIndex = int.Parse(Console.ReadLine());

                        //Verificar se o índice é válido
                        if (deleteClientIndex >= 0 && deleteClientIndex < client.Count)
                        {
                            client.RemoveAt(deleteClientIndex);
                            Console.WriteLine("Cliente removido com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido!");
                        }
                        break;

                    case "8":
                    
                        Console.WriteLine("Carros cadastrados: ");
                        for (int i = 0; i < cars.Count; i++)
                        {
                            Console.WriteLine($"[{i}] Nome: {cars[i].name}, Modelo: {cars[i].model}, Valor: {cars[i].value}, Cor: {cars[i].color}");
                        }

                        Console.WriteLine("Digite o número do carro que deseja remover: ");
                        int deleteCarIndex = int.Parse(Console.ReadLine());

                        if (deleteCarIndex >= 0 && deleteCarIndex < cars.Count)
                        {
                            cars.RemoveAt(deleteCarIndex);
                            Console.WriteLine("Carro removido com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido!");
                        }

                        break;

                    case "0":
                        executando = false;
                        Console.WriteLine("Finalizando sessão!!!");
                        Console.WriteLine("Até a Próxima!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente!");
                        break; 
                }
            }  
        }

    }
}