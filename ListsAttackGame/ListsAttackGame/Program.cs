
using System.Collections.Generic;

namespace ListsGameMetin2;


class Program
{
    public class Character
    {
        
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Ulti { get; set; }
        public double MissRate { get; set; }

    }

    static void Main(string[] args)
    {
        List<Character> characters = new List<Character>
        {
            new Character { Name = "Savaşçi", Attack = 20, Defence = 130 , Ulti = 26, MissRate = 0.1},
            new Character { Name = "Sura", Attack = 25, Defence = 120, Ulti = 30, MissRate = 0.2 },
            new Character { Name = "Şaman", Attack = 23, Defence = 125, Ulti = 26, MissRate = 0.1 },
            new Character { Name = "Ninja", Attack = 22, Defence = 110, Ulti = 25 , MissRate = 0.2}
        };
        //Console.WriteLine(characters[0].Name);
        Console.WriteLine("Characters:");
        foreach (Character character in characters)
        {
            Console.WriteLine($"Name: {character.Name} Attack: {character.Attack} Defence: {character.Defence}");
        }


        while (true)
        {
            Console.WriteLine("Metin2");
            Console.WriteLine("karakter numarası girin:");
            int user = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            int index = rnd.Next(0, 3);
            int userSuccessAttack = 0;
            int pcSuccessAttack = 0;

            int userAttack = characters[user - 1].Attack;
            int userDefence = characters[user - 1].Defence;

            int pcAttack = characters[index].Attack;
            int pcDefence = characters[index].Defence;

            int userUlti = characters[user - 1].Ulti;
            int pcUlti = characters[index].Ulti;

            double userMiss = characters[user - 1].MissRate;
            double pcMiss = characters[index].MissRate;

            bool kullaniciSirasi = true;

            switch (user)
            {
                case 1:
                    Console.WriteLine($"Secilen karakter: {characters[user - 1].Name}, Bilgisayarın karakteri: {characters[index].Name}");
                    Atak(characters, user, index, userSuccessAttack, pcSuccessAttack, kullaniciSirasi, userAttack, userDefence, pcAttack, pcDefence, userMiss, pcMiss, pcUlti, userUlti);
                    break;
                case 2:
                    Console.WriteLine($"Secilen karakter: {characters[user - 1].Name}, Bilgisayarın karakteri: {characters[index].Name}");
                    Atak(characters, user, index, userSuccessAttack, pcSuccessAttack, kullaniciSirasi, userAttack, userDefence, pcAttack, pcDefence, userMiss, pcMiss, pcUlti, userUlti);
                    break;
                case 3:
                    Console.WriteLine($"Secilen karakter: {characters[user - 1].Name}, Bilgisayarın karakteri: {characters[index].Name}");
                    Atak(characters, user, index, userSuccessAttack, pcSuccessAttack, kullaniciSirasi, userAttack, userDefence, pcAttack, pcDefence, userMiss, pcMiss, pcUlti, userUlti);
                    break;
                case 4:
                    Console.WriteLine($"Secilen karakter: {characters[user - 1].Name}, Bilgisayarın karakteri: {characters[index].Name}");
                    Atak(characters, user, index, userSuccessAttack, pcSuccessAttack, kullaniciSirasi, userAttack, userDefence, pcAttack, pcDefence, userMiss, pcMiss, pcUlti, userUlti);
                    break;

                default:
                    break;
            }
        }



        Console.ReadLine();
    }

    public static void Atak(List<Character> characters, int user, int index, int userSuccessAttack, int pcSuccessAttack, bool kullaniciSirasi, int userAttack, int userDefence, int pcAttack, int pcDefence, double userMiss, double pcMiss, int pcUlti, int userUlti)
    {





        while (userDefence > 0 || pcDefence > 0)
        {
            Console.WriteLine("Saldiriyi baslatmak icin saldir yazin");
            string saldir = Console.ReadLine();

            Random random1 = new Random();
            double rnd1 = random1.NextDouble();

            Random random2 = new Random();
            double rnd2 = random2.NextDouble();



            if (saldir.Trim().ToLower() == "saldir")
            {
                if (kullaniciSirasi)
                {
                    Console.WriteLine();
                    if (userMiss > rnd1)
                    {
                        Console.WriteLine("Maalesef iskaladin");
                        Console.WriteLine(rnd1);
                    }
                    else if (userSuccessAttack == 3)
                    {
                        Ulti(characters, user, index, pcSuccessAttack, userSuccessAttack, kullaniciSirasi, pcDefence, userDefence, pcUlti, userUlti);
                        userSuccessAttack = 0;
                    }
                    else
                    {
                        pcDefence -= userAttack;

                        if (pcDefence <= 0)
                        {
                            Console.WriteLine("Kazanadınız!");
                            return;
                        }

                        Console.WriteLine($"Kullanici saldiriya geciyor..");
                        Console.WriteLine($"Bilgisayar canı: {pcDefence}");
                        userSuccessAttack++;
                    }
                }
                else
                {
                    if (pcMiss > rnd2)
                    {
                        Console.WriteLine("Bilgisayar iskaladi");
                        Console.WriteLine(rnd2);
                    }
                    else if (pcSuccessAttack == 3)
                    {
                        Ulti(characters, user, index, pcSuccessAttack, userSuccessAttack, kullaniciSirasi, pcDefence, userDefence, pcUlti, userUlti);
                        pcSuccessAttack = 0;
                    }
                    else
                    {
                        userDefence -= pcAttack;
                        if (userDefence <= 0)
                        {
                            Console.WriteLine("Kaybettiniz!");
                            return;
                        }

                        Console.WriteLine($"Bilgisayar saldiriya geciyor..");
                        Console.WriteLine($"Kullanicin canı: {userDefence}");
                        pcSuccessAttack++;
                        Console.WriteLine(pcSuccessAttack);

                    }
                }
                kullaniciSirasi = !kullaniciSirasi;



            }
            else
            {
                Console.WriteLine("Geçersiz komut");
            }
        }

    }

    public static void Ulti(List<Character> characters, int user, int index, int userSuccessAttack, int pcSuccessAttack, bool kullaniciSirasi, int pcDefence, int userDefence, int pcUlti, int userUlti)
    {


        if (kullaniciSirasi)
        {
            if (userSuccessAttack == 3)
            {

                pcDefence -= userUlti;
                Console.WriteLine("ulti vuruş geldi.");
                Console.WriteLine($"Bilgisayar canı: {pcDefence}");

            }
        }
        else
        {
            if (pcSuccessAttack == 3)
            {

                userDefence -= pcUlti;
                Console.WriteLine("ulti vuruş geldi.");
                Console.WriteLine($"Bilgisayar canı: {userDefence}");
            }
        }




    }

}

