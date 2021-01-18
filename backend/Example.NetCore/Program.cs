using System;
using ClubinhoDoBebe.Infra;
using ClubinhoDoBebe.Infra.FirebaseConnection;
using static System.Console;

namespace Example.NetCore
{
    class Program
    {
        public static void Main()
        {
            ProdutoService firebaseDB = new ProdutoService("https://clubinhodobebe-cd995-default-rtdb.firebaseio.com/");

            ProdutoService firebaseDBTeams = firebaseDB.Node("Teams");

            var data = @"{  
                            'Team-Awesome': {  
                                'Members': {  
                                    'M1': {  
                                        'City': 'Hyderabad',  
                                        'Name': 'Ashish'  
                                        },  
                                    'M2': {  
                                        'City': 'Cyberabad',  
                                        'Name': 'Vivek'  
                                        },  
                                    'M3': {  
                                        'City': 'Secunderabad',  
                                        'Name': 'Pradeep'  
                                        }  
                                   }  
                               }  
                          }";

            WriteLine("GET Request");
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            WriteLine(getResponse.Success);
            if (getResponse.Success) WriteLine(getResponse.JSONContent);
            WriteLine();

            WriteLine("PUT Request");
            FirebaseResponse putResponse = firebaseDBTeams.Put(data);
            WriteLine(putResponse.Success);
            WriteLine();

            WriteLine("POST Request");
            FirebaseResponse postResponse = firebaseDBTeams.Post(data);
            WriteLine(postResponse.Success);
            WriteLine();

            WriteLine("PATH Request");

        }
    }
}
